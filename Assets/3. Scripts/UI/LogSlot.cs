using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class LogSlot : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    public void SetText(int index, TestamentType type, int score, int maxScore)
    {
        string format = "({0}).{1} [{2}/{3}]";
        string str = string.Format(format, index, TypeToString(type), score.ToString(), maxScore.ToString());
        text.text = str;
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
