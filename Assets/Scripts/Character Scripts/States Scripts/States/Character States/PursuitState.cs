using GlobalVariables;
using UnityEngine;

public class PursuitState : CharacterState
{
    private Character _target;

    public PursuitState(Character character, StateChanger stateChanger, Character target) : base(character, stateChanger)
    {
        _target = target;
    }

    public override void EnterState()
    {
        _character.OnCollisionEntered += StepAside;
    }

    public override void LogicUpdate()
    {
        CheckExecutionCondition();
    }

    public override void PhysicsUpdate()
    {
        _character.MoveTo(MovementDirection());
    }

    public override void CheckExecutionCondition()
    {
        if (_target == null)
        {
            StartPatrolState();
        }
    }

    public void StartPatrolState()
    {
        _stateChanger.SetState(new PatrolState(_character, _stateChanger));
    }

    private Vector3 MovementDirection()
    {
        return _target.transform.position * KeepDistanseFromTarget();
    }

    private void RotateCharacter(float angle)
    {
        _character.RotateByAngle(angle);
    }

    private void StepAside(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")//
        {
            var angle = _character.transform.rotation.eulerAngles.z + RandomAngle(90.0f, 270.0f);

            RotateCharacter(angle);
        }
    }

    private float RandomAngle(float minAngle, float maxAngle)
    {
        return Random.Range(minAngle, maxAngle);
    }

    private int KeepDistanseFromTarget()
    {
        float currentDistance = Vector2.Distance(_character.transform.position, _target.transform.position);

        float requiredDistance = GlobalConstants.DistanceToTarget;

        /// Учитываем влияние размера нашего объекта.
        requiredDistance *= _target.transform.localScale.y * _character.transform.localScale.y;
        /// Погрешность в 1/4 необходимой дистанции.
        float variation = requiredDistance * 0.25f;

        float minDistance = requiredDistance - variation;
        float maxDistance = requiredDistance + variation;

        /// Если нужная дистанция: возвращает 0 (объект будет стоять на месте).
        /// Если дистанция больше необходимой: возвращает 1 (объект будет двигаться вперед).
        /// Если дистанция меньше необходимой: возвращает -1 (объект будет двигаться назад).
        if (minDistance < currentDistance && currentDistance < maxDistance)
        {
            return 0;
        }
        else if (currentDistance > maxDistance)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    public override void ExitState()
    {
        _character.OnCollisionEntered -= StepAside;
    }
}