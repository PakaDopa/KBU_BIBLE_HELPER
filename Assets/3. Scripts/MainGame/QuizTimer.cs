using DG.Tweening.Core.Easing;
using Manager;
using System;
using TMPro;
using UnityEngine;
using Utils;

namespace MainGame
{
    public class QuizTimer : MonoBehaviour
    {
        [Header("GameManager")]
        [SerializeField] private GameManager gameManager;
        [SerializeField] private bool isOn = false;
        float timer = 0;
        

        [Header("Text")]
        [SerializeField] private TMP_Text timerText;

        private void Awake()
        {
            EventManager.Instance.AddListener(MEventType.GameStart, StartGame);
            EventManager.Instance.AddListener(MEventType.GameEnd, EndGame);
        }
        private void Update()
        {
            if(isOn == true)
            {
                timer -= Time.deltaTime;
                if(timer < 0)
                {
                    timer = 0;
                    isOn = false;
                    //Time Over
                    EventManager.Instance.PostNotification(MEventType.GameNextProblem, this, new TransformEventArgs(transform, false));
                }
            }
            timerText.text = ((int)timer).ToString();
        }
        private void StartGame(MEventType MEventType, Component Sender, EventArgs args = null)
        {
            float maxTime = gameManager.TimerTime;
            timer = maxTime + 1;
            isOn = true;
        }
        private void EndGame(MEventType MEventType, Component Sender, EventArgs args = null) => isOn = false;
    }
}