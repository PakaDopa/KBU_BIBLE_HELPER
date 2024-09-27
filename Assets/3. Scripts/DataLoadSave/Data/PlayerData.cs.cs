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
        public List<QuizLog> quizLogs;
        public void Init()
        {
            playerId = 0;
            playerName = "";
            gold = 0;
            testamentDictionary = new TestamentDictionary[501];
            quizLogs = new List<QuizLog>();
        }
    }
}