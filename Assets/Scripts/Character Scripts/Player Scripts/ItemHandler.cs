using InputData;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    private WeaponController _weaponController;
    [SerializeField] private Item _selectedItem;

    public Item SelectedItem { get => _selectedItem; }

    private void Start()
    {
        _weaponController= GetComponent<WeaponController>();

        EventManager.OnItemSelected.AddListener(SelectItem);
        EventManager.OnItemDeselected.AddListener(DeselectItem);
    }

    private void SelectItem(Item item)
    {
        _selectedItem = item;

        Take(_selectedItem);
    }

    private void DeselectItem()
    {
        _selectedItem = null;
    }

    private void Take(Item item)
    {
        if (InputHandler.GetKeyE())
        {
            if (item.TryGetComponent(out Weapon weapon))
            {
                EquipWeapon(weapon);
            }
            else
            {
                PickUpItem(item);
            }
        }
    }

    private void EquipWeapon(Weapon weapon)
    {
        _weaponController.EquipWeapon(weapon);
    }

    private void PickUpItem(Item item)
    {
        // ...

        _selectedItem.PickUp();
    }
}