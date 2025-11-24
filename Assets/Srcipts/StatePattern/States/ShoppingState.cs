using System.Collections.Generic;
using UnityEngine;

public class ShoppingState : ICharacterState
{
    private Transform _transform;
    private Animator _animator;

    public ShoppingState(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }
    public void Enter()
    {
        // 쇼핑 목록 생성
        Debug.Log("[ShoppingState] 쇼핑 시작");
        _animator.SetFloat("floatIdle", 1);
        //throw new System.NotImplementedException();
    }

    public void Exit()
    {
        // 대기열에 Add
        Debug.Log("[ShoppingState] 쇼핑 끝");
        //throw new System.NotImplementedException();
    }

    public void Update()
    {
        //throw new System.NotImplementedException();
    }
}
