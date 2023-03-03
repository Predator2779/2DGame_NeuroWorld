using GlobalVariables;
using UnityEngine;

public class SearchState : CharacterState
{
    private Character _target;
    private Vector3 _lastTargetPosition;
    private float _lifeTime;

    public SearchState(Character character, StateMachine stateMachine, Vector3 lastTargetPosition) : base(character, stateMachine)
    {
        _lastTargetPosition = lastTargetPosition;
    }

    public override void EnterState()
    {
        _lifeTime = RandomStateTime();
    }

    public override void LogicUpdate()
    {
        CheckExecutionCondition();
    }

    public override void PhysicsUpdate()
    {
        SearchTarget();

        DecreaseLifeTime();
    }

    public override void CheckExecutionCondition()
    {
        if (_lifeTime <= 0)
        {
            StartPatrolState();
        }
        else if (_target != null)
        {
            StartChaseState();
        }
    }

    private void SearchTarget()
    {
        _character.MoveTo(_lastTargetPosition);
    }

    private void StartChaseState()
    {
        _stateMachine.SetState(new ChaseState(_character, _stateMachine, _target));
    }

    private void StartPatrolState()
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