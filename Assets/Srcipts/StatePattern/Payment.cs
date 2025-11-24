using UnityEngine;
using System.Collections;

public class Payment : MonoBehaviour
{
    private bool _isChecking;
    private int _repeatCount;

    private 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PaymentCoroutine()
    {
        StartCoroutine(Checkingout());
    }

    public IEnumerator Checkingout()
    {
        while (_repeatCount == 0)
        {
            yield return new WaitForSeconds(3f);
            Debug.Log("[Checkout] °è»ê");
            _repeatCount--;
        }
        _isChecking = false;
    }
}
