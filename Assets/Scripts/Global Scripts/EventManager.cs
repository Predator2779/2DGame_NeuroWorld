using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent<Item> OnItemSelected = new UnityEvent<Item>();
    public static UnityEvent OnItemDeselected = new UnityEvent();
}