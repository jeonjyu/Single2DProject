using System.Collections.Generic;
using UnityEngine;

public class StaffIdleState : IStaffState
{
    public IStaffState StateAction(StaffStatePattern ssp)
    {
        if (WaitingQueueManager.Instance.Count > 0)
        {
            ssp.isIdle = false;
            return ssp.checkoutState;
        }

        return ssp.idleState;
    }



    //private Transform _transform;
    //private Animator _animator;
    //private Queue<GameObject> _waitingQueue;

    //public StaffIdleState(Transform transform)
    //{
    //    _transform = transform;
    //    //_waitingQueue = waitingQueue;
    //    _animator = transform.GetComponent<Animator>();
    //}

    //public void Enter()
    //{
    //    Debug.Log($"[{_transform.gameObject.name}] ´ë±â");
    //    _animator.SetFloat("floatIdle", 0);
    //}

    //public void Update()
    //{
    //}
}
