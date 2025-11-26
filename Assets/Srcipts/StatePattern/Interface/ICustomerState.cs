public interface ICustomerState
{
    void StateAction(CustomerStatePattern statePattern);
    void Enter();
    void Exit();
    void Update();
}
