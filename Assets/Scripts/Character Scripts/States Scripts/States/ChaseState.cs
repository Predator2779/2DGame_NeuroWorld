using GlobalVariables;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New ChaseState",
    menuName = "Scriptable Objects/Character States/Chase State", order = 1)]
public class ChaseState : WarriorState
{
    public Character Target { get; private set; }
    private Vector3 _lastTargetPosition;

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
        Target = target;
    }

    public override void LogicUpdate()
    {
        CheckExecutionCondition();
    }

    public override void PhysicsUpdate()
    {
        ChaseTarget();

        RecordLastTargetPosition();
    }

    protected override void CheckExecutionCondition()
    {
        if (IsAttackRange())
        {
            StartAttackState(Target);
        }

        if (Target == null)
        {
            StartSearchState();
        }
    }

    private void ChaseTarget()
    {
        _warrior.MoveTo(MovementDirection());
    }

    private bool IsAttackRange()
    {
        return GlobalConstants.IsAttackRange(_warrior.transform, Target.transform);
    }

    private void StartAttackState(Character target)
    {
        _warriorAI.SetState(_warriorAI.Chase, target);

        ExitState();
    }

    private void StartSearchState()
    {
        _warriorAI.SetState(_warriorAI.Search);
        _warriorAI.Search.GetComponent<SearchState>().SetLastTargetPosition(_lastTargetPosition);

        ExitState();
    }

    private void RecordLastTargetPosition()
    {
        if (Target != null)
        {
            _lastTargetPosition = Target.transform.position;
        }
    }

    private Vector3 MovementDirection()
    {
        return Target.transform.position;
    }

    //private void RotateCharacter(float angle)
    //{
    //    _character.RotateByAngle(angle);
    //}

    //private void StepAside(Collision2D collision)
    //{
    //    if (collision.gameObject.tag != "Player")//
    //    {
    //        var angle = _character.transform.rotation.eulerAngles.z + RandomAngle(90.0f, 270.0f);

    //        RotateCharacter(angle);
    //    }
    //}

    //private float RandomAngle(float minAngle, float maxAngle)
    //{
    //    return Random.Range(minAngle, maxAngle);
    //}

    protected override void ExitState()
    {
        //_character.OnCollisionEntered -= StepAside;
    }
}