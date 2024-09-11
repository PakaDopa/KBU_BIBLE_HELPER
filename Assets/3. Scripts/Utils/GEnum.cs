namespace Utils
{
    // Tutorial에서 사용하는 텍스트 박스 사이즈
    public enum TutorialBoxSize
    {
        XSmall,
        Small,
        Middle,
        Large,
        XLarge,
        None,
    }

    public enum TriggerZoneEventType
    {
        None,           //예외처리용
        Jump,           //점프
        Crawl,          //기어가기
        Turn,           //옆 레인으로 이동 
        WakeUp,         //이쁜누나 타입 <- 미구현
        EndLine,        //도착!
    }
}