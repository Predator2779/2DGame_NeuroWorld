using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PlayerCursor : MonoBehaviour
{
    public delegate void OnCursorStay(IItem item);
    public delegate void OnCursorExit();

    public event OnCursorStay OnCursorTriggerStay;
    public event OnCursorExit OnCursorTriggerExit;

    private void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.gameObject.TryGetComponent(out IItem item))
        {
            OnCursorTriggerStay?.Invoke(item);
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        OnCursorTriggerExit?.Invoke();
    }
}