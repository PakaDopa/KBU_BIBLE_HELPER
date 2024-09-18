using System;

namespace Utils
{
    [Serializable]
    // TutorialManager에서 사용하는 이벤트 타입
    public enum TEventType
    {
        None = 0, //default
        End,
    }

    [Serializable]
    // EventManager에서 사용하는 이벤트 타입
    public enum MEventType
    {
        //SAVE & LOAD Data
        SaveData = 0,

        //GameScene EventType
        GameStart,
        GameEnd,
        GameStop,
        GameNextProblem,

        //Error Control
        None,
    }
}