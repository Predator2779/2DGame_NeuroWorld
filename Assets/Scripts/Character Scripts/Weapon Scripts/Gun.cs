using GlobalVariables;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField] private string _name;
    [SerializeField] private int _damage;
    [SerializeField] private bool _ricochet;
    [SerializeField] [Range(0, 10)] private int _timeRollback;

    private bool _firePermission = true;
    private float _timeLeft;

    public override string Name { get => _name; }
    public override int Damage { get => _damage; set => _damage = Damage; }

    private void FixedUpdate()
    {
        ShootRollback();
    }

    public override void Fire()
    {
        Shoot();
    }

    public override void Use()
    {
       
    }

    private void Shoot()
    {
        if (_firePermission)
        {
            var bulletSpawnPlace = transform.position + transform.up * transform.localScale.y / 2;
            var bulletVector = transform.up * GlobalConstants.BulletForce;
            var bullet = PoolManager.GetObject("Bullet", bulletSpawnPlace, transform.rotation);

            bullet.GetComponent<Bullet>().SetBulletOptions(_damage, _ricochet);
            bullet.GetComponent<Rigidbody2D>().AddForce(bulletVector, ForceMode2D.Impulse);

            _firePermission = false;

            ResetRollback();
        }
    }

    private void ResetRollback()
    {
        _timeLeft = _timeRollback * GlobalConstants.CoefShotRollback;
    }

    private void ShootRollback()
    {
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;

            _firePermission = false;
        }
        else
        {
            _firePermission = true;
        }
    }
}