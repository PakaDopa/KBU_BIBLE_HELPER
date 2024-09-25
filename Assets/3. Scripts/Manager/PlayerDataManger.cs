using DataLoader.Data;
using System.IO;
using UnityEngine;

namespace Manager
{
    public class PlayerDataManager : Singleton<PlayerDataManager>
    {
        private static string filePath = Application.dataPath + "PlayerData.json";
        public PlayerData LoadData()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonUtility.FromJson<PlayerData>(json);
            }
            else
                return null;
        }
        public void SaveData(PlayerData playerData)
        {
            if (playerData == null)
                return;

            string json = JsonUtility.ToJson(playerData);
            File.WriteAllText(filePath, json);
        }
        public override void Init()
        {
            //player Data를 가져오고, 없다면 새로 하나 만들어서 저장한다.
            var data = LoadData();
            if(data == null)
            {
                PlayerData playerData = ScriptableObject.CreateInstance<PlayerData>();
                playerData.Init();

                SaveData(playerData);
            }
        }
    }
}