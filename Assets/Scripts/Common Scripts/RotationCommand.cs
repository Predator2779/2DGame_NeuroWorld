using UnityEngine;

public class RotationCommand : Command
{
    public RotationCommand(Transform RotatableObj)
    {
        _rotatableObj = RotatableObj;
    }

    public RotationCommand(Transform RotatableObj, Vector2 TargetObj)
    {
        _rotatableObj = RotatableObj;
        _targetObj = TargetObj;
    }

    private Transform _rotatableObj;
    private Vector2 _targetObj;

    public override void Execute()
    {
        var angle = Vector2.Angle(Vector2.right, _targetObj - (Vector2)_rotatableObj.position);

        var newAngle = _rotatableObj.position.y < _targetObj.y ? (angle - 90.0f) : (-angle - 90.0f);

        ExecuteByValue(newAngle);
    }

    public override void ExecuteByValue(float angle)
    {
        _rotatableObj.localRotation = Quaternion.Euler(0f, 0f, angle);
    }
}