using DG.Tweening;
using EasyTransition;
using Manager;
using TMPro;
using UnityEngine;
using Utils;

public class MainGameEndPopupUI : MonoBehaviour
{
    [Header("GameManager Script")]
    [SerializeField] private GameManager gameManager;


    [Header("Text Component")]
    [SerializeField] private TMP_Text[] scoreTexts;
    [SerializeField] private TMP_Text comboText;

    [Header("AnswerCheckPanel")]
    [SerializeField] private RectTransform answerCheckPanel;

    [Header("TransitionSettings")]
    [SerializeField] private TransitionSettings transitionSettings;

    public void SetText(int score, int problemCount, int maxCombo)
    {
        scoreTexts[0].text = score.ToString();
        scoreTexts[1].text = problemCount.ToString();
        comboText.text = maxCombo.ToString();
    }
    public void OnClickOpenPanel()
    {
        answerCheckPanel.gameObject.SetActive(true);
    }
    public void OnClickClosePanel()
    {
        answerCheckPanel.gameObject.SetActive(false);
    }
    public void OnClick()
    {
        //로비 화변으로
        EventManager.Instance.RemoveEvent(MEventType.GameStart);
        EventManager.Instance.RemoveEvent(MEventType.GameEnd);
        EventManager.Instance.RemoveEvent(MEventType.GameStop);
        EventManager.Instance.RemoveEvent(MEventType.GameNextProblem);
        TransitionManager.Instance().Transition("LobbyScene", transitionSettings, 0.0f);
    }
}