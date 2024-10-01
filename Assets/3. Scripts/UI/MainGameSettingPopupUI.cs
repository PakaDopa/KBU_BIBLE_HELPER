using DG.Tweening;
using Manager;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class MainGameSettingPopupUI : MonoBehaviour
{
    [Header("GameManager Script")]
    [SerializeField] private GameManager gameManager;

    [Header("Half Alpha Background Component")]
    [SerializeField] private RectTransform backTransform;
    [SerializeField] private AnimationCurve easeCurve;

    [Header("Button RectTrasnform")]
    [SerializeField] private RectTransform[] settingRectTransform;

    private List<string> settingList;                   // 게임 설정 값을 전달하는 개체

    private void Awake()
    {
        settingList = new List<string>();
    }
    private void Start()
    {
        ShowDotween(0);
    }
    //Button Event Function
    public void OnClickValueBnt(Button bnt)
    {
        string text = bnt.GetComponentInChildren<TMP_Text>().text;
        settingList.Add(text);
    }
    public void OnClickBnt(int ind)
    {
        ShowDotween(ind);
    }
    public void OnConfirmBnt()
    {
        Sequence seq = DOTween.Sequence();
        var rectTransform = GetComponent<RectTransform>();
        seq.SetAutoKill(true);
        seq.Append(rectTransform.DOAnchorPosY(-2200, 0.8f).SetEase(easeCurve))
            .OnComplete(() =>
            {
                backTransform.gameObject.SetActive(false);
                gameObject.SetActive(false);
            });

        //Sending Data
        gameManager.GameInit(settingList);
    }

    //Dotween Function
    private void ShowDotween(int nextInd)
    {
        Sequence seq = DOTween.Sequence();
        var rectTransform = settingRectTransform[nextInd];
        seq.SetAutoKill(true);
        seq.Append(rectTransform.DOAnchorPosX(0, 0.5f).SetEase(Ease.InOutElastic));
        if(nextInd > 0)
        {
            var preTransform = settingRectTransform[nextInd - 1];
            seq.Prepend(preTransform.DOAnchorPosX(1000, 0.5f).SetEase(Ease.InOutElastic));
        }
    }
}