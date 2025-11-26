using System.Collections.Generic;
using UnityEngine;

public class CustomerStatePattern : MonoBehaviour
{
    [SerializeField] private Queue<GameObject> _waitingQueue;
    [SerializeField] private Customer customer;
    [SerializeField] private GameObject _counterObj;
    //[SerializeField] private ItemObject _itemObj;
    //public ItemObject[] itemArr;
    private ICustomerState _currentState;
    private bool _isShopping;
    private bool _isCheckingout;
    private int _itemIdx;
    private ItemData _itemPropertyValue;

    private Vector2 _counterPos;

    public bool IsChecking { get => _isCheckingout; set => _isCheckingout = value; }
    public int ItemIdx { get => _itemIdx; set => _itemIdx = value; }
    public ItemData ItemValue { get => _itemPropertyValue; set => _itemPropertyValue = value; }
    //public ItemObject ItemObj { get => _itemObj; set => _itemObj = value; }

    public ICustomerState _shoppingState;
    public ICustomerState _waitingState;
    public ICustomerState _checkoutState;
    public ICustomerState _exitState;


    private void Awake()
    {
        customer = gameObject.GetComponent<Customer>();
        //_itemObj = gameObject.GetComponent<ItemObject>();
        Debug.Log($"[CustomerStatePattern | Awake]");

        _shoppingState = new ShoppingState(transform);
        _waitingState = new WaitingState(transform);
        _checkoutState = new CheckoutState(transform);
        _exitState = new ExitState(transform);
    }

    private void Start()
    {
        _counterPos = _counterObj.transform.position;
        Debug.Log($"[CustomerStatePattern | Start]");
        Debug.Log($"[CustomerStatePattern] {gameObject}");
        //itemArr = GetComponent<ItemObjectSearcher>().itemObjects;
        //SetState(_shoppingState);
        //SetShoppingList();
        
        //GetInLine();
    }

    private void OnEnable()
    {
        Debug.Log($"[CustomerStatePattern | OnEnable]");
        SetState(_shoppingState);
        _isShopping = true;
        SetShoppingList();
    }

    public void SetState(ICustomerState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }


    public void ChangeState()
    {

    }

    void Update()
    {
        //timer += Time.deltaTime; // 프레임마다 시간을 더함
        //if (timer >= delayTime)
        //{
        //    //GetInLine();
        //}
        if (_isShopping && customer.IsArrived())
        {
            TakeItem();
            _isShopping = false;
            customer.SetDest(_counterPos);
        } else if (!_isShopping && customer.IsArrived())
        {
            GetInLine();
        }
    }

    public void SetShoppingList()
    {
        _itemIdx = Random.Range(1, ItemStockManager.Instance.Count);
        Debug.Log($"[CustomerStatePattern] {_itemIdx} / {ItemStockManager.Instance.Count}");
        _itemPropertyValue = ItemStockManager.Instance.GetItem(_itemIdx);
        SetTarget();
    }

    public void SetTarget()
    {
        GameObject target = ItemStockManager.Instance.GetItemObject(_itemIdx);
        Debug.Log($"[CustomerStatePattern] 타겟 위치 {target.transform.position}");
        customer.SetDest(target.transform.position);
        
        //_itemObj = 
        //Vector2 itemPos = _itemObj.GetItemPos(_itemIdx);

        //customer.SetDest(_itemObj.GetItemPos(_itemIdx));
        // _itemIdx로 정해진 대상의 오브젝트 위치를 연결해준다 (어떻게?)
        // 암튼 타겟이 정해지면 이동
        //if (customer.IsArrived())
        //{
        //    _isShopping = false;
        //    customer.SetDest(_counterPos);
        //}

    }

    public void TakeItem()
    {
        ItemStockManager.Instance.SubCount(_itemIdx);
    }
    public void GetInLine()
    {
        Debug.Log("[CustomerStatePattern] 계산대 도착");
        WaitingQueueManager.Instance.EnqueueCustomer(gameObject);
        SetState(_waitingState);
        // 계산 끝날 때까지 기다리는 로직 추가
        // 기다리는 시간 추가(item Count에 초 곱해서 기다리기)
        _itemPropertyValue = ItemStockManager.Instance.GetItem(_itemIdx);
        StoreBalanceManager.Instance.AddBalnce(_itemPropertyValue.Price);
        Debug.Log("[CustomerStatePattern] 계산 끝");
        ExitStore();
    }


    public void ExitStore()
    {
        SetState(_exitState);
    }
}
