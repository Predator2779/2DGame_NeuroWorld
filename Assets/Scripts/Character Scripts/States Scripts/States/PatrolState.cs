using GlobalVariables;
using UnityEngine;

public class PatrolState : CharacterState
{
    private Character _target;
    private float _lifeTime;

    public PatrolState(Character character, StateMachine stateMachine)
        : base(character, stateMachine) { }

    public override void EnterState()
    {
        //_character.OnCollisionEntered += StepAside;

        _lifeTime = RandomStateTime();

        RotateCharacter(RandomAngle(0.0f, 360.0f));
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

    public override void CheckExecutionCondition()
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

    public void StartIdleState()
    {
        _stateMachine.SetState(new IdleState(_character, _stateMachine));
    }

    public void StartChaseState(Character target)
    {
       _stateMachine.SetState(new ChaseState(_character, _stateMachine, target));
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

    private float RandomStateTime()
    {
        var minStateTime = GlobalConstants.MinStateTime;
        var maxStateTime = GlobalConstants.MaxStateTime;

        return Random.Range(minStateTime, maxStateTime);
    }

    public override void ExitState()
    {
        _lifeTime = 0;

        //_character.OnCollisionEntered -= StepAside;
    }
}