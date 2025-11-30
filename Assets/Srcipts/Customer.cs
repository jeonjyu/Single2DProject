using UnityEngine;

public class Customer : MonoBehaviour
{
    private void Start()
    {
        
        ItemStockManager.Instance.GetItemObject(6);
    }
}
