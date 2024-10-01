using Cysharp.Threading.Tasks.Triggers;
using DataLoader.Data;
using Manager;
using TMPro;
using UnityEngine;
using Utils;

public class DicSlot : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    [SerializeField]
    [ColorUsage(false, true)] private Color noTypeColor;
    [SerializeField]
    [ColorUsage(false, true)] private Color solvedTypeColor;
    [SerializeField]
    [ColorUsage(false, true)] private Color UnSolvedTypeColor;
    //문제 푼 여부에 따라서 어떻게 보일지를 정함 (퀴즈에서 안 나온 경우, 푼 경우, 틀린 경우)

    public void Init(BibleData bibleData)
    {
        SetText(bibleData);
        SetViusal(bibleData);
    }
    public void SetViusal(BibleData bibleData)
    {
        SolvedType type = bibleData.solvedType;
        switch(type)
        {
            case SolvedType.Hidden:
                break;
            case SolvedType.Solved:
                break;
            case SolvedType.NotSolved:
                break;
            default:
                break;
        }
    }
    public void SetText(BibleData bibleData)
    {
        //Setting Data
        string type = TypeToString(bibleData.testamentType);
        string number = bibleData.number.ToString();
        string problem = bibleData.problem.Substring(0, 12) + "...";
        string answer = bibleData.answers[bibleData.answerIndex - 1];
        if (answer.Length > 7)
            answer = answer.Substring(0, 7);
        string answerFormat = string.Format("정답: [{0}] {1}", bibleData.answerIndex, answer);
        string textFormat = string.Format("{0} {1}. {2}\n{3}", type, number, problem, answerFormat);
        text.text = textFormat;
    }
    private string TypeToString(TestamentType type)
    {
        switch (type)
        {
            case TestamentType.None:
                return "None";
            case TestamentType.OldTestament:
                return "구약";
            case TestamentType.NewTestament:
                return "신약";
            case TestamentType.All:
                return "All";
        }
        return "None";
    }
}
