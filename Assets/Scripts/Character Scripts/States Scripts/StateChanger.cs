using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StateChanger : MonoBehaviour
{
    public string _currentStateString;//
    public bool StartPatrolState = false;///

    [SerializeField] private GameObject _target;

    private Character _character;

    private CharacterState _currentState;

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        MyMethod();///

        _currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        _currentState.PhysicsUpdate();
    }

    private void Initialize()
    {
        _character = GetComponent<Character>();

        SetState(new IdleState(_character, this));
    }

    public void SetState(CharacterState newState)
    {
        if (_currentState != null)
        {
            _currentState.ExitState();

            _currentState = null;
        }

        _currentState = newState;

        _currentState.EnterState();
    }

    private void MyMethod()///
    {
        _currentStateString = _currentState.ToString();//

        if (StartPatrolState)
        {
            StartPatrolState = false;

            SetState(new PatrolState(_character, this));
        }
    }
}