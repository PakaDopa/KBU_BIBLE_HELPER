using Manager;
using System;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace MainGame
{
    public class GameProgress : MonoBehaviour
    {
        [Header("GameManager")]
        [SerializeField] private GameManager gameManager;

        private Slider slider;

        private void Awake()
        {
            slider = GetComponent<Slider>();

            EventManager.Instance.AddListener(MEventType.GameStart, StartGame);
        }

        private void StartGame(MEventType MEventType, Component Sender, EventArgs args)
        {
            int size = gameManager.ProblemIndex;
            int len = gameManager.ProblemCount;

            slider.value = size / (float)len;
        }
    }
}