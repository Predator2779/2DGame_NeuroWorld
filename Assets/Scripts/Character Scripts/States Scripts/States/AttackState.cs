using GlobalVariables;
using UnityEngine;

[CreateAssetMenu(fileName = "New AttackState",
    menuName = "Scriptable Objects/Character States/Attack State", order = 1)]
public class AttackState : WarriorState
{
    private Character _target;
    private Warrior _warrior;
    private WarriorAI _warriorAI;

    public override void EnterState(Character character)
    {
        _warrior = character.GetComponent<Warrior>();
        _warriorAI = character.GetComponent<WarriorAI>();

        //_character.OnCollisionEntered += StepAside;
    }

    public override void SetTarget(Character target)
    {
        _target = target;
    }

    public override void LogicUpdate()
    {
        AttackTarget();
    }

    protected override void CheckExecutionCondition()
    {
        if (_target == null)
        {
            StartPatrolState();
        }
        else if (!IsAttackRange())
        {
            StartChaseState(_target);
        }
    }

    private void AttackTarget()
    {
        _warrior.Attack();
    }

    private void StartChaseState(Character target)
    {
        _warriorAI.SetState(_warriorAI.Chase, target);
    }

    private void StartPatrolState()
    {
        _warriorAI.SetState(_warriorAI.Patrol);
    }

    private bool IsAttackRange()
    {
        return GlobalConstants.IsAttackRange(_warrior.transform, _target.transform);
    }
}