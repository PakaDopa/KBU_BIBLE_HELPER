using DataLoad.Data;
using Manager;
using UnityEngine;

public class InitManager : MonoBehaviour
{
    private void Awake()
    {
        //Application.targetFrameRate = 60;
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
        var data = SaveManager.Instance.GetPlayerData();
        if(data == null)
        {
            PlayerData defaultData = new PlayerData();
            defaultData.isTutorial = false;
            defaultData.isEffect = true;
            defaultData.isBGM = true;
            defaultData.isShake = true;
            defaultData.name = "";

            SaveManager.Instance.SaveData(Utils.MEventType.SaveData, this,
                new TransformEventArgs(transform, defaultData));
        }
    }
}
