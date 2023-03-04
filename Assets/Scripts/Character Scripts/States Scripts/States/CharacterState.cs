using UnityEngine;

public abstract class CharacterState : ScriptableObject
{
    protected CharacterState(Character character, StateMachine stateMachine)
    {
        _character = character;
        _stateMachine = stateMachine;
    }

    protected Character _character;
    protected StateMachine _stateMachine;

    public abstract void EnterState();

    public abstract void LogicUpdate();

    public virtual void PhysicsUpdate() { }

    public abstract void CheckExecutionCondition();

    public abstract void ExitState();
}