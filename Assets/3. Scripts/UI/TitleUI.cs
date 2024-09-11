using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleUI : MonoBehaviour
{
    [Header("UI 텍스트 효과 컴포넌트")]
    [SerializeField]
    private RectTransform _titleText;
    [SerializeField]
    private RectTransform _subTitleText;
    [SerializeField]
    private RectTransform _infoText;

    [Header("UI 텍스트 효과 값")]
    [SerializeField] private float _moveValue;
    [SerializeField] private Vector3 _scaleValue;

    void Start()
    {
        //Dotween 실행
        DoTextEffect();
    }

    void DoTextEffect()
    {
        if (_titleText == null || _subTitleText == null || _infoText == null)
            return;

        DoTitleEffect(_titleText);
        DoTitleEffect(_subTitleText);

        _infoText.transform.DOScale(_scaleValue, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

    void DoTitleEffect(RectTransform _rect)
    {
        Vector2 textPos = _rect.anchoredPosition;
        float value = textPos.y - _moveValue;
        float backValue = textPos.y + _moveValue;

        Sequence titleTextSeq = DOTween.Sequence();
        titleTextSeq
            .Append(_rect.DOAnchorPosY(value, 0.75f))
            .Append(_rect.DOAnchorPosY(value + _moveValue, 0.75f));
        titleTextSeq.SetLoops(-1, LoopType.Restart);
    }
}
