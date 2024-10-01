using DG.Tweening;
using Manager;
using UnityEngine;
using EasyTransition;

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

    [Header("Transition 값")]
    [SerializeField] private TransitionSettings transition;
    [SerializeField] private float startDelay;

    [Header("BGM SoundSO")]
    [SerializeField] private SoundEventSO soEvent;
    [Header("Swipe SoundSO")]
    [SerializeField] private SoundEventSO swipeEvent;

    void Start()
    {
        //Dotween 실행
        DoTextEffect();
        soEvent.Raise();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            swipeEvent.Raise();
            DOTween.KillAll();
            TransitionManager.Instance().Transition("LobbyScene", transition, startDelay);
        }
        if (Input.touchCount > 0)
        {
            swipeEvent.Raise();
            DOTween.KillAll();
            var touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
                TransitionManager.Instance().Transition("LobbyScene", transition, startDelay);
        }
    }
    void DoTextEffect()
    {
        Sequence seq = DOTween.Sequence();
        seq.SetAutoKill(true);
        seq
            .PrependInterval(2f)
            .Append(_titleText.DOAnchorPosY(-46, 1.5f)).SetEase(Ease.OutBack)
            .Join(_subTitleText.DOAnchorPosY(-343, 2f)).SetEase(Ease.OutBack)
            .OnComplete(() =>
            {
                DoTitleEffect(_titleText);
                DoTitleEffect(_subTitleText);
            });

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
