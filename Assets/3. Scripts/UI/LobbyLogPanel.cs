using DataLoader.Data;
using Manager;
using UnityEngine;

public class LobbyLogPanel : MonoBehaviour
{
    [Header("Container Component")]
    [SerializeField] private RectTransform container;
    [SerializeField] private GameObject slotPrefab;

    private void Start()
    {
        var playerData = PlayerDataManager.Instance.LoadData();
        var logList = playerData.quizLogs;
        int index = 1;
        foreach(QuizLog log in logList)
        {
            var obj = Instantiate(slotPrefab).GetComponent<LogSlot>();
            obj.SetText(index++, log.type, log.score, log.maxScore);
            obj.transform.SetParent(container.transform, false);
        }
    }
}
