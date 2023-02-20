using InputData;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    private Warrior _warrior;

    [SerializeField] private Item _selectedItem;
    [SerializeField] private float _distance;

    private void Start()
    {
        _warrior = GetComponent<Warrior>();

        EventManager.OnItemSelected.AddListener(SelectItem);
        EventManager.OnItemDeselected.AddListener(DeselectItem);
    }

    private void SelectItem(Item item)
    {
        _selectedItem = item;

        PickUpItem(_selectedItem);
    }

    private void DeselectItem()
    {
        _selectedItem = null;
    }

    private void PickUpItem(Item item)
    {
        if (InputFunctions.GetKeyE())
        {
            if (item.TryGetComponent(out Weapon weapon))
            {
                EquipWeapon(weapon);
            }
        }
    }

    private void EquipWeapon(Weapon weapon)
    {
        _warrior.EquipWeapon(weapon);
    }
}