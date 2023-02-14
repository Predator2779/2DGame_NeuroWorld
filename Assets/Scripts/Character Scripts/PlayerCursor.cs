using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    public void SetPosition(Vector2 inputPosition)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(inputPosition);

        transform.position = new (mousePos.x, mousePos.y);
    }
}