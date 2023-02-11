using UnityEngine;

public class RotationCommand : Command
{
    #region Конструктор

    public RotationCommand(Transform RotatableObj)
    {
        _rotatableObj = RotatableObj;
    }

    public RotationCommand(Transform RotatableObj, Vector3 TargetObj)
    {
        _rotatableObj = RotatableObj;
        _targetObj = TargetObj;
    }

    #endregion

    private Transform _rotatableObj;
    private Vector3 _targetObj;

    /// <summary>
    /// Повернуть rotatableObj к targetOgj. 
    /// </summary>
    public override void Execute()
    {
        //угол между вектором от rotatableObj к targetOgj.
        var angle = Vector2.Angle(Vector2.right, _targetObj - _rotatableObj.position);

        //устанавливает угол, в зависимости от позиции targetOgj по Y.
        var newAngle = _rotatableObj.position.y < _targetObj.y ? (angle - 90.0f) : (-angle - 90.0f);

        ExecuteByValue(newAngle);
    }

    /// <summary>
    /// Повернуть rotatableObj на указанный угол.
    /// </summary>
    /// <param name="angle">Угол</param>
    public override void ExecuteByValue(float angle)
    {
        _rotatableObj.eulerAngles = new Vector3(0f, 0f, angle);
    }
}