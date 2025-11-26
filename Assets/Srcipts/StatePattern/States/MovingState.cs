using UnityEngine;

public class MovingState : ICustomerState
{ 

    public ICustomerState StateAction(CustomerStatePattern cst)
    {
        // 목적지 설정
        SetDest(cst);

        // 경로 탐색 
        // 이동

        // 전환 스위치 (불리언 변수) 전환
        if (EvalutateArrival(cst)) return cst.movingState;

        if (!cst.isShopped) return cst.shoppingState;
        
        if (cst.isCheckedout) return cst.exitState;

        if (!cst.isTurn) return cst.waitingState;

        return cst.movingState;
    }

    // 목적지 설정
    private void SetDest(CustomerStatePattern inCst)
    {
        inCst.agent.SetDestination(inCst.nextPosition);
    }

    private bool EvalutateArrival(CustomerStatePattern inCst)
    {
        if (inCst.isArrived == false && inCst.agent.remainingDistance < 1f)
        {
            //Debug.Log("[MovingState] 도착");
            inCst.isArrived = true;
            return true;
        }
        return false;
    } 
}
