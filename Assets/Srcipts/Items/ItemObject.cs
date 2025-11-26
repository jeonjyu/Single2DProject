using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private ItemData _itemProperty;
    [SerializeField] private int _itemID;

    public int ItemID { get => _itemID; set => _itemID = value; }
        
    void Start()
    {
        Debug.Log("[ItemObject | Start] ");
        _itemProperty = ItemStockManager.Instance.GetItem(ItemID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetItemPos()
    {
        Debug.Log("[ItemObject] 아이템 위치 리턴");
        return gameObject.transform.position;
    }
}
