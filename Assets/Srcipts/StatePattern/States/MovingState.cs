using UnityEngine;

public class MovingState : ICustomerState
{ 

    public ICustomerState StateAction(CustomerStatePattern csp)
    {
        // 목적지 설정
        if (!csp.isArrived) 
        {
            //Debug.Log($"[MovingState] 목적지 설정 {csp.targetObject.name} | {csp.targetObject.transform.position} | {csp.nextPosition}");
            SetDest(csp);
        }
        // 경로 탐색 
        // 이동

        // 전환 스위치 (불리언 변수) 전환
        if (!EvaluateArrival(csp))
        {
            return csp.movingState;
        }
        if (EvaluateArrival(csp) && csp.targetObject == csp.exit)
        {
            Debug.Log($"[MovingState] 목적지 도착 {csp.targetObject}");
            if(!csp.isCheckedout)
                Checkout(csp);
            return csp.exitState;
        }

        if (csp.isCheckedout) return csp.exitState;

        if (!csp.isShopped) return csp.shoppingState;

        if (csp.isShopped)
        {
            Checkout(csp);
            return csp.exitState;
        }

        return csp.movingState;
    }

    // 목적지 설정
    private void SetDest(CustomerStatePattern inCsp)
    {
        inCsp.agent.SetDestination(inCsp.nextPosition);
        Debug.Log($"[MovingState] {inCsp.nextPosition}");

        inCsp.isArrived = false;
    }

    private bool EvaluateArrival(CustomerStatePattern inCsp)
    {
        if (inCsp.agent.velocity.sqrMagnitude < 0.1f && inCsp.agent.remainingDistance < 1f)
        {
            Debug.Log("[MovingState] 도착");
            inCsp.isArrived = true;
            inCsp.targetObject = null;
            return true;
        }
        return false;
    }
    private void Checkout(CustomerStatePattern inCsp)
    {
        StoreBalanceManager.Instance.AddBalnce(inCsp.targetData.Price);
        SatisfactionManager.Instance.AddSatisfaction(5);
        inCsp.isCheckedout = true;
        inCsp.isTurn = false;
    }
}
