using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace UnityToolbarExtender.Examples
{
	static class ToolbarStyles
	{
		public static readonly GUIStyle commandButtonStyle;

		static ToolbarStyles()
		{
			commandButtonStyle = new GUIStyle("Command")

			{
				fontSize = 16,
				alignment = TextAnchor.MiddleCenter,
				imagePosition = ImagePosition.ImageAbove,
				fontStyle = FontStyle.Bold
			};
		}
	}

	[InitializeOnLoad]
	public class SceneSwitchLeftButton
	{
		static SceneSwitchLeftButton()
		{
			ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
		}

		static void CreateButton(string text, string sceneName)
		{
            GUIContent buttonContent = new GUIContent(text);
            Vector2 buttonSize = GUI.skin.button.CalcSize(buttonContent);
            if (GUILayout.Button(buttonContent, GUILayout.Width(buttonSize.x), GUILayout.Height(buttonSize.y)))
            {
                SceneHelper.OpenScene(sceneName);
            }
        }
		static void OnToolbarGUI()
		{
            GUILayout.FlexibleSpace();

			string[] bntText = { "AwakeScene", "TitleScene", "LobbyScene", "TutorialScene", "MainGameScene", "ExamGameScene" };
			for (int i = 0; i < bntText.Length; i++)
				CreateButton(bntText[i], bntText[i]);
		}
	}

	static class SceneHelper
	{
		static string sceneToOpen;

		public static void OpenScene(string sceneName)
		{
            var saved = EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            if (saved)
            {
                _ = EditorSceneManager.OpenScene($"Assets/1. Scenes/{sceneName}.unity");
            }
        }

		static void OnUpdate()
		{
			if (sceneToOpen == null ||
			    EditorApplication.isPlaying || EditorApplication.isPaused ||
			    EditorApplication.isCompiling || EditorApplication.isPlayingOrWillChangePlaymode)
			{
				return;
			}

			EditorApplication.update -= OnUpdate;

			if(EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
			{
				// need to get scene via search because the path to the scene
				// file contains the package version so it'll change over time
				string[] guids = AssetDatabase.FindAssets("t:scene " + sceneToOpen, null);
				if (guids.Length == 0)
				{
					Debug.LogWarning("Couldn't find scene file");
				}
				else
				{
					string scenePath = AssetDatabase.GUIDToAssetPath(guids[0]);
					EditorSceneManager.OpenScene(scenePath);
					EditorApplication.isPlaying = true;
				}
			}
			sceneToOpen = null;
		}
	}
}