using System.Collections.Generic;
using UnityEngine;


// Staff 상태 변화, 상태에 따른 로직 총괄
public class StaffStatePattern : MonoBehaviour
{
    [SerializeField] private Queue<GameObject> _waitingQueue;
    private ICharacterState _currentState;
    private bool _isCheckingout;
    private int _repeatCount;

    public bool IsChecking { get => _isCheckingout; set => _isCheckingout = value; }
    public int RepeatCount { get => _repeatCount; set => _repeatCount = value; }
    public Queue<GameObject> WaitingQueue { get => _waitingQueue; set => _waitingQueue = value; }

    public ICharacterState _idleState;
    public ICharacterState _checkoutState;

    private void Start()
    {
        _idleState = new IdleState(transform, WaitingQueue);
        _checkoutState = new CheckoutState(transform, WaitingQueue);


        SetState(_idleState);
    }

    public void SetState(ICharacterState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    private void Update()
    {
    }

    // 대기열 확인
    // 대기 인원이 있으면 계산 상태로 전환
    public void CheckWaitingQueue()
    {
        if (WaitingQueue.Count != 0)
            SetState(_checkoutState);
    }

    // 고객 계산하기
    public void Payment()
    {

    }

}
