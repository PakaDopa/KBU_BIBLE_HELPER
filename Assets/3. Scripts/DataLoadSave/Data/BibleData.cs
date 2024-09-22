using System;
using UnityEngine;

namespace DataLoader.Data
{
    [Serializable]
    [CreateAssetMenu(fileName = "BibleData", menuName = "ScriptableObjects/Data/BibleData", order = 1)]
    public class AllBibleData : ScriptableObject
    {
        [SerializeField] public BibleData[] bibleDatas; //통합
    }
}