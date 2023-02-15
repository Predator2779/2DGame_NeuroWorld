using InputData;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    private ItemHandler _cursor;

    private void Start()
    {
        _cursor= GetComponent<ItemHandler>();
    }

    private void Update()
    {
        SetCursorPosition();
    } 

    private void SetCursorPosition()
    {
        Vector2 mousePos = GetMousePosition();

        _cursor.transform.position = new(mousePos.x, mousePos.y);
    }

    private Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(InputHandler.GetMousePosition());
    }
}
