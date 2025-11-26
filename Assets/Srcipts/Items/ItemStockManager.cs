using System.Collections.Generic;
using UnityEngine;

public class ItemStockManager : Singleton<ItemStockManager> 
{
    [SerializeField] private ItemDatabaseReader _reader;
    [SerializeField] private ItemObjectSearcher _itemObjectSearcher;
    private Dictionary<int, ItemData> items;
    public ItemObject[] itemArr;


    private int _count;

    public int Count { get => _count; set => _count = value; }

    protected override void Awake()
    {
        _reader = gameObject.GetComponent<ItemDatabaseReader>();

        Debug.Log($"[ItemStockManager | Awake]  _itemObjectSearcher : {_itemObjectSearcher}");
        items = _reader.ItemDict;
        _count = items.Count;
        Debug.Log($"[ItemStockManager | Awake] 리스트 받아옴 {_count}");
    }

    private void Start()
    {
        itemArr = _itemObjectSearcher.itemObjects;
        Debug.Log($"[ItemStockManager | Start] 오브젝트 배열 정렬");

    }

    public ItemData GetItem(int id)
    {
        ItemData item;

        if (!items.TryGetValue(id, out item))
        {
            Debug.LogError("[ItemStockManager] 해당하는 품목이 없음");
        }
        //Debug.Log($"[ItemStockManager] {item.Name} ");
        //Debug.Log($"[ItemStockManager] {item.Name} ");

        return item;
    }
    public GameObject GetItemObject(int id)
    {
        Debug.Log($"[ItemStockManager] 타겟 : {id}");
        GameObject targetObject = itemArr[id - 1].gameObject;
        Debug.Log($"[ItemStockManager] 타겟 : {targetObject}");
        foreach(var key in items.Keys)
        {
            if (key == id)
                Debug.Log(key);
        }
        return targetObject;
    }

    public void AddCount(int id)
    {
        ItemData item;
        Debug.Log($"[ItemStockManager] arr id {id}   ");
        if (items.TryGetValue(id, out item))
        {
            item.Count += 5;
        }
        else
        {
            Debug.LogError($"[ItemStockManager] {id}에 해당하는 값이 존재하지 않음");
        }
    }

    public void SubCount(int id)
    {
        ItemData item;
        if (items.TryGetValue(id, out item))
        {
            if(item.Count <= 0)
            {
                // 재고 없음 만족도 하락 
                Debug.Log($"[ItemStockManager] {item.Name} 재고 없음");
                return;
            }
            item.Count -= 1;
        }
        else
        {
            Debug.LogError($"[ItemStockManager] {id}에 해당하는 값이 존재하지 않음");
        }
    }
}
