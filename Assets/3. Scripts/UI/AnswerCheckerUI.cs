using DataLoader.Data;
using Manager;
using UnityEngine;

public class AnswerCheckerUI : MonoBehaviour
{
    [Header("GameManager")]
    [SerializeField] private GameManager gameManager;

    [Header("Slot Prefab")]
    [SerializeField] private RectTransform slot;

    [Header("Container")]
    [SerializeField] private RectTransform container;

    private void Start()
    {
        //Init Container
        TestamentDictionary[] testamentDictionaries = gameManager.TestamentDictionaries;
    }
}
