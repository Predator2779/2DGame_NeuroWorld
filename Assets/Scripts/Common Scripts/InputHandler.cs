using UnityEngine;
using GlobalVars;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Character _player;
    [SerializeField] private float _sensitivity;

    private float _xRot = 0;

    private void FixedUpdate()
    {
        _player.MoveTo(MovementVector());
        _player.RotateByAngle(MousePosition());
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

    private float MousePosition()
    {
        _xRot -= Input.GetAxis(GlobalVariables.MouseX) * _sensitivity;

        return _xRot;
    }
}