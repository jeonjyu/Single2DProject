using UnityEngine;

public class StoreBalanceManager : Singleton<StoreBalanceManager>
{
    private int _balance;

    public int Balance { get => _balance; set => _balance = value; }

    protected override void Awake()
    {
        _balance += 5000;
        Debug.Log(_balance);
    }

    public void AddBalnce(int addAmount)
    {
        _balance += addAmount;
    }

    public void SubBalance(int subAmount)
    {
        _balance -= subAmount;
    }
}
