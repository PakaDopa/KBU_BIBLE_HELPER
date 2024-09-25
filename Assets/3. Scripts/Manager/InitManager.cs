using UnityEngine;
using DG.Tweening;

namespace Manager
{
    public class InitManager : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
            Screen.SetResolution(1080, 1920, Screen.fullScreen);

            DOTween.Init();

            EventManager.Instance.Init();
            //SaveManager.Instance.Init();
            PlayerDataManager.Instance.Init();
            TimeManager.Instance.Init();
            SceneLoadManager.Instance.Init();
        }

        private void Start()
        {
            SceneLoadManager.Instance.MoveScene(SceneLoadManager.SceneType.Title);
        }
    }
}
