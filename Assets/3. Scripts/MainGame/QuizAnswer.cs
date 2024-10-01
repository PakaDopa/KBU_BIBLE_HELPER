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

        [Header("Button")]
        [SerializeField] private TMP_Text[] bntTexts;

        private void Awake()
        {
            EventManager.Instance.AddListener(MEventType.GameStart, StartGame);
        }

        private void StartGame(MEventType MEventType, Component Sender, EventArgs args = null)
        {
            BibleData data = gameManager.GetCurrentProblem();
            string[] strs = data.answers;

            for(int i = 0; i < strs.Length; i++)
            {
                bntTexts[i].text = strs[i];
            }
        }

        public void OnClick(int ind)
        {
            //정답
            int answerIndex = gameManager.GetCurrentProblem().answerIndex;
            if (answerIndex == ind)
                EventManager.Instance.PostNotification(MEventType.GameNextProblem, this, new TransformEventArgs(transform, true));
            else
                EventManager.Instance.PostNotification(MEventType.GameNextProblem, this, new TransformEventArgs(transform, false));
        }
    }
}