using DataLoader.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Utils;

namespace DataLoader
{
    public class PreloadData
    {
        private const string TutorialCsvPath = "Assets/03. Prefabs/DataPrefabs/";
        private const string TutorialTextsFileName = "TutorialTexts.asset";

        public List<Dictionary<string, object>> LoadCSV(string filePath)
        {
            List<Dictionary<string, object>> fileData = CSVReader.Read(filePath);

            return fileData == null ? throw new FileNotFoundException() : fileData;
        }
        public void DeletePrefabsData()
        {
#if UNITY_EDITOR
            try
            {
                AssetDatabase.DeleteAsset(TutorialCsvPath + TutorialTextsFileName);
                AssetDatabase.Refresh();
                AssetDatabase.SaveAssets();
            }
            catch (Exception)
            {
                return;
            }
#endif
            return;
        }
        public bool TutorialCsvToPrefab(List<Dictionary<string, object>> data)
        {
#if UNITY_EDITOR
            if (data == null)
                return false;

            TPair[] tPairs = new TPair[data.Count];
            for(int i = 0; i < data.Count; i++)
            {
                object[] values = data[i].Values.ToArray();
                try
                {
                    string text = values[1].ToString();
                    TEventType type = Converter.StringToEnum<TEventType>(values[2].ToString());
                    string desc = values[3].ToString();
                    TutorialBoxSize boxSize = Converter.StringToEnum<TutorialBoxSize>(values[4].ToString());
                    
                    tPairs[i].Text = text;
                    tPairs[i].EventType = type;
                    tPairs[i].Descending = desc;
                    tPairs[i].Size = boxSize;
                    
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
            //TutorialData tData = new TutorialData();
            var tData = ScriptableObject.CreateInstance<TutorialData>();
            tData.tPairs = tPairs;
            tData.index = 0;

            AssetDatabase.CreateAsset(tData, TutorialCsvPath + TutorialTextsFileName);

            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
#endif
            return true;
        }
    }
}