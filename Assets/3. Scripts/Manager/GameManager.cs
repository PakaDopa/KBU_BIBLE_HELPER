using DataLoader.Data;
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

        private BibleData currentProblem;                       // 지금 바라보고 있는 문제
        private int problemIndex = 0;                           // 지금 바라보고 있는 인덱스

        [Header("Timer 관련 데이터")]
        [SerializeField] private float timerTime = 10.0f;       // 각 문제당 주어지는 시간 default = 10s
        [SerializeField] private float firstWaitTime = 3.0f;    // 게임 처음 시작하고 대기 시간 default = 3s

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
                int ind = Random.Range(0, bibleDatas.Length);
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
            //PreInit
            MakeSettingData(settingList);
            //Make 30(n) Problems
            MakeProblems();
            //Make data[index]

            //Shot Event
            //EventManager.Instance.PostNotification(MEventType.GameStart, this, new TransformEventArgs(transform));
        }
    }
}