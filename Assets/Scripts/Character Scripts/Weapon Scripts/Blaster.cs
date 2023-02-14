using UnityEngine;

public class Blaster : MonoBehaviour, IItem, IWeapon
{
    [SerializeField] private string _name;
    [SerializeField] private int _damage;

    public string Name { get => _name; }
    public int Damage { get => _damage; set => _damage = value; }

    public void Fire()
    {
        Debug.Log("Fire");
    }

    public void PickUp(/*Warrior warrior*/)
    {
        //warrior.Weapon = this;

        print("Picked!");

        Destroy(this.gameObject);
    }

    public void Put(Warrior warrior)
    {
        warrior.Weapon = null;
    }
}