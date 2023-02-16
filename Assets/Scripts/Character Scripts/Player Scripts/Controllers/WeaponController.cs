using GlobalVariables;
using InputData;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private Weapon _weapon;

    private void Update()
    {
        if (_weapon != null && InputHandler.GetLMB())
        {
            _weapon.Fire();
        }
    }

    public void EquipWeapon(Weapon weapon)
    {
        _weapon = weapon;

        PositioningWeapon(_weapon);
    }

    private void PositioningWeapon(Weapon weapon)
    {
        _weapon.transform.position = GlobalConstants.WeaponPosition;
        _weapon.transform.eulerAngles = GlobalConstants.WeaponRotation;
        _weapon.transform.SetParent(transform);
    }
}