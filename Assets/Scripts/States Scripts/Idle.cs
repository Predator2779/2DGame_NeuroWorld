using UnityEngine;

public class Idle : CharacterState
{
    private float _lifeTime;

    public Idle(Character character, StateChanger stateChanger, float TimeOfThisState = 1.0f)
        : base(character, stateChanger) { _lifeTime = TimeOfThisState; }

    public override void OnceExecute()
    {
        
    }

    public override void PermanentExecute()
    {
        DecreaseLifeTime();
    }

    public override void Handle()
    {
        StateChanger.ChangeState(new WalkAround(Character, StateChanger, StateChanger.RandomValueInRange()));

        StateChanger.OnceExecute();
    }

    private void DecreaseLifeTime()
    {
        StateChanger.LifeTime = _lifeTime;

        _lifeTime -= Time.deltaTime;

        if (_lifeTime <= 0)
        {
            Handle();
        }
    }
}