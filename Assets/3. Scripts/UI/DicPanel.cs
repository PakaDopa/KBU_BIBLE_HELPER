using DataLoader.Data;
using Manager;
using UnityEngine;

public class DicPanel : MonoBehaviour
{
    [Header("Container Component")]
    [SerializeField] private RectTransform container;
    [SerializeField] private GameObject slotPrefab;

    [Header("All Bible Data")]
    [SerializeField] private AllBibleData allBibleData;

    //quiz db를 적용
    private void InitPrefabs()
    {
        foreach(BibleData bibleData in allBibleData.bibleDatas)
        {
            var obj = Instantiate(slotPrefab);
            obj.GetComponent<DicSlot>().Init(bibleData);
            obj.transform.SetParent(container, false);
        }
    }

    //quiz db의 아이디 값으로, playerData 기반으로 푼 문제들을 체크
    private void AdjustPlayerData()
    {

    }
    private void Start()
    {
        InitPrefabs();
    }
}
