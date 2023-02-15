public interface IWeapon
{
    int Damage { get; set; }

    void Fire();

    Gun Take();
}