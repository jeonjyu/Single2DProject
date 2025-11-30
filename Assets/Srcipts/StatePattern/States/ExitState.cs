using UnityEngine;

public class ExitState : ICustomerState
{
    public ICustomerState StateAction(CustomerStatePattern csp)
    {
        // 출구로 목적지 설정
        //if(csp.isCheckedout && csp.targetObject != csp.exit)
        //{
        //    SetExitDest(csp);
        //    return csp.movingState;
        //}
        // 이동

        if(csp.isShopped && csp.targetObject != csp.exit)
        {
            SetExitDest(csp);
            return csp.movingState;
        }

        // 오브젝트 비활성화
        if (csp.transform.position == csp.exit.transform.position && csp.targetObject == csp.exit)
        {
            // 오브젝트 비활성화
            Debug.Log("[ExitState] 퇴장");
            csp.transform.gameObject.SetActive(false);
            return csp.waitingState;
        }
        return csp.exitState;
    }

    private void SetExitDest(CustomerStatePattern inCsp)
    {
        Debug.Log("[ExitState] 퇴장하러 가자");

        inCsp.isArrived = false;
        inCsp.targetObject = inCsp.exit;
    }

}
