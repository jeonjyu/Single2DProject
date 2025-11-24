using UnityEngine;

public class ExitState : ICharacterState
{
    private Transform _transform;
    private Animator _animator;

    public ExitState(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }

    public void Enter()
    {
        Debug.Log($"[ExitState] {_transform.gameObject.name} Επΐε");
        _animator.SetFloat("floatIdle", 1);
        //throw new System.NotImplementedException();
    }

    public void Exit()
    {
        //throw new System.NotImplementedException();
    }

    public void Update()
    {
        //throw new System.NotImplementedException();
    }
}
