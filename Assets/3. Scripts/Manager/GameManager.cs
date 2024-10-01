using DataLoader.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;
using static Manager.EventManager;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        [Header("CSV 데이터")]
        [SerializeField] private AllBibleData datas;
        public AllBibleData AllBD { get { return datas; } }
        [SerializeField] private List<BibleData> problems;      // 실제 뽑힌 문제들
        public List<BibleData> GetProblems {  get { return problems; } }
         
        // Setting Panel UI로부터 건네받는 변수들
        [SerializeField] private int problemCount = 15;         // 문제 개수
        public int ProblemCount { get { return problemCount; } }
        [SerializeField] private TestamentType testamentType;   // 출제 문제 범위
        public TestamentType TestamentType { get { return testamentType; } }

        private int problemIndex = 0;                           // 지금 바라보고 있는 인덱스
        public int ProblemIndex { get { return problemIndex; } }

        [Header("Timer 관련 데이터")]
        [SerializeField] private float timerTime = 10.0f;       // 각 문제당 주어지는 시간 default = 10s
        public float TimerTime { get { return timerTime; } }
        [SerializeField] private float firstWaitTime = 3.0f;    // 게임 처음 시작하고 대기 시간 default = 3s

        [Header("Game Eed Panel Object")]
        [SerializeField] private RectTransform gameEndPanel;
        [SerializeField] private RectTransform halfAlphaPanel;

        private int maxCombo = 0;                               //최대 콤보
        private int combo = 0;                                  //현재 콤보
        public int Combo { get { return combo; } }
        private int answerCount = 0;                            //정답 횟수
        private TestamentDictionary[] testamentDictionaries;    //정답 저장 (오답노트용) -> 사전에도 등록해야함. (게임끝)
        public TestamentDictionary[] TestamentDictionaries { get { return testamentDictionaries; } }

        [Header("BGM So Event")]
        [SerializeField] private SoundEventSO soEvent;
        [Header("Combo So Event")]
        [SerializeField] private SoundEventSO comboEvent;
        [Header("End So Event")]
        [SerializeField] private SoundEventSO EndEvent;
        private void Awake()
        {
            EventManager.Instance.AddListener(MEventType.GameNextProblem, NextProblem);
        }

        private void Start()
        {
            soEvent.Raise();
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
            testamentDictionaries = new TestamentDictionary[problemCount];
            //Shot Event
            EventManager.Instance.PostNotification(MEventType.GameStart, this, new TransformEventArgs(transform));
        }
        public void SaveDictionaryData(TestamentDictionary[] testaments)
        {
            TestamentDictionary[] playerData = PlayerDataManager.Instance.LoadData().testamentDictionary;
            //30문제가 testaments에 들어옴
            for(int i = 0; i < testaments.Length; i++)
            {
                var target = testaments[i];

                for(int j = 0; j < playerData.Length; j++)
                {
                    if(target.type == playerData[j].type
                        && target.number == playerData[j].number)
                    {
                        playerData[j].solvedType = target.solvedType;
                    }
                }
            }
            PlayerDataManager.Instance.SaveData(playerData);
        }
        //접근 가능 변수 함수
        public BibleData GetCurrentProblem() => problems[problemIndex];

        //이벤트 함수
        private void NextProblem(MEventType MEventType, Component Sender, EventArgs args = null)
        {
            //debug log
            var tArgs = args as TransformEventArgs;
            if (tArgs != null)
                Debug.Log(tArgs.value[0].ToString());

            //정답일 때
            if (bool.Parse(tArgs.value[0].ToString()) == true)
            {
                comboEvent.Raise();
                TestamentDictionaryInit(true);
                combo++;
                answerCount++;
                EventManager.Instance.PostNotification(MEventType.GameEffect, this, new TransformEventArgs(transform, true));
            }
            else //오답일 때
            {
                TestamentDictionaryInit(false);
                maxCombo = Math.Max(maxCombo, combo);
                combo = 0;
                EventManager.Instance.PostNotification(MEventType.GameEffect, this, new TransformEventArgs(transform, false));
            }

            problemIndex++;
            if (problemIndex >= problemCount)
            {
                EventManager.Instance.PostNotification(MEventType.GameEnd, this, new TransformEventArgs(transform));
                EndEvent.Raise();
                gameEndPanel.gameObject.SetActive(true);
                gameEndPanel.GetComponent<MainGameEndPopupUI>().SetText(answerCount, problemCount, maxCombo);
                halfAlphaPanel.gameObject.SetActive(true);
            }
            else
            {
                EventManager.Instance.PostNotification(MEventType.GameStart, this, new TransformEventArgs(transform));
            }
        }
        private void TestamentDictionaryInit(bool isSovled)
        {
            int number = GetCurrentProblem().number;
            testamentDictionaries[problemIndex].type = problems[problemIndex].testamentType;
            testamentDictionaries[problemIndex].number = number;
            testamentDictionaries[problemIndex].solvedType = isSovled == true ? SolvedType.Solved : SolvedType.NotSolved;
        }
    }
}