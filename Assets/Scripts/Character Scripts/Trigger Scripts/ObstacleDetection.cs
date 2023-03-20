using UnityEngine;

public class ObstacleDetection : MonoBehaviour
{
    private Character _character;

    private void Start()
    {
        _character= GetComponent<Character>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RotateCharacter(collision);
    }

    private void RotateCharacter(Collision2D collision)
    {
        var hit = collision.contacts[0];

        Vector3 hitPosition = new Vector3(hit.point.x, hit.point.y);

        Vector3 direction = hitPosition + _character.transform.up;

        _character.RotateTo(direction);
    }
}