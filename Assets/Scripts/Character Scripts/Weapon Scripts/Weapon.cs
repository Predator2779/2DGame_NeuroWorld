using UnityEngine;

public class Weapon : Item, IWeapon
{
    [SerializeField] private string _name;
    [SerializeField] private int _damage;

    public override string Name { get => _name; }
    public int Damage { get => _damage; set => _damage = Damage; }

    public void Fire()
    {
        print("Fire!");
    }

    public IWeapon Equip()
    {
        return this;
    }

    public override Item PickUp()
    {
        return this;
    }

    public override void Put()
    {
        print("Put!");
    }
}