using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    [Header("Character States:")]
    public CharacterState Idle;
    public CharacterState Patrol;

    protected abstract void Initialize();

    public abstract void SetState(CharacterState newState);
}