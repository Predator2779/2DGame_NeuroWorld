using UnityEngine;

[CreateAssetMenu(fileName = "New SearchState",
    menuName = "Scriptable Objects/Character States/Search State", order = 1)]
public class SearchState : WarriorState
{
    public float LifeTime;

    private float _lifeTime;
    private Vector3 _lastTargetPosition;
    private Character _target;
    private Warrior _warrior;
    private WarriorAI _warriorAI;

    public override void SetTarget(Character target)
    {
        _target = target;
    }

    public void SetLastTargetPosition(Vector3 position)
    {
        _lastTargetPosition = position;
    }

    public override void EnterState(Character character)
    {
        _warrior = character.GetComponent<Warrior>();
        _warriorAI = character.GetComponent<WarriorAI>();
        _lifeTime = LifeTime;
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

    protected override void CheckExecutionCondition()
    {
        if (_lifeTime <= 0)
        {
            StartPatrolState();
        }
        else if (_target != null)
        {
            StartChaseState(_target);
        }
    }

    private void SearchTarget()
    {
        _warrior.MoveTo(_lastTargetPosition);
    }

    private void StartChaseState(Character target)
    {
        _warriorAI.SetState(_warriorAI.Chase, target);
    }

    private void StartPatrolState()
    {
        _warriorAI.SetState(_warriorAI.Patrol);
    }

    private void DecreaseLifeTime()
    {
        _lifeTime -= Time.deltaTime;
    }
}