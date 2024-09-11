using System.Collections.Generic;
using UnityEngine;

namespace DataLoader
{
    public class DataLoader : MonoBehaviour
    {
        [Header("true = CSV to Prefab 로직 실행")]
        [SerializeField] private bool doMakePrefab = false;
        
        private string tutorialCSVPath = "Assets/10. Resources/CSV/TutorialCSV.csv";

        private void Awake()
        {
            if (!doMakePrefab)
                return;

            PreloadData dataLoader = new PreloadData();
            //Debug.Log("Data Load Start!");
            try
            {
                //Debug.Log("    튜토리얼 CSV 데이터 파싱 시작");
                //dataLoader.DeletePrefabsData();
                List<Dictionary<string, object>> tCsv = dataLoader.LoadCSV(tutorialCSVPath);
                bool isSuccess = dataLoader.TutorialCsvToPrefab(tCsv);
            }
            catch (System.Exception e)
            {
                Debug.LogError("    데이터 로드 실패 [" + e.Message + "]");
            }
            //Debug.Log("Data Load End!");
        }
    }
}