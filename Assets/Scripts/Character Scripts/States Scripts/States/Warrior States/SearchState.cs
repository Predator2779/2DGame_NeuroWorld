using UnityEngine;

[CreateAssetMenu(fileName = "Search",
    menuName = "Scriptable Objects/States/Warrior States/Search State", order = 1)]
public class SearchState : WarriorState
{
    public float LifeTime;

    private float _lifeTime;
    private Vector2 _lastTargetPosition;
    private Character _target;
    private Warrior _warrior;
    private WarriorAI _warriorAI;

    public override void SetTarget(Character target)
    {
        _target = target;
    }

    public override void TargetIsGone()
    {
        _target = null;

        StartPatrolState();
    }

    public void SetLastTargetPosition(Vector3 position)
    {
        _lastTargetPosition = position;
    }

    public override void EnterState(Character character)
    {
        _target = null;
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
            TargetIsGone();
        }
        else if (_target != null)
        {
            StartChaseState(_target);
        }
    }

    private void SearchTarget()
    {
        if ((Vector2)_warrior.transform.position != _lastTargetPosition)
        {
            _warrior.RotateTo(_lastTargetPosition);
            _warrior.MoveTo(TargetDirection());
        }
    }

    private void StartChaseState(Character target)
    {
        _warriorAI.SetState(_warriorAI.Chase);
        _warriorAI.SetTarget(target);
    }

    private void StartPatrolState()
    {
        _warriorAI.SetState(_warriorAI.Patrol);
    }

    private Vector2 TargetDirection()
    {
        Vector2 direction = _lastTargetPosition - (Vector2)_warrior.transform.position;

        return direction.normalized;
    }

    private void DecreaseLifeTime()
    {
        _lifeTime -= Time.deltaTime;
    }
}