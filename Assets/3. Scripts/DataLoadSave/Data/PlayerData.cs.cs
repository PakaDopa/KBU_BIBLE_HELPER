using System;
using System.Collections.Generic;
using UnityEngine;

namespace DataLoader.Data
{
    [Serializable]
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/Data/PlayerData", order = 1)]
    public class PlayerData : ScriptableObject
    {
        public int playerId;        //for sever
        public string playerName;
        public int gold;
        public TestamentDictionary[] testamentDictionary;
        [SerializeField] public List<QuizLog> quizLogs;

        public void Init()
        {
            playerId = 0;
            playerName = "";
            gold = 0;
            testamentDictionary = new TestamentDictionary[501];
            for (int i = 0; i < 250; i++)
            {
                testamentDictionary[i].type = Utils.TestamentType.OldTestament;
                testamentDictionary[i].number = i+1;
                testamentDictionary[i].solvedType = Utils.SolvedType.Hidden;
            }
            for (int i = 250; i < 500; i++)
            {
                testamentDictionary[i].type = Utils.TestamentType.NewTestament;
                testamentDictionary[i].number = (i + 1) - 250;
                testamentDictionary[i].solvedType = Utils.SolvedType.Hidden; 
            }
            quizLogs = new List<QuizLog>();
        }
    }
}