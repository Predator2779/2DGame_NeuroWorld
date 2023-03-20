using UnityEngine;

[CreateAssetMenu(fileName = "Patrol",
    menuName = "Scriptable Objects/States/Warrior States/Patrol State", order = 1)]
public class PatrolState : WarriorState
{
    public float LifeTime;

    private Character _target;
    private float _lifeTime;
    private Character _character;
    private StateMachine _stateMachine;

    public override void EnterState(Character character)
    {
        _character = character;
        _stateMachine = character.GetComponent<StateMachine>();
        _lifeTime = LifeTime;

        _character.RotateByAngle(_character.RandomAngle(0.0f, 360.0f));
    }

    public override void SetTarget(Character target)
    {
        _target = target;
    }

    public override void TargetIsGone()
    {
        _target = null;
    }

    public override void LogicUpdate()
    {
        CheckExecutionCondition();
    }

    public override void PhysicsUpdate()
    {
        DecreaseLifeTime();

        Patrol();
    }

    private void Patrol()
    {
        _character.MoveTo(_character.transform.up.normalized);
    }

    protected override void CheckExecutionCondition()
    {
        if (_lifeTime <= 0)
        {
            StartIdleState();
        }
        else if (_target != null)
        {
            StartChaseState(_target);
        }     
    }

    private void StartIdleState()
    {
        _stateMachine.SetState(_stateMachine.Idle);
    }

    private void StartChaseState(Character target)
    {
        if (_stateMachine.TryGetComponent(out WarriorAI warriorAI))
        {
            warriorAI.SetState(warriorAI.Chase);
            warriorAI.SetTarget(target);
        }
        else
        {
            StartIdleState();
        }
    }

    private void DecreaseLifeTime()
    {
        _lifeTime -= Time.deltaTime;
    }
}