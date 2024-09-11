using System;
using UnityEngine;
using Utils;

namespace DataLoader.Data
{
    [Serializable]
    public struct TPair
    {
        public string Text;
        public TEventType EventType;
        public string Descending;
        public TutorialBoxSize Size;
    }
    [Serializable]
    [CreateAssetMenu(fileName = "TutorialTexts", menuName = "ScriptableObjects/Data/TutorialTexts", order = 1)]
    public class TutorialData : ScriptableObject
    {
        public int index;
        [SerializeField] public TPair[] tPairs;
    }
}