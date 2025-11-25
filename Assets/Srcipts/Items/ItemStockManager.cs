using System.Collections.Generic;
using UnityEngine;

public class ItemStockManager : Singleton<ItemStockManager> 
{
    //[SerializeField] private List<Item> items;
    private Dictionary<int, Item> items;

    private int _count;

    public int Count { get => _count; set => _count = value; }

    private void Start()
    {
        ItemDatabaseReader reader = gameObject.GetComponent<ItemDatabaseReader>();
        items = reader.ItemDict;
        Debug.Log("[ItemStockManager] 리스트 받아옴");
    }

    public Item GetItem(int id)
    {
        Item item;

        if (!items.TryGetValue(id, out item))
        {
            Debug.Log("[ItemStockManager] 해당하는 품목이 없음");
        }
        Debug.Log($"[ItemStockManager] {item}");

        return item;
    }

    public void AddCount(int id)
    {
        Item item;
        if (items.TryGetValue(id, out item))
        {
            item.Count += 5;
        }
        Debug.Log($"[ItemStockManager] {id}에 해당하는 값이 존재하지 않음");
    }

    public void SubCount(int id)
    {
        Item item;
        if (items.TryGetValue(id, out item))
        {
            if(item.Count > 0)
            {
                item.Count -= 1;
            }
            // 재고 없음 만족도 하락 
            Debug.Log($"[ItemStockManager] {item.Name} 재고 없음");

        }
        Debug.Log($"[ItemStockManager] {id}에 해당하는 값이 존재하지 않음");
    }

}
