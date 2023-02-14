using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Warrior : Character
{
    [SerializeField] protected IWeapon _weapon;

    public IWeapon Weapon { get { return _weapon; } set { _weapon = value; } }

    public void Attack()
    {
        _weapon.Fire();
    }
}