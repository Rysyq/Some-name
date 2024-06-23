class ComposedPlayer
{
    public HealthComp Health { get; }
    public PositionComp PositionComp { get; }
    public IInputComp InputComp { get; }
    public VisualComp VisualComp { get; }
    public MoveComp Move { get; }

    public DamageComp Damaging { get; }

    public ComposedPlayer(string visual, Coords startingPosition, int maxX, int maxY)
    {
        Health = new HealthComp();
        PositionComp = new PositionComp(startingPosition);
        InputComp = new KeyboardInputComp();
        VisualComp = new VisualComp(visual);
        var randomPositionComp = new RandomPositionComp(maxX, maxY);
        Move = new MoveComp(PositionComp, InputComp, randomPositionComp);
        Damaging = new DamageComp(PositionComp);
    }
}

