using DG.Tweening;
using Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class MainGameCombo : MonoBehaviour
{
    [Header("GameManager")]
    [SerializeField]
    private GameManager gameManager;
    
    [SerializeField]
    private TMP_Text numberText;

    private Sequence effect;
    private Sequence alwaysEffect; //흔들리는 이펙트

    [SerializeField]
    private AnimationCurve animationCurve;
    
    private void Awake()
    {
        effect = DOTween.Sequence();
        alwaysEffect = DOTween.Sequence();
        EventManager.Instance.AddListener(MEventType.GameEffect, TextChange);
    }
    private void Start()
    {
        //var rectTrans = GetComponent<RectTransform>();
        //alwaysEffect.SetAutoKill(true)
        //    .Append(rectTrans.DOShakeAnchorPos(1, 10))
        //    .SetLoops(-1, LoopType.Restart);
    }
    private void SetEnable(bool enable)
    {
        var image = GetComponent<Image>();
        if (enable == false)
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        else
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
    }
    private void TextChange(MEventType MEventType, Component Sender, EventArgs args)
    {
        if (args is not TransformEventArgs tArgs) return;
        bool isSolved = bool.Parse(tArgs.value[0].ToString());
        if (isSolved == true)
        {
            //SetEnable(true);
            var rectTrans = GetComponent<RectTransform>();
            if (effect.IsPlaying())
                effect.Kill();
            effect = DOTween.Sequence();
            effect
                .SetAutoKill(true)
                .Append(rectTrans.DOAnchorPosY(-220, 0.01f))
                .Append(rectTrans.DOAnchorPosY(400, 9f))
                .Play();
            numberText.text = gameManager.Combo.ToString();
        }
        Debug.Log("[MainGameCombo.cs] combo : " + gameManager.Combo.ToString());
    }
}
