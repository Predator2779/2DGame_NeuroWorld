using GlobalVariables;

public class AttackState : CharacterState
{
    private Warrior _warrior;
    private Character _target;

    public AttackState(Character character, StateMachine stateMachine, Character target)
        : base(character, stateMachine)
    {
        _target = target;
    }

    public override void EnterState()
    {
        if (_character.TryGetComponent(out Warrior warrior))
        {
            _warrior = warrior;
        }
        else
        {
            StartChaseState();

            throw new System.Exception("The 'Character' object is missing the 'Warrior' component!");      
        }
    }

    public override void LogicUpdate()
    {
        AttackTarget();
    }

    public override void CheckExecutionCondition()
    {
        if (_target == null)
        {
            StartPatrolState();
        }
        else if (!IsAttackRange())
        {
            StartChaseState();
        }
    }

    private void AttackTarget()
    {
        _warrior.Attack();
    }

    private void StartChaseState()
    {
        _stateMachine.SetState(new ChaseState(_character, _stateMachine, _target));
    }

    private void StartPatrolState()
    {
        _stateMachine.SetState(new PatrolState(_character, _stateMachine));
    }

    private bool IsAttackRange()
    {
        return GlobalConstants.IsAttackRange(_character.transform, _target.transform);
    }

    public override void ExitState()
    {
        
    }
}