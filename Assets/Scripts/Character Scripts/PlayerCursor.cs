using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    // singleton?

    [SerializeField] private Transform _player;
    [SerializeField] private float _maxCursorDistance;
    [SerializeField] private float _minCursorDistance;

    public void SetPositionY(float inputPosition)
    {
        if (transform.localPosition.y > _maxCursorDistance)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, _maxCursorDistance);
        }
        else if (transform.localPosition.y < 0)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, _minCursorDistance);
        }
        else
        {
            transform.localPosition += new Vector3(0, inputPosition);
        }
    }
}