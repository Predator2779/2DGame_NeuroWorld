using UnityEngine;

public class WalkAround : CharacterState
{
    private float _lifeTime;

    public WalkAround(Character character, StateChanger stateChanger, float TimeOfThisState = 1.0f)
        : base(character, stateChanger) { _lifeTime = TimeOfThisState; }

    public override void OnceExecute()
    {
        Character.OnPlayerCollisionEnter += RotateToBack;

        RotateCharacter();
    }

    public override void PermanentExecute()
    {
        DecreaseLifeTime();

        Character.MoveTo(Character.transform.up);
    }

    public override void Handle()
    {
        Character.OnPlayerCollisionEnter -= RotateToBack;

        StateChanger.ChangeState(new Idle(Character, StateChanger, StateChanger.RandomValueInRange()));

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

    private void RotateCharacter()
    {
        float angle = Random.Range(0.0f, 360.0f);

        Character.RotateByAngle(angle);
    }

    private void RotateToBack()
    {
        float angle = Character.transform.rotation.eulerAngles.z + 180.0f;

        Character.RotateByAngle(angle);
    }
}