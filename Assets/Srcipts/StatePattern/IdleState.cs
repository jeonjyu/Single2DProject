using System.Collections.Generic;
using UnityEngine;

public class IdleState : ICharacterState
{
    private Transform _transform;
    private Animator _animator;
    private Queue<GameObject> _waitingQueue;

    public IdleState(Transform transform, Queue<GameObject> waitingQueue)
    {
        _transform = transform;
        _waitingQueue = waitingQueue;
        _animator = transform.GetComponent<Animator>();
    }

    public void Enter()
    {
        _animator.SetFloat("floatIdle", 0);
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
