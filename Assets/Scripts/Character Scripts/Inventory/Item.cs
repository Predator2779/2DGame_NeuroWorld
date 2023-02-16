using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract string Name { get; }

    public abstract Item PickUp();

    public abstract void Put();
}