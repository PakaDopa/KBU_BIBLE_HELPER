using DataLoader.Data;
using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        [Header("CSV 데이터")]
        [SerializeField] private AllBibleData datas;

        [Header("Timer 관련 데이터")]
        [SerializeField] private float timerTime = 10.0f;       // 각 문제당 주어지는 시간 default = 10s
        [SerializeField] private float firstWaitTime = 3.0f;    // 게임 처음 시작하고 대기 시간 default = 3s

        public void Awake()
        {
            //Game Event Add
        }

        private void Start()
        {
            //Game Start()!
        }
    }
}