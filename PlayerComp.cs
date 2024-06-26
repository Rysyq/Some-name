public class ComposedPlayer
{
    public VisualComp VisualComp { get; }
    public HealthComp Health { get; }
    public PositionComp PositionComp { get; }
    public MoveComp Movement { get; }
    public IInputComp InputComp { get; }
    public DamageComp DamageComp { get; }
    public Inventory Inventory { get; }

    public ComposedPlayer(string visual, Coords startingPosition)
    {
        VisualComp = new VisualComp(visual);
        Health = new HealthComp();
        PositionComp = new PositionComp(startingPosition);
        InputComp = new KeyboardInputComp();
        Movement = new MoveComp(PositionComp, InputComp);
        DamageComp = new DamageComp(PositionComp);
        Inventory = new Inventory();
    }

    public void Heal(int amount)
    {
        Health.Heal(amount);
        Console.WriteLine($"Player healed by {amount}. Current health: {Health.Hp}");
    }
}
