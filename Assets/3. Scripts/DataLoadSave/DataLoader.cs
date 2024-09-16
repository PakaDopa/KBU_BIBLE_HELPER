using System.Collections.Generic;
using UnityEngine;

namespace DataLoader
{
    public class DataLoader : MonoBehaviour
    {
        [Header("true = CSV to Prefab 로직 실행")]
        [SerializeField] private bool doMakePrefab = false;
        
        private string BibleDataBaseCsvPath = "Assets/2. Resources/8. CSV/BibleCSV.csv";

        private void Awake()
        {
            if (!doMakePrefab)
                return;

            PreloadData dataLoader = new PreloadData();
            try
            {
                List<Dictionary<string, object>> tCsv = dataLoader.LoadCSV(BibleDataBaseCsvPath);
                bool isSuccess = dataLoader.BibleCsvToPrefab(tCsv);
            }
            catch (System.Exception e)
            {
                Debug.LogError("    데이터 로드 실패 [" + e.Message + "]");
            }
        }
    }
}