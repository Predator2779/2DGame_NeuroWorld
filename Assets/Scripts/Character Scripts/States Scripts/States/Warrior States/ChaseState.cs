using GlobalVariables;
using UnityEngine;

[CreateAssetMenu(fileName = "Chase",
    menuName = "Scriptable Objects/States/Warrior States/Chase State", order = 1)]
public class ChaseState : WarriorState
{
    public Character _target;
    private Vector2 _lastTargetPosition;

    private Warrior _warrior;
    private WarriorAI _warriorAI;

    public override void EnterState(Character character)
    {
        _target = null;
        _warrior = character.GetComponent<Warrior>();
        _warriorAI = character.GetComponent<WarriorAI>();
    }

    public override void SetTarget(Character target)
    {
        _target = target;
    }

    public override void TargetIsGone()
    {
        _target = null;

        StartSearchState();
    }

    public override void LogicUpdate()
    {
        RecordLastTargetPosition();

        CheckExecutionCondition();
    }

    public override void PhysicsUpdate()
    {
        ChaseTarget();
    }

    protected override void CheckExecutionCondition()
    {
        if (_target != null)
        {
            if (IsAttackRange())
            {
                StartAttackState(_target);
            }

            RecordLastTargetPosition();
        }
        else
        {
            TargetIsGone();
        }
    }

    private void ChaseTarget()
    {
        _warrior.RotateTo(_lastTargetPosition);
        _warrior.MoveTo(TargetDirection());
    }

    private bool IsAttackRange()
    {
        return GlobalConstants.IsAttackRange(_warrior.transform, _target.transform);
    }

    private void StartAttackState(Character target)
    {
        _warriorAI.SetState(_warriorAI.Attack);
        _warriorAI.SetTarget(target);
    }

    private void StartSearchState()
    {
        _warriorAI.SetState(_warriorAI.Search);

        if (_warriorAI.Search is SearchState searchState)
        {
            searchState.SetLastTargetPosition(_lastTargetPosition);
        }
    }

    private void RecordLastTargetPosition()
    {
        if (_target != null)
        {
            _lastTargetPosition = _target.transform.position;
        }
    }

    private Vector2 TargetDirection()
    {
        Vector2 direction = _lastTargetPosition - (Vector2)_warrior.transform.position;

        return direction.normalized;
    }
}