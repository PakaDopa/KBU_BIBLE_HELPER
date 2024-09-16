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
        private const string CsvPath = "Assets/2. Resources/1. Prefabs/Data/";

        private const string TutorialTextsFileName = "BibleCSV.asset";
        private const string BibleDataFileName = "BibleCSV.asset";

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
                AssetDatabase.DeleteAsset(CsvPath + TutorialTextsFileName);
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

            AssetDatabase.CreateAsset(tData, CsvPath + TutorialTextsFileName);

            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
#endif
            return true;
        }
        public bool BibleCsvToPrefab(List<Dictionary<string, object>> data)
        {
#if UNITY_EDITOR
            if (data == null)
                return false;

            BibleData[] bibleDatas = new BibleData[data.Count];
            for(int i = 0; i < data.Count; i++)
            {
                object[] objects = data[i].Values.ToArray();
                try
                {
                    bibleDatas[i].number = int.Parse(objects[0].ToString());
                    bibleDatas[i].problem = objects[1].ToString();
                    bibleDatas[i].problemType = Converter.StringToEnum<ProblemType>(objects[2].ToString());

                    bibleDatas[i].answers = new string[4];
                    bibleDatas[i].answers[0] = objects[3].ToString();
                    bibleDatas[i].answers[1] = objects[4].ToString();
                    bibleDatas[i].answers[2] = objects[5].ToString();
                    bibleDatas[i].answers[3] = objects[6].ToString();
                    
                    bibleDatas[i].answerIndex = int.Parse(objects[7].ToString()) - 1;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            var datas = ScriptableObject.CreateInstance<AllBibleData>();
            datas.bibleDatas = bibleDatas;
            AssetDatabase.CreateAsset(datas, CsvPath + BibleDataFileName);

            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
#endif
            return true;
        }
    }
}