using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class SceneLoadManager : Singleton<SceneLoadManager>
    {
        public enum SceneType
        {
            Awake,
            Title,
            Tutorial,
            Lobby,
            Main,
        }

        public void MoveScene(SceneType type)
        {
            switch(type)
            {
                case SceneType.Awake:
                    SceneManager.LoadScene("AwakeScene");
                    break;
                case SceneType.Title:
                    SceneManager.LoadScene("TitleScene");
                    break;
                case SceneType.Tutorial:
                    SceneManager.LoadScene("TutorialScene");
                    break;
                case SceneType.Lobby:
                    SceneManager.LoadScene("LobbyScene");
                    break;
                case SceneType.Main:
                    SceneManager.LoadScene("MainScene");
                    break;
                default:
                    break;

            }
        }
        public override void Init()
        {
            Debug.Log("SceneManager.cs Init Complete!");
        }
    }
}