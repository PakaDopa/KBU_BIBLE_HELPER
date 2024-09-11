using System;

namespace DataLoad.Data
{
    [Serializable]
    public class PlayerData
    {
        public string name;      // 플레이어 이름
        public bool isTutorial;  // 튜토리얼이 끝났는지 아닌지?

        public bool isBGM;      // 브금 틀건지?
        public bool isEffect;   // 이펙트 사운드 틀건지?
        public bool isShake;    // 화면 흔들리게 할건지?
    }
}