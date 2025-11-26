using System;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingState : ICustomerState
{
    private Transform _transform;
    private Animator _animator;
    private int _itemCount;


    public ShoppingState(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }

    public float delayTime = 7f;
    private float timer = 0f;

    public void Enter()
    {
        // 쇼핑 목록 생성

        Debug.Log("[ShoppingState] 쇼핑 시작");
        // 애니메이션 방향 변경 필요
        //_animator.SetFloat("floatIdle", 1);
    }

    public void Exit()
    {
        Debug.Log("[ShoppingState] 쇼핑 끝");
    }


    public void Update()
    {
        //timer += Time.deltaTime; // 프레임마다 시간을 더함
        //if (timer >= delayTime)
        //{
        //    Exit();
        //}

        // transform의 직진 방향으로 애니메이션 방향 전환

        // 
    }

    public void StateAction(CustomerStatePattern statePattern)
    {
        throw new NotImplementedException();
    }
}
