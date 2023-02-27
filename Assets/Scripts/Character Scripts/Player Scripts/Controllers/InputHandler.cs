using UnityEngine;
using InputData;

public class InputHandler : MonoBehaviour
{
    private Character _player;
    private Warrior _playerWar;

    [SerializeField][Range(1, 10)] private int _sensitivityX;
    [SerializeField][Range(1, 10)] private int _sensitivityY;

    private float _posX = 0;

    private void Start()
    {
        Initialize();
    }

    private void FixedUpdate()
    {
        _player.MoveTo(GetMovementVector());
    }

    private void Update()
    {
        if (CanAttack())
        {
            _playerWar.Attack();
        }

        _player.RotateByAngle(GetAnglePlayerRotation());
    }

    private void Initialize()
    {
        _player = GetComponent<Character>();

        if (TryGetComponent(out Warrior warrior))
        {
            _playerWar = warrior;
        }
    }

    private bool CanAttack()
    {
        var PressedLMB = InputFunctions.GetLMB();

        if (_playerWar != null && PressedLMB)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private Vector2 GetMovementVector()
    {
        var VerticalAxis = InputFunctions.GetVerticalAxis();
        var HorizontalAxis = InputFunctions.GetHorizontallAxis();

        var v = _player.transform.up * VerticalAxis;
        var h = _player.transform.right * HorizontalAxis;

        Vector2 vector = h + v;

        return vector;
    }

    private float GetAnglePlayerRotation()
    {
        _posX -= InputFunctions.GetMousePositionX() * _sensitivityX;

        return _posX;
    }
}