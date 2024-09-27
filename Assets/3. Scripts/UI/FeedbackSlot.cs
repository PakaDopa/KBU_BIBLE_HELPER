using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackSlot : MonoBehaviour
{
    [SerializeField] private TMP_Text quiz;
    [SerializeField] private TMP_Text answer;
    [SerializeField] int number;

    [SerializeField] private bool isSolved;

    [Header("Image Icon")]
    [SerializeField] private Image icon;
    [SerializeField] private Sprite solvedSprite;
    [SerializeField] private Sprite unSolvedSprite;


    public void SetText(int number, string quiz, string answer, bool isSolved)
    {
        this.number = number;
        this.quiz.text = quiz;
        this.answer.text = answer;

        icon.sprite = isSolved == true ? solvedSprite : unSolvedSprite;
        if (isSolved == false) //#FFBBBB
            GetComponent<Image>().color = new Color(255, 187, 187);
    }
}
