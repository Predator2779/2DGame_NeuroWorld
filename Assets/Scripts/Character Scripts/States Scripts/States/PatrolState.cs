using UnityEngine;

[CreateAssetMenu(fileName = "New PatrolState",
    menuName = "Scriptable Objects/Character States/Patrol State", order = 1)]
public class PatrolState : WarriorState
{
    public float LifeTime;

    private Character _target;
    private float _lifeTime;
    private Character _character;
    private StateMachine _stateMachine;

    public override void EnterState(Character character)
    {
        _character = character;
        _stateMachine = character.GetComponent<StateMachine>();
        _lifeTime = LifeTime;

        //_character.OnCollisionEntered += StepAside;
        RotateCharacter(RandomAngle(0.0f, 360.0f));//
    }

    public override void SetTarget(Character target)
    {
        _target = target;
    }

    public override void LogicUpdate()
    {
        CheckExecutionCondition();
    }

    public override void PhysicsUpdate()
    {
        DecreaseLifeTime();

        _character.MoveTo(_character.transform.up);
    }

    protected override void CheckExecutionCondition()
    {
        if (_lifeTime <= 0)
        {
            StartIdleState();
        }
        else if (_target != null)
        {
            StartChaseState(_target);
        }
    }

    private void StartIdleState()
    {
        _stateMachine.SetState(_stateMachine.Idle);
    }

    private void StartChaseState(Character target)//
    {
        if (_stateMachine.TryGetComponent(out WarriorAI warriorAI))
        {
            warriorAI.SetState(warriorAI.Chase, target);

            ExitState();
        }
        else
        {
            StartIdleState();
        }
    }

    private void DecreaseLifeTime()
    {
        _lifeTime -= Time.deltaTime;
    }

    private void RotateCharacter(float angle)
    {
        _character.RotateByAngle(angle);
    }

    //private void StepAside(Collision2D collision)
    //{
    //    if (collision.gameObject.tag != "Player")//
    //    {
    //        var angle = _character.transform.rotation.eulerAngles.z + RandomAngle(90.0f, 270.0f);

    //        RotateCharacter(angle);
    //    }
    //    else
    //    {
    //        StartPursuitState(collision.gameObject.GetComponent<Character>());
    //    }
    //}

    private float RandomAngle(float minAngle, float maxAngle)
    {
        return Random.Range(minAngle, maxAngle);
    }

    protected override void ExitState()
    {
        //_character.OnCollisionEntered -= StepAside;
    }
}