using InputData;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    private void Update()
    {
        SetPosition(GetMousePosition());
    } 

    private void SetPosition(Vector2 mousePos)
    {
        transform.position = new(mousePos.x, mousePos.y);
    }

    private Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(InputHandler.GetMousePosition());
    }

    private void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.gameObject.TryGetComponent(out Item item))
        {
            EventManager.OnItemSelected?.Invoke(item);
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject.TryGetComponent(out Item item))
        {
            EventManager.OnItemDeselected?.Invoke();
        }
    }
}
