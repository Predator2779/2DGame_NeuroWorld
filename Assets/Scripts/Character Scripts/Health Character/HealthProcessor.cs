using UnityEngine;

public class HealthProcessor : MonoBehaviour, IHealth
{
    [SerializeField] private int _maxHitPoints;
    [SerializeField] private float _coefDefense;
    [SerializeField] private int _hitPoints;

    private Health _health;

    private void Start()
    {
        _health = new Health(_maxHitPoints, _coefDefense);
    }

    private void Update()
    {
        _hitPoints = GetCurrentHitPoints();
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }

    public void TakeHeal(float heal)
    {
        _health.TakeHeal(heal);
    }

    public int GetCurrentHitPoints()
    {
        return _health.GetCurrentHitPoints();
    }
}