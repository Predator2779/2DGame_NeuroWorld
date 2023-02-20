public abstract class Weapon : Item
{
    public abstract int Damage { get; set; }

    public abstract void Fire();
}