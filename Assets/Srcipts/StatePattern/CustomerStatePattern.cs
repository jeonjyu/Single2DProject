using System.Collections.Generic;
using UnityEngine;

public class CustomerStatePattern : MonoBehaviour
{
    [SerializeField] private Queue<GameObject> _waitingQueue;
    private ICharacterState _currentState;
    private bool _isCheckingout;

    public bool IsChecking { get => _isCheckingout; set => _isCheckingout = value; }
    public Queue<GameObject> WaitingQueue { get => _waitingQueue; set => _waitingQueue = value; }

    public ICharacterState _shoppingState;
    public ICharacterState _idleState;
    public ICharacterState _checkoutState;
    public ICharacterState _exitState;

    private void Start()
    {
        
    }

    public void SetState(ICharacterState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
}
