using System;
using Utils;

namespace DataLoader.Data
{
    [Serializable]
    public struct BibleData
    {
        public int number;                  //문제번호(id)
        public string problem;              //문제
        public ProblemType problemType;     //문제 타입
        public string[] answers;            //답 4개
        public int answerIndex;             //정답 번호
        public TestamentType testamentType; //구약, 신약 타입 나누기
        public SolvedType solvedType;       //해당 문제 풀었는지 안 풀었는지
    }

    [Serializable]
    public struct TestamentDictionary
    {
        public TestamentType type;
        public int number;
        public bool isSolved;
    }

    [Serializable]
    public class QuizLog
    {
        public int id;
        public TestamentType type;
        public int score;
        public int maxScore;
    }
}