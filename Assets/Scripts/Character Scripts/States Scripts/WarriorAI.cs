using Unity.VisualScripting;
using UnityEngine;

public class WarriorAI : StateMachine
{
    #region Debug

    //public string _currentState;
    //public bool StartPatrolState = false;

    #endregion

    public CharacterState _currentCharacterState;
    public CharacterState _startCharacterState;

    [Header("Warrior States:")]

    public WarriorState Chase;
    public WarriorState Attack;
    public WarriorState Search;

    private Character _character;

    private void Start()
    {
        Initialize();

        SetState(_startCharacterState);
    }

    private void Update()
    {
        DebugExecute();///

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
    
    public void SetState(CharacterState newState, Character target)
    {
        _currentCharacterState = newState;

        _currentCharacterState.EnterState(_character);

        var currentWarState = _currentCharacterState.GetComponent<WarriorState>();

        currentWarState.SetTarget(target);
    }

    private void DebugExecute()
    {
        //_currentState = _currentCharacterState.ToString();

        //if (StartPatrolState)
        //{
        //    StartPatrolState = false;

        //    SetState(new PatrolState(_character, this));
        //}
    }
}