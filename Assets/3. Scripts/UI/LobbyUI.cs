using DG.Tweening;
using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUI : MonoBehaviour
{
    [Header("Scene ��ȯ ����")]
    [SerializeField] private TransitionSettings transition;
    [SerializeField] private float startDelay = 0f;

    [Header("Dotween ��� UI")]
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
