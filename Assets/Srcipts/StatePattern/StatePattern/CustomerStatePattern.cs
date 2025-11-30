using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CustomerStatePattern : MonoBehaviour
{
    [SerializeField]
    private ICustomerState currentState;

    public Customer customer;
    public NavMeshAgent agent;

    public ItemData targetData;
    public int targetItemId;
    public GameObject targetObject;
    public Vector3 nextPosition;

    public GameObject exit;
    public GameObject counterObj;

    public bool isArrived = false;
    public bool isShopped = false;
    public bool isWaiting = false;
    public bool isTurn = false;
    public bool isCheckedout = false;
    public bool isPaid = false;

    public ICustomerState movingState;
    public ICustomerState shoppingState;
    public ICustomerState waitingState;
    public ICustomerState payState;
    public ICustomerState exitState;

    public ICustomerState CurrentState { get => currentState; }

    private void Awake()
    {
        //Debug.Log($"[CustomerStatePattern | Awake]");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        customer = gameObject.GetComponent<Customer>();

        movingState = new MovingState();
        shoppingState = new ShoppingState();
        waitingState = new WaitingState();
        payState = new PayState();
        exitState = new ExitState();
    }

    private void OnEnable()
    {
        //Debug.Log($"[CustomerStatePattern | OnEnable]");
        currentState = movingState;
    }
    void Update()
    {
        currentState = CurrentState.StateAction(this);
    }

}
