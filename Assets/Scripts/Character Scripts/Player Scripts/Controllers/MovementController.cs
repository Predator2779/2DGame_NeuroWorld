using UnityEngine;
using InputData;

public class MovementController : MonoBehaviour
{
    private Character _player;

    [SerializeField][Range(1, 10)] private int _sensitivityX;
    [SerializeField][Range(1, 10)] private int _sensitivityY;

    private float _posX = 0;

    private void Start()
    {
        _player = GetComponent<Character>();
    }

    private void FixedUpdate()
    {
        _player.MoveTo(GetMovementVector());
    }

    private void Update()
    {
        _player.RotateByAngle(GetAnglePlayerRotation());
    }

    private Vector2 GetMovementVector()
    {
        var VerticalAxis = InputHandler.GetVerticalAxis();
        var HorizontalAxis = InputHandler.GetHorizontallAxis();

        var v = _player.transform.up * VerticalAxis;
        var h = _player.transform.right * HorizontalAxis;

        Vector2 vector = h + v;

        return vector;
    }

    private float GetAnglePlayerRotation()
    {
        _posX -= InputHandler.GetMousePositionX() * _sensitivityX;

        return _posX;
    }
}