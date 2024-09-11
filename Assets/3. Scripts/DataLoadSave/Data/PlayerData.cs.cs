using System;
using UnityEngine;
using Utils;

namespace DataLoader.Data
{
    [Serializable]
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/Data/PlayerData", order = 1)]
    public class PlayerData : ScriptableObject
    {
        public int index;
        [SerializeField] public TPair[] tPairs;
    }
}