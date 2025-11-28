using UnityEngine;
using UnityEngine.UIElements;

public class ItemButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton()
    {
        for(int i = 0; i < ItemStockManager.Instance.Count; i++)
        {
            ItemStockManager.Instance.AddCount(i);
        }
        Debug.Log("[ItemButton] 아이템 재고 추가");
    }
}
