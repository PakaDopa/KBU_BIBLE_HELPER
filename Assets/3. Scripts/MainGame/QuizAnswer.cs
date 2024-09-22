using DataLoader.Data;
using Manager;
using System;
using TMPro;
using UnityEngine;
using Utils;

namespace MainGame
{
    public class QuizAnswer : MonoBehaviour
    {
        [Header("GameManager")]
        [SerializeField] private GameManager gameManager;

        private void Awake()
        {
            EventManager.Instance.AddListener(MEventType.GameStart, StartGame);
        }

        private void StartGame(MEventType MEventType, Component Sender, EventArgs args = null)
        {
        }
    }
}