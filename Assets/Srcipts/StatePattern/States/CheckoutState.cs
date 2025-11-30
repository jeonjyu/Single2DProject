using System;
using UnityEngine;

public class CheckoutState : IStaffState
{
    public IStaffState StateAction(StaffStatePattern ssp)
    {
        // 대기하고 있다가
        if (!ssp.isIdle)
        {
            // 상태 기준 토글
            EndCheckout(ssp);
            return ssp.idleState;
        }

        // 리턴
        return ssp.checkoutState;
    }

    private void EndCheckout(StaffStatePattern inSsp)
    {
        //inSsp.isCheckedout = true;
        inSsp.isIdle = false;
    }
}
