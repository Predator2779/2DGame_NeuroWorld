public abstract class CharacterState
{
    protected CharacterState(Character character, StateChanger stateChanger) 
    { 
        Character = character;
        StateChanger = stateChanger;
    }
    
    protected Character Character { get; set; }
    protected StateChanger StateChanger { get; set; }

    public abstract void OnceExecute();

    public abstract void PermanentExecute();
    
    public abstract void Handle();
}