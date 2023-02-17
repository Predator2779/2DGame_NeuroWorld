using UnityEngine;

[AddComponentMenu("Pool/PoolObject")]
public class PoolObject : MonoBehaviour
{
    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)//
    {
        if (!collision.gameObject.GetComponent<PoolObject>())
        {
            ReturnToPool();
        }
    }
}