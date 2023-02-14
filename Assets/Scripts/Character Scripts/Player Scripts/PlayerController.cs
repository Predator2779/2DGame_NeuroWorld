using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Character _player;
    [SerializeField] private PlayerCursor _cursor;
    [SerializeField] private InputHandler _inputHandler;

    [SerializeField] private IItem _selectedItem;

    [SerializeField][Range(1, 10)] private int _sensitivityX;
    [SerializeField][Range(1, 10)] private int _sensitivityY;

    private float _posX = 0;
    private float _posY = 0;

    private void Start()
    {
        _cursor.OnCursorTriggerStay += SelectItem;
        _cursor.OnCursorTriggerExit += DeseelectItem;
    }

    private void FixedUpdate()
    {
        _player.MoveTo(GetMovementVector());
    }

    private void Update()
    {
        _player.RotateByAngle(GetAnglePlayerRotation());

        SetCursorPosition();
    }

    private void SelectItem(IItem item)////
    {
        _selectedItem = item;

        if (_inputHandler.GetE())
        {
            _selectedItem.PickUp();
        }
    }

    private void DeseelectItem()
    {
        _selectedItem = null;
    }

    private void SetCursorPosition()
    {
        Vector2 mousePos = GetMousePosition();

        _cursor.transform.position = new(mousePos.x, mousePos.y);
    }

    private Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(_inputHandler.GetMousePosition());
    }

    private Vector2 GetMovementVector()
    {
        var VerticalAxis = _inputHandler.GetVerticalAxis();
        var HorizontalAxis = _inputHandler.GetHorizontallAxis();

        var v = _player.transform.up * VerticalAxis;
        var h = _player.transform.right * HorizontalAxis;

        Vector2 vector = h + v;

        return vector;
    }

    private float GetAnglePlayerRotation()
    {
        _posX -= _inputHandler.GetMousePositionX() * _sensitivityX;

        return _posX;
    }
}