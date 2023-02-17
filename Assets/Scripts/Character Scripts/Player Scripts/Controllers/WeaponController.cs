using GlobalVariables;
using InputData;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private Warrior _warrior;
    private Weapon _weapon;

    private void Start()
    {
        _warrior = GetComponent<Warrior>();
    }

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

    public void UnequipWeapon(Weapon weapon)
    {
        weapon.transform.parent = null;

        _weapon = null;
    }

    private void PositioningWeapon(Weapon weapon)//
    {
        weapon.transform.SetParent(_warrior.transform);

        var vec = new Vector2(GlobalConstants.WeaponPosition.x, GlobalConstants.WeaponPosition.y);

        weapon.transform.localPosition = vec;
        weapon.transform.rotation = _warrior.transform.rotation;
    }
}