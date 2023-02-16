using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] private Item _selectedItem;

    private void Start()
    {
        EventManager.OnItemSelected.AddListener(SelectItem);
        EventManager.OnItemDeselected.AddListener(DeselectItem);
    }

    private void SelectItem(Item item)
    {
        _selectedItem = item;
    }

    private void DeselectItem()
    {
        _selectedItem = null;
    }
}