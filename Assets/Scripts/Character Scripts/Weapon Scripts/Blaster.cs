using UnityEngine;

public class Blaster : MonoBehaviour, IItem, IWeapon
{
    [SerializeField] private int _damage;

    public int Damage { get => _damage; set => _damage = value; }

    public void Fire()
    {
        Debug.Log("Fire");
    }

    public void PickUp(Warrior warrior)
    {
        warrior.Weapon = this;
    }

    public void Put(Warrior warrior)
    {
        warrior.Weapon = null;
    }
}