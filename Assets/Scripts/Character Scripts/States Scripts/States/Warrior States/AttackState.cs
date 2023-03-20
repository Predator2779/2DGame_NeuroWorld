using GlobalVariables;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack",
    menuName = "Scriptable Objects/States/Warrior States/Attack State", order = 1)]
public class AttackState : WarriorState
{
    private Character _target;
    private Vector2 _lastTargetPosition;
    private Warrior _warrior;
    private WarriorAI _warriorAI;

    public override void EnterState(Character character)
    {
        _warrior = character.GetComponent<Warrior>();
        _warriorAI = character.GetComponent<WarriorAI>();
    }

    public override void SetTarget(Character target)
    {
        _target = target;
    }

    public override void TargetIsGone()
    {
        StartSearchState();
    }

    public override void LogicUpdate()
    {
        AttackTarget();

        CheckExecutionCondition();
    }

    protected override void CheckExecutionCondition()
    {
        if (_target != null)
        {
            if (!IsAttackRange())
            {
                StartChaseState(_target);
            }

            RecordLastTargetPosition();
        }
        else
        {
            TargetIsGone();
        }
    }

    private void AttackTarget()
    {
        _warrior.Attack();
    }

    private void StartChaseState(Character target)
    {
        _warriorAI.SetState(_warriorAI.Chase);
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

    private bool IsAttackRange()
    {
        return GlobalConstants.IsAttackRange(_warrior.transform, _target.transform);
    }

    private void RecordLastTargetPosition()
    {
        _lastTargetPosition = _target.transform.position;
    }
}