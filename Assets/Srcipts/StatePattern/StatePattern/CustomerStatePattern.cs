using System.Collections.Generic;
using UnityEngine;

public class CustomerStatePattern : MonoBehaviour
{
    [SerializeField] private Queue<GameObject> _waitingQueue;
    private ICharacterState _currentState;
    private bool _isCheckingout;

    public bool IsChecking { get => _isCheckingout; set => _isCheckingout = value; }

    public ICharacterState _shoppingState;
    public ICharacterState _idleState;
    public ICharacterState _checkoutState;
    public ICharacterState _exitState;

    private void Start()
    {
        _shoppingState = new ShoppingState(transform);
        _idleState = new CustomerIdleState(transform);
        _checkoutState = new CheckoutState(transform);
        _exitState = new ExitState(transform);

        Debug.Log($"[CustomerStatePattern] {gameObject}");
        SetState(_shoppingState);
        
        //GetInLine();
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
        timer += Time.deltaTime; // 프레임마다 시간을 더함
        if (timer >= delayTime)
        {
            GetInLine();
        }
    }

    public void GetInLine()
    {
        WaitingQueueManager.Instance.EnqueueCustomer(gameObject);
        //Debug.Log("[CustomerStatePattern] 대기");
        SetState(_idleState);
        // 계산 끝날 때까지 기다리는 로직 추가
        // 점원이 왜 동작을 안하지
        ExitStore();
    }



    public void ExitStore()
    {
        SetState(_exitState);
    }
}
