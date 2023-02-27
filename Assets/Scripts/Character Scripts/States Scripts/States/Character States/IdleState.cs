using GlobalVariables;
using UnityEngine;

public class IdleState : CharacterState
{
    private float _lifeTime;

    public IdleState(Character character, StateChanger stateChanger)
        : base(character, stateChanger) { }

    public override void EnterState()
    {
        _lifeTime = RandomStateTime();
    }

    public override void LogicUpdate()
    {
        Debug.Log("Invoked.LogicUpdate()");//
        CheckExecutionCondition();
    }

    public override void PhysicsUpdate()
    {
        Debug.Log("Invoked.PhysicsUpdate()");//
        Debug.Log("LifeTime: " + _lifeTime);//
        DecreaseLifeTime();
    }

    public override void CheckExecutionCondition()
    {
        if (_lifeTime <= 0)
        {
            Debug.Log("LifeTime <= 0; CheckExecuteCondition()");//
            StartPatrolState();
        }
    }

    public void StartPatrolState()
    {
        _stateChanger.SetState(new PatrolState(_character, _stateChanger));
    }

    private void DecreaseLifeTime()
    {
        _lifeTime -= Time.deltaTime;
    }

    private float RandomStateTime()
    {
        var minStateTime = GlobalConstants.MinStateTime;
        var maxStateTime = GlobalConstants.MaxStateTime;

        return Random.Range(minStateTime, maxStateTime);
    }

    public override void ExitState()
    {
        Debug.Log("Invoked.ExitState()");//
    }
}