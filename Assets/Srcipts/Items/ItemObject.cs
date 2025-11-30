using System;
using UnityEngine;

[Serializable]
public class IOProperty
{
    public ItemData itemData;
    public int itemId;
}

public class ItemObject : MonoBehaviour
{
    public IOProperty IOProperty;
    private ItemData _itemProperty;
    [SerializeField] private int _itemID;

    public int ItemID { get => _itemID; set => _itemID = value; }
        
    void Start()
    {
        _itemProperty = ItemStockManager.Instance.GetItem(ItemID);
    }
}
