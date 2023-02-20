using InputData;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private Warrior _warrior;

    private void Start()
    {
        _warrior = GetComponent<Warrior>();
    }

    private void Update()
    {
        if (InputFunctions.GetLMB())
        {
            _warrior.Attack();
        }
    }
}