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
        while (container.childCount > 0)
            Destroy(container.GetChild(0).gameObject);

        foreach(BibleData bibleData in allBibleData.bibleDatas)
        {
            var obj = Instantiate(slotPrefab);
            obj.GetComponent<DicSlot>().Init(bibleData);
            obj.transform.SetParent(container, false);
        }
    }
    private void Start()
    {
        InitPrefabs();
    }
}
