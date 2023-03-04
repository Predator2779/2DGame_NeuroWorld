using GlobalVariables;
using UnityEngine;

public class IdleState : CharacterState
{
    /// Добавить rotation по таймингу сюда и в патрол.
    private float _lifeTime;

    public IdleState(Character character, StateMachine stateMachine)
        : base(character, stateMachine) { }

    public override void EnterState()
    {
        _lifeTime = RandomStateTime();

        throw new System.Exception("The 'Character' object is missing the 'Warrior' component!");
    }

    public override void LogicUpdate()
    {
        CheckExecutionCondition();
    }

    public override void PhysicsUpdate()
    {
        DecreaseLifeTime();
    }

    public override void CheckExecutionCondition()
    {
        if (_lifeTime <= 0)
        {
            StartPatrolState();
        }
    }

    public void StartPatrolState()
    {
        _stateMachine.SetState(new PatrolState(_character, _stateMachine));
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
        _lifeTime = 0;
    }
}