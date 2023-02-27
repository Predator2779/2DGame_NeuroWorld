using GlobalVariables;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _damage;
    private bool _ricochet;

    public void SetBulletOptions(int damage = 1, bool ricochet = false)
    {
        _damage = damage;
        _ricochet = ricochet;
    }

    private void ApplyDamage(GameObject obj)
    {
        if (obj.TryGetComponent(out IHealth health))
        {
            health.TakeDamage(CalculateDamage());
        }
    }

    private void ReturnBulletToPool()
    {
        gameObject.GetComponent<PoolObject>().ReturnToPool();
    }

    private float CalculateDamage()
    {
        float randValue = Random.Range(GlobalConstants.MinRangeDamage, GlobalConstants.MaxRangeDamage);

        return randValue * _damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var obj = collision.gameObject;

        if (IsDamageable(obj))
        {
            ApplyDamage(obj);
        }

        if (!CanRicochet())
        {
            ReturnBulletToPool();
        }
    }

    private bool IsDamageable(GameObject obj)
    {
        if (!obj.GetComponent<Bullet>())
        {
            return true;
        }
        else
        {
            return false;
        }
    }  
    
    private bool CanRicochet()
    {
        if (_ricochet)
        {
            _ricochet = false;

            return true;
        }
        else
        {
            return false;
        }
    }
}