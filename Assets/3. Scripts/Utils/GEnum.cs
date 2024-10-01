using System;

namespace Utils
{
    // Tutorial에서 사용하는 텍스트 박스 사이즈
    [Serializable]
    public enum TutorialBoxSize
    {
        XSmall,
        Small,
        Middle,
        Large,
        XLarge,
        None,
    }
    [Serializable]
    public enum SettingBntType
    {
        None,
        ProblemCount,
        ProblemRange,
    }
    [Serializable]
    public enum TestamentType
    {
        None,
        OldTestament,
        NewTestament,
        All,
    }
    [Serializable]
    public enum SolvedType
    {
        Hidden,
        Solved,
        NotSolved
    }
    [Serializable]
    public enum ProblemType
    {
        MultipleChoice = 0, //객관식
        Subjective,         //주관식
        None,               //예외처리
    }

    [Serializable]
    public enum SoundType
    {
        MainBGM = 0,
        SecondBGM,
        Click_1,
        Click_2,
        Click_3,
        Click_4,
        Combo,
        ComboUpgrade,
        GameClear_1,
        Swipe
    }
}