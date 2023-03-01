using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected abstract void Initialize();

    public abstract void SetState(CharacterState newState);
}