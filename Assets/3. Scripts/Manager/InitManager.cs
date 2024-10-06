using UnityEngine;
using DG.Tweening;

namespace Manager
{
    public class InitManager : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
            Screen.SetResolution(720, 1280, Screen.fullScreen);
            DOTween.Init();

            EventManager.Instance.Init();
            PlayerDataManager.Instance.Init();
            TimeManager.Instance.Init();
            SceneLoadManager.Instance.Init();
            ParticleManager.Instance.Init();
        }

        private void Start()
        {
            SceneLoadManager.Instance.MoveScene(SceneLoadManager.SceneType.Title);
        }
    }
}
