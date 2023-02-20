using GlobalVariables;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Warrior : Character
{
    [SerializeField] protected Weapon _weapon;

    public Weapon Weapon { get { return _weapon; } set { _weapon = value; } }

    public void Attack()
    {
        if (_weapon != null)
        {
            _weapon.Fire();
        }
    }

    public void EquipWeapon(Weapon weapon)
    {
        if (_weapon != null)
        {
            UnequipWeapon();
        }

        _weapon = weapon;

        PositioningWeapon(weapon);
    }

    public void UnequipWeapon()
    {
        _weapon.transform.parent = null;

        _weapon = null;
    }

    private void PositioningWeapon(Weapon weapon)
    {
        weapon.transform.SetParent(this.transform);

        var vec = new Vector2(GlobalConstants.WeaponPosition.x, GlobalConstants.WeaponPosition.y);

        weapon.transform.localPosition = vec;
        weapon.transform.rotation = this.transform.rotation;
    }
}