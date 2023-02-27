using UnityEngine;
using GlobalVariables;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    protected Rigidbody2D _rbody;
    [SerializeField][Range(0, 60)] protected int _movementSpeed;

    public delegate void SomeAction(Collision2D collision);
    public event SomeAction OnCollisionEntered;

    private void Start()
    {
        Initialize();
    }

    private void OnCollisionEnter2D(Collision2D collision)//
    {
        print("Enter");
        OnCollisionEntered?.Invoke(collision);
    }

    protected void Initialize()
    {
        _rbody = GetComponent<Rigidbody2D>();
    }

    public void MoveTo(Vector2 movementDirection)
    {
        float speed = _movementSpeed * GlobalConstants.CoefMovementSpeed;

        ExecuteCommand(new MoveCommand(_rbody, movementDirection * speed));
    }

    public void RotateTo(Vector3 target)
    {
        ExecuteCommand(new RotationCommand(_rbody.transform, target));
    }

    public void RotateByAngle(float angle)
    {
        ExecuteCommandByValue(new RotationCommand(_rbody.transform), angle);
    }

    protected void ExecuteCommand(Command command)
    {
        command.Execute();
    }
    
    protected void ExecuteCommandByValue(Command command, float value)
    {
        command.ExecuteByValue(value);
    }
}