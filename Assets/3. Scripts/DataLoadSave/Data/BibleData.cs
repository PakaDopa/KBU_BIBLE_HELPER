using System;
using UnityEngine;

namespace DataLoader.Data
{
    [Serializable]
    [CreateAssetMenu(fileName = "BibleData", menuName = "ScriptableObjects/Data/BibleData", order = 1)]
    public class AllBibleData : ScriptableObject
    {
        [SerializeField] public BibleData[] bibleDatas; //구약(모세오경)
        //[SerializeField] public BibleData[] bibleDatas;
        //[SerializeField] public BibleData[] bibleDatas;
        //[SerializeField] public BibleData[] bibleDatas;
    }
}