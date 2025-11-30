using UnityEngine; 
using System;
using System.Collections.Generic;

public class ShoppingState : ICustomerState
{
    // 각 상태에서 수행해야 할 메서드
    public ICustomerState StateAction(CustomerStatePattern csp)
    {
        // 타겟 선정
        if (csp.targetObject == null)
        {
            SetTargetItem(csp);
        }

        // 아이템 담기
        if (csp.isArrived)
        {
            // 타겟 담기
            TakeTargetItem(csp);
        }

        // 상태 전환
        if (csp.isShopped)
        {
            csp.nextPosition = csp.exit.transform.position;
            return csp.movingState;
        }

        return csp.shoppingState;
    }

    // 목표 아이템 선정 메서드
    public void SetTargetItem(CustomerStatePattern inCsp)
    {
        // 아이템 목록 중 랜덤 인덱스를 지정
        inCsp.targetItemId = UnityEngine.Random.Range(1, ItemStockManager.Instance.Count);
        Debug.Log($"[CustomerStatePattern] {inCsp.targetItemId} / {ItemStockManager.Instance.Count}");
        // 인덱스에 해당하는 아이템 오브젝트를 타겟으로 선정
        inCsp.targetObject = ItemStockManager.Instance.GetItemObject(inCsp.targetItemId);
        inCsp.nextPosition = inCsp.targetObject.transform.position;
        inCsp.targetData = ItemStockManager.Instance.GetItem(inCsp.targetItemId);
        Debug.Log($"[CustomerStatePattern] {inCsp.nextPosition}");
        inCsp.nextPosition = inCsp.targetObject.transform.position;

        //inCsp.targetData.

    }

    // 목표 아이템 가져온 것으로 처리하는 메서드
    public void TakeTargetItem(CustomerStatePattern inCsp)
    {
        // 타겟 아이템의 재고 감소 후 쇼핑 여부 전환
        ItemStockManager.Instance.SubCount(inCsp.targetItemId);
        inCsp.isShopped = true;
    }
}
