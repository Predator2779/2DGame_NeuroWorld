using UnityEngine;

public class Gun : Item, IWeapon
{
    [SerializeField] private string _name;
    [SerializeField] private int _damage;

    public Gun(string name, int damage)
    {
        _name = name;
        _damage = damage;
    }

    public override string Name { get => _name; }
    public int Damage { get => _damage; set => _damage = Damage; }

    public void Fire()
    {
        Debug.Log("Fire!");
    }

    public override Item PickUp()
    {
        print("Picked!");

        return this;
    }

    public override void Put()
    {
        print("Put!");
    }
}