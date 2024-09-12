using DG.Tweening;
using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUI : MonoBehaviour
{
    [Header("Scene 전환 변수")]
    [SerializeField] private TransitionSettings transition;
    [SerializeField] private float startDelay = 0f;

    [Header("Dotween 대상 UI")]
    [SerializeField] private RectTransform[] bnts;
    private Sequence seq;

    public void Start()
    {
        // Start Aniamtion
    }
    public void SceneChangeMainGame()
    {
        TransitionManager.Instance().Transition("MainGameScene", transition, startDelay);
    }
}
