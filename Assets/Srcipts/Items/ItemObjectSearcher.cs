using System;
using UnityEngine;

public class ItemObjectSearcher : MonoBehaviour
{
    public ItemObject[] itemObjects;
        
    void Start()
    {
        itemObjects = GetComponentsInChildren<ItemObject>();
        SortObjArr();
        //Debug.Log("========");
        //foreach (var obj in itemObjects)
            //Debug.Log($"[ItemObjectSearcher] {obj} {obj.ItemID}");
        //Debug.Log("========");
        Debug.Log($"[ItemObjectSearcher | Start]");
    }

    // 받아온 오브젝트들을 딕셔너리에 등록된 id 순으로 정렬
    private ItemObject[] SortObjArr()
    {
        Array.Sort(itemObjects, (a, b) =>
        {
            if (a.ItemID < b.ItemID) return -1;
            else return 1;
        });
        return itemObjects;
    }
}
