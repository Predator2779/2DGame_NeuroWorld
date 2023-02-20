using GlobalVariables;
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
        if (InputHandler.GetLMB())/// сделать под ИИ
        {
            Attack();
        }
    }

    public void Attack()
    {
        _warrior.Attack();
    }

    public void EquipWeapon(Gun weapon)
    {
        _warrior.Weapon = weapon;

        PositioningWeapon(weapon);
    }

    public void UnequipWeapon(Gun weapon)
    {
        weapon.transform.parent = null;

        _warrior.Weapon = null;
    }

    private void PositioningWeapon(Gun weapon)
    {
        weapon.transform.SetParent(_warrior.transform);

        var vec = new Vector2(GlobalConstants.WeaponPosition.x, GlobalConstants.WeaponPosition.y);

        weapon.transform.localPosition = vec;
        weapon.transform.rotation = _warrior.transform.rotation;
    }
}