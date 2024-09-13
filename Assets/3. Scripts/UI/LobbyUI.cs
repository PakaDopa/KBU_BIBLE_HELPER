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

    [Header("Dotween Target Bottom UI")]
    [SerializeField] private RectTransform[] bnts;
    [Header("Dotween Target Top UI")]
    [SerializeField] private RectTransform goldUI;
    [SerializeField] private RectTransform playerUI;
    [SerializeField] private float moveValue;
    [SerializeField] private float moveTime;

    public void Start()
    {
        // Start Aniamtion
        Sequence bntSeq = DOTween.Sequence();
        bntSeq.SetAutoKill(true); //Scene 전환시 삭제함

        //botton ui
        for(int i = bnts.Length - 1; i >= 0; i--)
        {
            RectTransform bnt = bnts[i];
            bntSeq.Join(bnt.DOAnchorPosX(0, 0.5f)).SetDelay(0.125f);
        }

        DoInterfaceEffect(goldUI);
        DoInterfaceEffect(playerUI);
    }
    void DoInterfaceEffect(RectTransform _rect)
    {
        Vector2 textPos = _rect.anchoredPosition;
        float value = textPos.x - moveValue;
        float backValue = textPos.x + moveValue;

        Sequence titleTextSeq = DOTween.Sequence();
        titleTextSeq.SetAutoKill(true);
        titleTextSeq
            .Append(_rect.DOAnchorPosX(value, moveTime))
            .Append(_rect.DOAnchorPosX(value + moveValue, moveTime));

        titleTextSeq.SetLoops(-1, LoopType.Restart);
    }
    public void SceneChangeMainGame()
    {
        TransitionManager.Instance().Transition("MainGameScene", transition, startDelay);
    }
}
