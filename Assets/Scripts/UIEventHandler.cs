using UnityEngine;
using UnityEngine.UI;
using GlobalVariables;
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
        var mousePos = InputFunctions.GetMousePosition();

        _objectInfo.rectTransform.position = new Vector2(
            mousePos.x - GlobalConstants.HorizontalOffsetInfo,
            mousePos.y + GlobalConstants.VerticalOffsetInfo);

        _objectInfo.text =
            $"{item.Name}\n" +
            $"Е - подобрать";
    }

    private void RemoveTextInfo()
    {
        _objectInfo.text = null;
    }
}