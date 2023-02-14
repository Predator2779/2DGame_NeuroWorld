public interface IItem
{
    string Name { get; }

    void PickUp(/*Warrior warrior*/);

    void Put(Warrior warrior);
}