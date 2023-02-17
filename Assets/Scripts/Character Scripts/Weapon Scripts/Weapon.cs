using UnityEngine;

public class Weapon : Item, IWeapon
{
    [SerializeField] private string _name;
    [SerializeField] private int _damage;

    public override string Name { get => _name; }
    public int Damage { get => _damage; set => _damage = Damage; }

    public void Fire()//
    {
        var bullet = PoolManager.GetObject("Bullet", transform.position, transform.rotation);

        bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * _damage, ForceMode2D.Impulse);
    }

    public override Item PickUp()
    {
        return this;
    }

    public override void Put()
    {
        
    }
}