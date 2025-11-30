using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemData 
{
    //private int _id;
    private string _name;
    private int _price;
    private int _count;
    private GameObject _itemGameObject;

    //public int Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }
    public int Price { get => _price; set => _price = value; }
    public int Count { get => _count; set => _count = value; }
    public GameObject Object { get => _itemGameObject; set => _itemGameObject = value; }
}

public class ItemDatabaseReader : MonoBehaviour
{
    [SerializeField] private TextAsset _textAsset;
    [SerializeField] private List<ItemData> _itemList;

    private Dictionary<int, ItemData> _itemDict = new Dictionary<int, ItemData>();

    [SerializeField] private SerializableDictionary<int, ItemData> _serialDict = new();
        
    public Dictionary<int, ItemData> ItemDict { get => _itemDict; set => _itemDict = value; }

    void Awake()
    {
        ReadCsv();
        _serialDict.OnAfterDeserialize();
        Debug.Log($"[ItemDatabaseReader | Awake] ");
    }

    public Dictionary<int, ItemData> ReadCsv()
    {
        string[] lineData = _textAsset.text.Split("\n");

        for (int i = 1; i < lineData.Length - 1; i++)
        {
            string[] splitData = lineData[i].Split(',');

            ItemData item = new ItemData();
            item.Name = splitData[1];
            item.Price = int.Parse(splitData[2]);
            item.Count = int.Parse(splitData[3]);


            _itemDict.Add(int.Parse(splitData[0]), item);
            //Debug.Log(itemDict.Count);
        }
        return _itemDict;
    }

    public ItemData GetItem(int index)
    {
        ItemData item;
        _itemDict.TryGetValue(index, out item);
        Debug.Log($"[ItemDatabaseReader] {item}");
        return item;
    }
}
