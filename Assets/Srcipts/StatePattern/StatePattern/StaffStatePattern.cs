using UnityEngine;


// Staff 상태 변화, 상태에 따른 로직 총괄
public class StaffStatePattern : MonoBehaviour
{
    private ICharacterState _currentState;
    private bool _isCheckingout;
    private int _repeatCount = 5;

    public bool IsChecking { get => _isCheckingout; set => _isCheckingout = value; }
    public int RepeatCount { get => _repeatCount; set => _repeatCount = value; }

    public ICharacterState _idleState;
    public ICharacterState _checkoutState;

    private void Awake()
    {
        //WaitingQueueManager.WaitingQueue = new Queue<GameObject>();
    }
    private void Start()
    {
        _idleState = new StaffIdleState(transform);
        _checkoutState = new CheckoutState(transform);
        _isCheckingout = false;
        //Debug.Log("[StaffStatePattern] 대기");
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
        if(!_isCheckingout)
            CheckWaitingQueue();
    }

    // 대기열 확인
    // 대기 인원이 있으면 계산 상태로 전환
    public void CheckWaitingQueue()
    {
        if (WaitingQueueManager.Instance.Count != 0)
        {
            Debug.Log("[StaffStatePattern] 대기자 등장");

            Payment(WaitingQueueManager.Instance.DequeueCustomer());
        }
    }

    // 고객 계산하기
    // 고객 받아서 repeatCount만큼 계산 반복
    public void Payment(GameObject customer)
    {
        SetState(_checkoutState);
        _isCheckingout = true;

        for (int i = 0; i < _repeatCount; i++)
        {
            Debug.Log("[StaffStatePattern] 계산");
        }
        Debug.Log("[StaffStatePattern] 정산");
        SetState(_idleState);
    }

}
