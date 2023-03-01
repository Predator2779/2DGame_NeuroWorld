using GlobalVariables;
using UnityEngine;

public class ChaseState : CharacterState
{
    private Character _target;
    private Vector3 _lastTargetPosition;

    public ChaseState(Character character, StateChanger stateChanger, Character target) : base(character, stateChanger)
    {
        _target = target;
    }

    public override void EnterState()
    {
        //_character.OnCollisionEntered += StepAside;
    }

    public override void LogicUpdate()
    {
        CheckExecutionCondition();
    }

    public override void PhysicsUpdate()
    {
        ChaseTarget();
    }

    public override void CheckExecutionCondition()
    {
        if (IsAttackRange())
        {
            StartAttackState();
        }

        if (_target == null)
        {
            StartSearchState();
        }
    }

    private void ChaseTarget()
    {
        _character.MoveTo(MovementDirection());
    }

    private bool IsAttackRange()
    {
        return GlobalConstants.IsAttackRange(_character.transform, _target.transform);
    }

    private void StartAttackState()
    {
        _stateChanger.SetState(new AttackState(_character, _stateChanger, _target));
    }

    private void StartSearchState()
    {
        _stateChanger.SetState(new SearchState(_character, _stateChanger, _lastTargetPosition));
    }

    private void RecordLastTargetPosition()
    {
        if (_target != null)
        {
            _lastTargetPosition = _target.transform.position;
        }
    }

    private Vector3 MovementDirection()
    {
        return _target.transform.position;
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

    public override void ExitState()
    {
        //_character.OnCollisionEntered -= StepAside;
    }
}