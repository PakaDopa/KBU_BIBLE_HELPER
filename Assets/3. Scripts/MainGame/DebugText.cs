using DataLoader.Data;
using Manager;
using System;
using TMPro;
using UnityEngine;
using Utils;

namespace MainGame
{
    public class DebugText : MonoBehaviour
    {
        [Header("GameManager")]
        [SerializeField] private GameManager gameManager;

        [Header("TextComponent")]
        [SerializeField] private TMP_Text text;

        private void Awake()
        {
            EventManager.Instance.AddListener(MEventType.GameStart, StartGame);
        }

        private void StartGame(MEventType MEventType, Component Sender, EventArgs args = null)
        {
            BibleData data = gameManager.GetCurrentProblem();
            text.text = data.answerIndex.ToString();
        }
    }
}