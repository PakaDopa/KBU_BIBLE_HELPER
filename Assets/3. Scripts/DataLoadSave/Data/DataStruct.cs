using System;
using Utils;

namespace DataLoader.Data
{
    [Serializable]
    public struct BibleData
    {
        public int number;                  //문제번호
        public string problem;              //문제
        public ProblemType problemType;     //문제 타입
        public string[] answers;            //답 4개
        public int answerIndex;             //answerIndex - 1 = 인덱스
        public TestamentType testamentType; //구약, 신약 타입 나누기
    }
}