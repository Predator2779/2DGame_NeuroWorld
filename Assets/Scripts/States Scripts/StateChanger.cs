using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateChanger : MonoBehaviour
{
    [SerializeField][Range(0.0f, 10.0f)] private float _minStateChangeTime = 0.0f;
    [SerializeField][Range(0.0f, 10.0f)] private float _maxStateChangeTime = 2.0f;
    [SerializeField] private string _currentState = "";

    public float LifeTime;//

    private Character _character;
    private CharacterState _currentCharacterState;

    private void Start()
    {
        InitialSetup();
    }

    private void FixedUpdate()
    {
        DisplayCurrentState();

        PermanentExecute();
    }

    private void InitialSetup()
    {
        _character = GetComponent<Character>();

        _currentCharacterState = new Idle(_character, this, RandomValueInRange());
    }

    private void DisplayCurrentState()
    {
        _currentState = _currentCharacterState.ToString();
    }  

    private void PermanentExecute()
    {
        _currentCharacterState.PermanentExecute();
    }

    public void OnceExecute()
    {
        _currentCharacterState.OnceExecute();
    }

    public void ChangeState(CharacterState state)
    {
        _currentCharacterState = state;
    }
    
    public float RandomValueInRange()
    {
        return Random.Range(_minStateChangeTime, _maxStateChangeTime);
    }
}