using System.Collections.Generic;
using UnityEngine;

public class WaitingQueueManager : Singleton<WaitingQueueManager>
{
    [SerializeField] public static Queue<GameObject> waitingQueue;

    public int Count { get => waitingQueue.Count; }

    protected override void Awake()
    {
        waitingQueue = new Queue<GameObject>();
        //Debug.Log($"[WaitingQueueManager] 인스턴스 생성 {Instance}");
        //Debug.Log($"[WaitingQueueManager] 큐 생성 {waitingQueue}");
    }

    public void EnqueueCustomer(GameObject gameObject)
    {
        Debug.Log("[WaitingQueueManager] 큐에 추가");
        waitingQueue.Enqueue(gameObject);
    }

    public GameObject DequeueCustomer()
    {
        Debug.Log("[WaitingQueueManager] 큐에서 제거");
        return waitingQueue.Dequeue();
    }
}
