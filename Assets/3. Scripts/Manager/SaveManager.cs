using DataLoad.Data;
using System;
using System.IO;
using UnityEngine;
using Utils;

namespace Manager
{
    public class SaveManager : Singleton<SaveManager>
    {
        PlayerData data = null;
        public PlayerData GetPlayerData()
        {
            return data = LoadData();
        }
        private void Awake()
        {
            EventManager.Instance.AddListener(MEventType.SaveData, SaveData);
        }
        public void SaveData(MEventType MEventType, Component Sender, EventArgs transformArgs)
        {
            var args = transformArgs as TransformEventArgs;
            PlayerData data = (PlayerData)args.value[0];
            if (data == null)
            {
                Debug.LogError("이벤트로부터 넘겨받은 매개변수가 PlayerData로 형변환할 수 없습니다.");
                return;
            }

            // 약간의 암호화ㅋㅋ
            string json = JsonUtility.ToJson(data);
            //File.WriteAllText(Path.Combine(Application.persistentDataPath, "PlayerData.json"), json);
            File.WriteAllText(Path.Combine(Application.dataPath, "PlayerData.json"), json);
        }

        //Player Data를 가지고 옵니다.
        private PlayerData LoadData()
        {
            //string path = Application.persistentDataPath + "/PlayerData.json";
            string path = Application.dataPath + "/PlayerData.json";
            Debug.Log(path);

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                return JsonUtility.FromJson<PlayerData>(json);
            }
            else
                return null;
        }

        public override void Init()
        {
            Debug.Log("DataSave.cs Init Complete!");
        }
    }
}