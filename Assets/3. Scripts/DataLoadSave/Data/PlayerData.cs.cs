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
            for (int i = 0; i < testamentDictionary.Length; i++)
            {
                testamentDictionary[i].type = Utils.TestamentType.None;
                testamentDictionary[i].number = -1;
                testamentDictionary[i].isSolved = false;
            }
            quizLogs = new List<QuizLog>();
        }
    }
}