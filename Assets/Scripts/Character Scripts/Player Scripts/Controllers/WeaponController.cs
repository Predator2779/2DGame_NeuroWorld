using InputData;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private IWeapon _leftHand;
    [SerializeField] private IWeapon _rightHand;

    private void Start()
    {
        EventManager.OnItemSelected.AddListener(Foo);
    }

    private void Foo(Item item)//
    {
        if (InputHandler.GetE())
        {
            if (item.TryGetComponent(out IWeapon weapon)/* || _gun == null*/)
            {
                //_gun = weapon;
            }
            else
            {
                //_selectedItem.PickUp();
            }
        }
    }
}