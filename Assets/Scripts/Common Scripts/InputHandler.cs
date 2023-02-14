using UnityEngine;
using GlobalVars;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Character _player;
    [SerializeField] private PlayerCursor _cursor;

    [SerializeField][Range(1, 10)] private int _sensitivityX;
    [SerializeField][Range(1, 10)] private int _sensitivityY;

    private float _posX = 0;
    private float _posY = 0;

    private void FixedUpdate()
    {
        _player.MoveTo(MovementVector());
    }

    private void Update()
    {
        _player.RotateByAngle(InputMousePositionX());
        _cursor.SetPosition(Input.mousePosition);
    }

    private Vector2 MovementVector()
    {
        var VerticalAxis = Input.GetAxis(GlobalVariables.VerticalAxis);
        var HorizontalAxis = Input.GetAxis(GlobalVariables.HorizontalAxis);

        var v = _player.transform.up * VerticalAxis;
        var h = _player.transform.right * HorizontalAxis;

        Vector2 vector = h + v;

        return vector;
    }

    private float InputMousePositionX()
    {
        _posX -= Input.GetAxis(GlobalVariables.MouseX) * _sensitivityX * GlobalVariables.FactorMouseSensitivityX;

        return _posX;
    }

    private float InputMousePositionY()
    {
        _posY = Input.GetAxis(GlobalVariables.MouseY) * _sensitivityY * GlobalVariables.FactorMouseSensitivityY;

        return _posY;
    }
}