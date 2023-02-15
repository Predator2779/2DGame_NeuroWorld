//public interface IItem
//{
//    string Name { get; }

//    void PickUp();

//    void Put();
//}

using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string Name { get; }

    public abstract Item PickUp();

    public abstract Item Put();
}