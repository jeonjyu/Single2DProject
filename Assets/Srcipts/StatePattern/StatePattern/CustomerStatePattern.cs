using System.Collections.Generic;
using UnityEngine;

public class CustomerStatePattern : MonoBehaviour
{
    [SerializeField] private Queue<GameObject> _waitingQueue;
    private ICharacterState _currentState;
    private bool _isCheckingout;
    private int _itemIdx;
    private Item _item;
    public bool IsChecking { get => _isCheckingout; set => _isCheckingout = value; }
    public int ItemIdx { get => _itemIdx; set => _itemIdx = value; }

    public ICharacterState _shoppingState;
    public ICharacterState _idleState;
    public ICharacterState _checkoutState;
    public ICharacterState _exitState;

    System.Random rd = new System.Random();


    private void Start()
    {
        _shoppingState = new ShoppingState(transform);
        _idleState = new CustomerIdleState(transform);
        _checkoutState = new CheckoutState(transform);
        _exitState = new ExitState(transform);

        Debug.Log($"[CustomerStatePattern] {gameObject}");
        SetShoppingList();
        SetState(_shoppingState);
        
        GetInLine();
    }

    public void SetState(ICharacterState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    public float delayTime = 7f;
    private float timer = 0f;

    void Update()
    {
        //timer += Time.deltaTime; // 프레임마다 시간을 더함
        //if (timer >= delayTime)
        //{
        //    //GetInLine();
        //}
    }

    public void SetShoppingList()
    {
        // 값이 안변함
        // 호출 위치가 잘못 된 듯
        _itemIdx = Random.Range(1, ItemStockManager.Instance.Count + 1);
        Debug.Log($"[CustomerStatePattern] {ItemStockManager.Instance.GetItem(_itemIdx)}");
    }

    public void MoveToTarget()
    {
        // _itemIdx로 정해진 대상의 오브젝트 위치를 연결해준다 (어떻게?)
        // 암튼 타겟이 정해지면 이동
    }

    public void GetInLine()
    {
        WaitingQueueManager.Instance.EnqueueCustomer(gameObject);
        SetState(_idleState);
        // 계산 끝날 때까지 기다리는 로직 추가
        // 기다리는 시간 추가(item Count에 초 곱해서 기다리기)
        _item = ItemStockManager.Instance.GetItem(_itemIdx);
        StoreBalanceManager.Instance.AddBalnce(_item.Price);
        Debug.Log("[CustomerStatePattern] 계산 끝");
        ExitStore();
    }


    public void ExitStore()
    {
        SetState(_exitState);
    }
}
