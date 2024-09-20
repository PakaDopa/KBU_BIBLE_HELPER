using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class MainGameSettingPopupUI : MonoBehaviour
{
    [Header("Half Alpha Background Component")]
    [SerializeField] private RectTransform backTransform;
    [SerializeField] private AnimationCurve easeCurve;

    [Header("설정 옵션들")]
    [SerializeField] private RectTransform[] settingRectTransform;

    [Header("버튼 Event관리")]
    [SerializeField] private Button[] problemCountBnts;
    [SerializeField] private Button[] typeBnts;

    [Header("게임 설정 값")]
    [SerializeField] private int settingCount;            //결정된 문제 수
    [SerializeField] private TestamentType problemType;   //성경 문제 타입 (전체, 구약, 신약)

    private void Start()
    {
        ShowOption(0);
    }
    public void OnClickBnt(int ind)
    {
        ShowOption(ind);
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
        seq.Append(rectTransform.DOAnchorPosX(0, 0.5f).SetEase(Ease.InOutElastic));
    }
}