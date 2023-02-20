using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract string Name { get; }

    public abstract void Use();
}