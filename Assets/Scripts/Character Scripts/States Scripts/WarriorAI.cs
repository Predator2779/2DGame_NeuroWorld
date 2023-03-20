using UnityEngine;

[RequireComponent(typeof(Character))]
public class WarriorAI : StateMachine
{
    private Character _character;

    [Header("Warrior States:")]

    public WarriorState Chase;
    public WarriorState Attack;
    public WarriorState Search;

    [Header("Setting State:")]
    [SerializeField] private CharacterState _currentCharacterState;
    public CharacterState _startCharacterState;

    private void Start()
    {
        Initialize();

        SetState(_startCharacterState);
    }

    private void Update()
    {
        _currentCharacterState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        _currentCharacterState.PhysicsUpdate();
    }

    protected override void Initialize()
    {
        _character = GetComponent<Character>();
    }

    public override void SetState(CharacterState newState)
    {
        _currentCharacterState = newState;

        _currentCharacterState.EnterState(_character);
    } 
       
    public void SetTarget(Character target)
    {
        WarriorState warriorState;

        if (_currentCharacterState is WarriorState)
        {
            warriorState = (WarriorState)_currentCharacterState;

            warriorState.SetTarget(target);
        }
        else
        {
            SetState(Chase);

            warriorState = (WarriorState)_currentCharacterState;
        }

        warriorState.SetTarget(target);
    }

    public void TargetIsGone()
    {
        if (_currentCharacterState is WarriorState)
        {
            WarriorState warriorState = (WarriorState)_currentCharacterState;

            warriorState.TargetIsGone();
        }
    }
}