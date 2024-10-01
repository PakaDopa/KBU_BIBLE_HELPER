using DG.Tweening;
using EasyTransition;
using Manager;
using UnityEngine;

public class LobbyUI : MonoBehaviour
{
    [Header("Scene Transitions")]
    [SerializeField] private RectTransform showLogPanel;   //퀴즈 로그 패널
    [SerializeField] private RectTransform dicPanel;        //문제 도감 패널

    [Header("Scene Transitions")]
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
        bntSeq.SetAutoKill(true); //Scene ��ȯ�� ������

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

    //Button Event
    public void SceneChangeMainGame()
    {
        TransitionManager.Instance().Transition("MainGameScene", transition, startDelay);
    }
    public void OnClick_ShowLogPanel(bool isEnable)
    {
        showLogPanel.gameObject.SetActive(isEnable);
    }
    public void OnClick_DicPanel(bool isEnable)
    {
        dicPanel.gameObject.SetActive(isEnable);
    }
    public void OnClick_GameExit()
    {
        //PlayerDataManager.Instance.SaveData();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
#else
        Application.Quit();
#endif
    }
}
