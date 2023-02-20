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
}