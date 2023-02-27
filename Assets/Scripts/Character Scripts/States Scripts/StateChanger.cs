using UnityEngine;

public class StateChanger : MonoBehaviour
{
    public string _currentState;//
    public bool StartPatrolState = false;///

    private CharacterState _currentCharacterState;
    private Character _character;

    private void Start()
    {
        Initialize();
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

    private void Initialize()
    {
        _character = GetComponent<Character>();

        SetState(new IdleState(_character, this));
    }

    public void SetState(CharacterState newState)
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