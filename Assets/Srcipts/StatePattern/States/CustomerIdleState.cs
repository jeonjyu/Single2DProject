using System.Collections.Generic;
using UnityEngine;

public class CustomerIdleState : ICharacterState
{
    private Transform _transform;
    private Animator _animator;
    private Queue<GameObject> _waitingQueue;

    public CustomerIdleState(Transform transform)
    {
        _transform = transform;
        //_waitingQueue = waitingQueue;
        _animator = transform.GetComponent<Animator>();
    }

    public void Enter()
    {
        Debug.Log($"[{_transform.gameObject.name}] 대기");
        _animator.SetFloat("floatIdle", 0);
    }

    public void Exit()
    {
    }


    //public float delayTime = 7f;
    //private float timer = 0f;
    
    public void Update()
    {
        //timer += Time.deltaTime; // 프레임마다 시간을 더함
        //if (timer >= delayTime)
        //{
        //    Exit();
        //}
    }
}
