using System;

namespace Utils
{
    [Serializable]
    // TutorialManager에서 사용하는 이벤트 타입
    public enum TEventType
    {
        None = 0, //default
        PlayerNameInput,
        ZoomOut,
        SceneMove,
        FadeInOut,
        TAnimationHandler,
        TextScaleUp,
        FakeJump,
        TJump,
        End,
    }

    [Serializable]
    // EventManager에서 사용하는 이벤트 타입
    public enum MEventType 
    {
        //SAVE & LOAD Data
        SaveData = 0,
        LoadData,
        //Trigger Zone 
        TriggerZoneEntered,
        TriggerZoneExit,
        //Typing
        TypingCompleted,//타이핑 완료 
        Completed,//맞았는지 틀렸는지 체크
        Failed,
        //Game
        GameOver,
        GameClear,
    }
}