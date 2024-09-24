using DataLoader.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        [Header("CSV 데이터")]
        [SerializeField] private AllBibleData datas;
        [SerializeField] private List<BibleData> problems;      // 실제 뽑힌 문제들
         
        // Setting Panel UI로부터 건네받는 변수들
        [SerializeField] private int problemCount = 15;         // 문제 개수
        [SerializeField] private TestamentType testamentType;   // 출제 문제 범위

        private int problemIndex = 0;                           // 지금 바라보고 있는 인덱스

        [Header("Timer 관련 데이터")]
        [SerializeField] private float timerTime = 10.0f;       // 각 문제당 주어지는 시간 default = 10s
        public float TimerTime { get { return timerTime; } }
        [SerializeField] private float firstWaitTime = 3.0f;    // 게임 처음 시작하고 대기 시간 default = 3s

        [Header("Game Eed Panel Object")]
        [SerializeField] private RectTransform gameEndPanel;
        [SerializeField] private RectTransform halfAlphaPanel;

        private void Awake()
        {
            EventManager.Instance.AddListener(MEventType.GameNextProblem, NextProblem);
        }
        /// <summary>
        /// CSV 데이터에서 SettingCount(Component Setting Value)를 토대로 문제지를 만듭니다.
        /// </summary>
        private void MakeProblems()
        {
            problems = new List<BibleData>();
            BibleData[] bibleDatas = datas.bibleDatas;
            //0 - 500
            int[] checkArr = new int[bibleDatas.Length];

            //전체가 아닐 경우
            if(testamentType != TestamentType.All)
                bibleDatas = bibleDatas.Where(x => x.testamentType == testamentType).ToArray();

            //뽑기
            for (int i = 0; i < problemCount; i++)
            {
                int ind = UnityEngine.Random.Range(0, bibleDatas.Length);
                Debug.Log(ind);
                if (checkArr[ind] == 1) // 중복 문제를 뽑았을 시 다시뽑음
                {
                    i--;
                    continue;
                }
                checkArr[ind] = 1;
                problems.Add(bibleDatas[ind]);
            }
        }
        /// <summary>
        /// Game Setting Panel UI로부터 건네받은 string 데이터를 타입에 맞게 가공합니다.
        /// </summary>
        private void MakeSettingData(List<string> settingList)
        {
            int count = int.Parse(settingList[0]);
            string type = settingList[1];
            TestamentType tType = TestamentType.None;
            switch (type)
            {
                case "All":
                    tType = TestamentType.All;
                    break;
                case "구약":
                    tType = TestamentType.OldTestament;
                    break;
                case "신약":
                    tType = TestamentType.NewTestament;
                    break;
                default:
                    break;
            }

            //apply value
            problemCount = count;
            testamentType = tType;
        }
        public void GameInit(List<string> settingList)
        {
            problemIndex = 0;
            //PreInit
            MakeSettingData(settingList);
            //Make 30(n) Problems
            MakeProblems();
            //Shot Event
            EventManager.Instance.PostNotification(MEventType.GameStart, this, new TransformEventArgs(transform));
        }

        //접근 가능 변수 함수
        public BibleData GetCurrentProblem() => problems[problemIndex];

        //이벤트 함수
        private void NextProblem(MEventType MEventType, Component Sender, EventArgs args = null)
        {
            var tArgs = args as TransformEventArgs;
            if (tArgs != null)
                Debug.Log(tArgs.value[0].ToString());

            problemIndex++;
            if (problemIndex >= problemCount)
            {
                Debug.Log("!!!!!!!!Game End!!!!!!!!!!");
                EventManager.Instance.PostNotification(MEventType.GameEnd, this, new TransformEventArgs(transform));

                gameEndPanel.gameObject.SetActive(true);
                halfAlphaPanel.gameObject.SetActive(true);
            }
            else
                EventManager.Instance.PostNotification(MEventType.GameStart, this, new TransformEventArgs(transform));
        }
    }
}