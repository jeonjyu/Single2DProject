using UnityEngine;
using System.Collections.Generic;

public class CheckoutState : ICustomerState
{
    private Transform _transform;
    private Animator _animator;

    public CheckoutState(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }

    public void Enter()
    {
        _animator.SetFloat("floatIdle", 1);
    }

    public void Exit()
    {
    }

    public void StateAction(CustomerStatePattern statePattern)
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
    }
}
