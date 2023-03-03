using UnityEngine;

public class WarriorAI : StateMachine
{
    public string _currentState;//
    public bool StartPatrolState = false;///

    private CharacterState _startCharacterState;
    private CharacterState _currentCharacterState;
    private Character _character;

    private void Start()
    {
        Initialize();

        SetState(_startCharacterState);
    }

    private void Update()
    {
        MyMethod();///

        _currentCharacterState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        _currentCharacterState.PhysicsUpdate();
    }

    protected override void Initialize()
    {
        _character = GetComponent<Character>();

        _startCharacterState = new IdleState(_character, this);
    }

    public override void SetState(CharacterState newState)
    {
        if (_currentCharacterState != null)
        {
            _currentCharacterState.ExitState();

            _currentCharacterState = null;
        }

        _currentCharacterState = newState;

        _currentCharacterState.EnterState();
    }

    private void MyMethod()///
    {
        _currentState = _currentCharacterState.ToString();//

        if (StartPatrolState)
        {
            StartPatrolState = false;

            SetState(new PatrolState(_character, this));
        }
    }
}