public interface IWeapon
{
    int Damage { get; set; }

    void Fire();

    IWeapon Equip();
}