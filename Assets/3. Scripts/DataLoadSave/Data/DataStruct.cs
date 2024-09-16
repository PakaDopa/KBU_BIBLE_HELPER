using System;

namespace DataLoader.Data
{
    [Serializable]
    public enum ProblemType
    {
        MultipleChoice = 0, //객관식
        Subjective,         //주관식
        None,               //예외처리
    }
    [Serializable]
    public struct BibleData
    {
        public int number;                 //문제번호
        public string problem;             //문제
        public ProblemType problemType;    //문제 타입
        public string[] answers;           //답 4개
        public int answerIndex;            //answerIndex - 1 = 인덱스
    }
}