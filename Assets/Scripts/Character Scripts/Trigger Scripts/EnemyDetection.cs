using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public WarriorAI _warriorAI;
    [SerializeField] private Character _target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsPlayer(collision, out Character character))
        {
            _target = character;
            _warriorAI.SetTarget(_target);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsPlayer(collision, out Character character))
        {
            _target = null;
            _warriorAI.TargetIsGone();
        }
    }

    private bool IsPlayer(Collider2D collision, out Character character)
    {
        if (collision.gameObject.TryGetComponent(out character) && character.tag == "Player")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}