using UnityEngine;

[CreateAssetMenu(fileName = "Idle", 
    menuName = "Scriptable Objects/States/Character States/Idle State", order = 1)]
public class IdleState : CharacterState
{
    /// Добавить rotation по таймингу сюда и в патрол.

    public float LifeTime;

    private float _lifeTime;
    private StateMachine _stateMachine;

    public override void EnterState(Character character)
    {
        _stateMachine = character.GetComponent<StateMachine>();
        _lifeTime = LifeTime;
    }

    public override void LogicUpdate()
    {
        CheckExecutionCondition();
    }

    public override void PhysicsUpdate()
    {
        DecreaseLifeTime();
    }

    protected override void CheckExecutionCondition()
    {
        if (_lifeTime <= 0)
        {
            StartPatrolState();
        }
    }

    private void StartPatrolState()
    {
        _stateMachine.SetState(_stateMachine.Patrol);
    }

    private void DecreaseLifeTime()
    {
        _lifeTime -= Time.deltaTime;
    }
}