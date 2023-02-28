using UnityEngine;

public abstract class CharacterState : ScriptableObject
{
    protected CharacterState(Character character, StateChanger stateChanger)
    {
        _character = character;
        _stateChanger = stateChanger;
    }

    protected Character _character;
    protected StateChanger _stateChanger;

    public virtual void EnterState() { }

    public abstract void LogicUpdate();

    public virtual void PhysicsUpdate() { }

    public abstract void CheckExecutionCondition();

    public abstract void ExitState();
}