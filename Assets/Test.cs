using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Warrior _warrior;
    [SerializeField] private Vector2 _lastTargetPosition;

    private void Start()
    {
        _warrior = GetComponent<Warrior>();
    }

    private void Update()
    {
        RecordLastTargetPosition();
    }

    private void FixedUpdate()
    {
        _warrior.RotateTo(_target.position);
        _warrior.MoveTo(TargetDirection());
    }

    private void RecordLastTargetPosition()
    {
        if (_target != null)
        {
            _lastTargetPosition = _target.transform.position;
        }
    }

    private Vector2 TargetDirection()
    {
        return _lastTargetPosition - (Vector2)_warrior.transform.position;
    }
}