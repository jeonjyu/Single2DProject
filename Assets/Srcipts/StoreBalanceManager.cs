using UnityEngine;

public class StoreBalanceManager : Singleton<StoreBalanceManager>
{
    private int _balance;

    public int Balance { get => _balance; set => _balance = value; }

    protected override void Awake()
    {
        _balance += 5000;
        //Debug.Log($"[StoreBalanceManager | Awake] Balance : {_balance}");
    }

    public void AddBalnce(int addAmount)
    {
        _balance += addAmount;
        Debug.Log($"[StoreBalanceManager] Balance : {_balance}");
    }

    public void SubBalance(int subAmount)
    {
        _balance -= subAmount;
        Debug.Log($"[StoreBalanceManager] Balance : {_balance}");
    }
}
