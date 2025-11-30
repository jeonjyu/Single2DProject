using System.Collections;
using UnityEngine;

public class CustomerPool : MonoBehaviour
{
    [SerializeField] private Customer customerprefab;
    [SerializeField] private int size = 12;

    private ObjectPoolManager<Customer> customerPool;

    void Awake()
    {
        customerPool = new ObjectPoolManager<Customer>(customerprefab, size);
    }

    void Start()
    {
        InvokeRepeating("SpawnCustomer", 0f, 5f);
        //StartCoroutine(SpawnCoroutine());
    }

    public void SpawnCustomer()
    {
        Customer customer = Object.Instantiate(customerprefab);

        //Customer customer = customerPool.GetObject();
        Debug.Log($"[CustomerPool] À§Ä¡ {transform.position}");
        customer.transform.position = transform.position;
        Destroy(customer.transform, 5f);
    }

    public void DespawnCustomer(Customer customer)
    {
        customerPool.ReturnObject(customer);
        //Destroy(cus);
    }

    IEnumerator SpawnCoroutine()
    {
        SpawnCustomer();
        yield return new WaitForSeconds(5f);
    }
}
