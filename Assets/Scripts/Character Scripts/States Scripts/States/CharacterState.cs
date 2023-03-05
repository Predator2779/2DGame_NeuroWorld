using UnityEngine;

public abstract class CharacterState : ScriptableObject
{
    public abstract void EnterState(Character character);

    public abstract void LogicUpdate();

    public virtual void PhysicsUpdate() { }

    protected abstract void CheckExecutionCondition();

    protected virtual void ExitState() { }
}