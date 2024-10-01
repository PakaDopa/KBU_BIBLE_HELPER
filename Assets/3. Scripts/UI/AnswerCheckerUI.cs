using DataLoader.Data;
using Manager;
using UnityEngine;

public class AnswerCheckerUI : MonoBehaviour
{
    [Header("GameManager")]
    [SerializeField] private GameManager gameManager;

    [Header("Slot Prefab")]
    [SerializeField] private GameObject slot;

    [Header("Container")]
    [SerializeField] private RectTransform container;

    private void Start()
    {
        if (container.childCount > 0)
            return;
        //Init Container
        TestamentDictionary[] testamentDictionaries = gameManager.TestamentDictionaries;
        BibleData[] bibleData = gameManager.GetProblems.ToArray();
        
        for(int i = 0; i < testamentDictionaries.Length; i++)
        {
            string quiz = bibleData[i].problem;
            string answer = bibleData[i].answers[bibleData[i].answerIndex - 1];
            int index = bibleData[i].number;

            var newSlot = Instantiate(slot);
            newSlot.transform.SetParent(container.transform, false);
            newSlot.GetComponent<FeedbackSlot>().SetText(index, quiz, answer, testamentDictionaries[i].solvedType);
        }
    }
}
