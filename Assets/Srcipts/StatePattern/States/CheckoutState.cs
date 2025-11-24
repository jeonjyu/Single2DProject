using UnityEngine;
using System.Collections.Generic;

public class CheckoutState : ICharacterState
{
    private Transform _transform;
    private Animator _animator;
    //private Queue<GameObject> _waitingQueue;

    public CheckoutState(Transform transform)
    {
        _transform = transform;
        //_waitingQueue = waitingQueue;
        _animator = transform.GetComponent<Animator>();
    }

    public void Enter()
    {
        _animator.SetFloat("floatIdle", 1);
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
