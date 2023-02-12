using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private Transform _object;

    private void FixedUpdate()
    {
        if (_object != null)
        {
            transform.position = new Vector3(_object.position.x, _object.position.y, transform.position.z);

            transform.rotation = new Quaternion(
                transform.rotation.x, transform.rotation.y, _object.rotation.z, transform.rotation.w);
        }
    }
}