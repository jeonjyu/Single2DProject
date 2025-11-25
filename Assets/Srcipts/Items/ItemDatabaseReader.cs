using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item 
{
    //private int _id;
    private string _name;
    private int _price;
    private int _count;

    //public int Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }
    public int Price { get => _price; set => _price = value; }
    public int Count { get => _count; set => _count = value; }
}

public class ItemDatabaseReader : MonoBehaviour
{
    [SerializeField] private TextAsset _textAsset;
    //[SerializeField] private List<Item> itemList = new List<Item>();

    private Dictionary<int, Item> itemDict = new Dictionary<int, Item>();

    //public List<Item> ItemList { get => itemList; set => itemList = value; }
    public Dictionary<int, Item> ItemDict { get => itemDict; set => itemDict = value; }

    void Start()
    {
        ReadCsv();
    }

    public Dictionary<int, Item> ReadCsv()
    {
        string[] lineData = _textAsset.text.Split("\n");

        for (int i = 1; i < lineData.Length - 1; i++)
        {
            string[] splitData = lineData[i].Split(',');

            Item item = new Item();
            //item.Id = int.Parse(splitData[0]);
            item.Name = splitData[1];
            item.Price = int.Parse(splitData[2]);
            item.Count = int.Parse(splitData[3]);

            Debug.Log(item.Name);
            //ItemList.Add(item);

            itemDict.Add(int.Parse(splitData[0]), item);
        }
        //return itemList;
        return itemDict;
    }
}
