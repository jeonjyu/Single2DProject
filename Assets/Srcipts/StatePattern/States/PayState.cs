using UnityEngine;

public class PayState : ICustomerState
{

    public ICustomerState StateAction(CustomerStatePattern csp)
    {
        // °áÁ¦
        Checkout(csp);
        return csp.movingState;

        if (csp.isTurn && !csp.isCheckedout)
        {
            Checkout(csp);
        }

        if (!csp.isTurn && csp.isCheckedout)
        {
            OutWaitingQueue(csp);
            return csp.exitState;
        }

        return csp.payState;
    }

    private void Checkout(CustomerStatePattern inCsp)
    {
        StoreBalanceManager.Instance.AddBalnce(inCsp.targetData.Price);
        SatisfactionManager.Instance.AddSatisfaction(5);
        inCsp.isCheckedout = true;
        inCsp.isTurn = false;
    }

    private void OutWaitingQueue(CustomerStatePattern inCsp)
    {
        if (WaitingQueueManager.Instance.Count > 0) 
        {
            WaitingQueueManager.Instance.DequeueCustomer();
        }
        //inCsp.targetObject.
    }
}
