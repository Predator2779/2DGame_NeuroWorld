using InputData;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] private Item _selectedItem;
    [SerializeField] private Gun _gun;///

    public delegate void OnCursorStay(Item item);
    public delegate void OnCursorExit();

    public event OnCursorStay OnCursorTriggerStay;
    public event OnCursorExit OnCursorTriggerExit;

    private void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.gameObject.TryGetComponent(out Item item))
        {
            SelectItem(item);
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        DeseelectItem();
    }

    private void Foo()//
    {
        if (InputHandler.GetE())
        {
            if (_selectedItem.TryGetComponent(out Gun gun) || _gun == null)
            {
                _gun = gun;
            }
            else
            {
                _selectedItem.PickUp();
            }
        }
    }

    private void SelectItem(Item item)
    {
        OnCursorTriggerStay?.Invoke(item);

        _selectedItem = item;
    }

    private void DeseelectItem()
    {
        OnCursorTriggerExit?.Invoke();

        _selectedItem = null;
    }
}