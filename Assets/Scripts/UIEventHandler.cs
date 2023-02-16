using UnityEngine;
using UnityEngine.UI;
using GlobalVars;
using InputData;

public class UIEventHandler : MonoBehaviour
{
    [SerializeField] private Text _objectInfo;

    private void Start()
    {
        EventManager.OnItemSelected.AddListener(DisplayObjectInfo);
        EventManager.OnItemDeselected.AddListener(RemoveTextInfo);
    }

    private void DisplayObjectInfo(Item item)
    {
        var mousePos = InputHandler.GetMousePosition();

        _objectInfo.rectTransform.position = new Vector2(
            mousePos.x - GlobalVariables.HorizontalOffsetInfo,
            mousePos.y + GlobalVariables.VerticalOffsetInfo);

        _objectInfo.text =
            $"{item.Name}\n" +
            $"Е - подобрать";
    }

    private void RemoveTextInfo()
    {
        _objectInfo.text = null;
    }
}