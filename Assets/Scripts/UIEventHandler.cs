using UnityEngine;
using UnityEngine.UI;
using GlobalVars;

public class UIEventHandler : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private PlayerCursor _cursor;
    [SerializeField] private Text _objectInfo;

    private void Start()
    {
        _cursor.OnCursorTriggerStay += DisplayObjectInfo;
        _cursor.OnCursorTriggerExit += RemoveTextInfo;
    }

    private void DisplayObjectInfo(IItem item)
    {
        var mousePos = _inputHandler.GetMousePosition();

        _objectInfo.rectTransform.position = new Vector2(
            mousePos.x - GlobalVariables.HorizontalOffsetInfo, 
            mousePos.y + GlobalVariables.VerticalOffsetInfo);

        _objectInfo.text = $"Подобрать {item.Name}?";
    }

    private void RemoveTextInfo()
    {
        _objectInfo.text = null;
    }
}