using UnityEngine;
using GlobalStringVars;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Character _player;

    private void FixedUpdate()
    {
        _player.MoveTo(MovementVector());
        _player.RotateTo(MousePosition());
    }

    private Vector2 MovementVector()
    {
        var VerticalAxis = Input.GetAxis(GlobalVariables.VerticalAxis);
        var HorizontalAxis = Input.GetAxis(GlobalVariables.HorizontalAxis);

        var v = Vector2.up * VerticalAxis;
        var h = Vector2.right * HorizontalAxis;

        Vector2 vector = h + v;

        return vector;
    }

    private Vector2 MousePosition()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        return mousePos;
    }
}