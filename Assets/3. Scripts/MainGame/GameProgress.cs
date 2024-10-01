using DG.Tweening;
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
        private Sequence seq;

        private void Awake()
        {
            slider = GetComponent<Slider>();
            seq = DOTween.Sequence();
            EventManager.Instance.AddListener(MEventType.GameStart, StartGame);
        }

        private void StartGame(MEventType MEventType, Component Sender, EventArgs args)
        {
            int size = gameManager.ProblemIndex;
            int len = gameManager.ProblemCount;
            if (seq.IsPlaying() == true)
                seq.Kill();
            seq.SetAutoKill(true)
               .Append(slider.DOValue((size / (float)len), 0.25f));
        }
    }
}