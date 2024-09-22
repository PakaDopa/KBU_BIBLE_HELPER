using Manager;
using System;
using UnityEngine;
using Utils;

namespace MainGame
{
    public class QuizTimer : MonoBehaviour
    {
        [Header("GameManager")]
        [SerializeField] private GameManager gameManager;
        float timer = 0;

        private void Awake()
        {
            EventManager.Instance.AddListener(MEventType.GameStart, StartGame);
        }

        private void StartGame(MEventType MEventType, Component Sender, EventArgs args = null)
        {

        }
    }
}