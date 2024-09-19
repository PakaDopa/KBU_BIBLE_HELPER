using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class MainGameSettingPopupUI : MonoBehaviour
{
    [Header("설정 옵션들")]
    [SerializeField] private RectTransform[] settingRectTransform;

    [Header("게임 설정 값")]
    [SerializeField] private int settingCount;          //결정된 문제 수
    [SerializeField] private TestamentType problemType;   //성경 문제 타입 (전체, 구약, 신약)

    private void Awake()
    {
    }
    private void Start()
    {
        ShowOption(0);
    }
    public void OnClickBnt(int ind)
    {
        ShowOption(ind);
    }
    private void ShowOption(int ind)
    {
        //error control
        if (settingRectTransform.Length < ind)
            return;

        ShowDotween(settingRectTransform[ind]);
    }
    private void ShowDotween(RectTransform rectTransform)
    {
        Sequence seq = DOTween.Sequence();
        seq.SetAutoKill(true);
        seq.Append(rectTransform.DOAnchorPosX(0, 0.5f));
    }
}