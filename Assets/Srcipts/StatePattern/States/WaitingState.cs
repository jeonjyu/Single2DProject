using System.Collections.Generic;
using UnityEngine;

public class WaitingState : ICustomerState
{
    public ICustomerState StateAction(CustomerStatePattern csp)
    {
        // 대기열에 추가
        if (!csp.isWaiting && csp.isArrived)
        {
            EnWaitingQueue(csp);
            return csp.waitingState;
        }

        // 갱신된 위치에 따라 이동하기

        // 순번 확인하기
        if (csp.isTurn)
        {
            Debug.Log($"[WaitingState] 순서가 돌아옴");
            csp.isWaiting = false;
            return csp.payState;
        }

        return csp.waitingState;
    }

    private void EnWaitingQueue(CustomerStatePattern inCsp)
    {
        WaitingQueueManager.Instance.EnqueueCustomer(inCsp.gameObject);
        inCsp.targetObject = inCsp.exit;
        inCsp.isWaiting = true;
        inCsp.isArrived = false;
    }
}
