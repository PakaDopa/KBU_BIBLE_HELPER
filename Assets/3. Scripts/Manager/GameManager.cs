using DataLoader.Data;
using UnityEngine;
using Utils;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        [Header("CSV 데이터")]
        [SerializeField] private AllBibleData datas;
        [SerializeField] private int defaultSettingCount = 15;  // Default 문제 카운트
        private BibleData currentProblem;                       // 지금 바라보고 있는 문제
        private int problemIndex = 0;                           // 지금 바라보고 있는 인덱스

        [Header("Timer 관련 데이터")]
        [SerializeField] private float timerTime = 10.0f;       // 각 문제당 주어지는 시간 default = 10s
        [SerializeField] private float firstWaitTime = 3.0f;    // 게임 처음 시작하고 대기 시간 default = 3s

        public void Awake()
        {
            //Game Event Add
        }
        /// <summary>
        /// CSV 데이터에서 SettingCount(Component Setting Value)를 토대로 문제지를 만듭니다.
        /// </summary>
        private void MakeProblems()
        {

        }
        public void GameInit()
        {
            //Make 30(n) Problems

            //Make data[index]

            //Shot Event
            EventManager.Instance.PostNotification(MEventType.GameStart, this, new TransformEventArgs(transform));
        }
    }
}