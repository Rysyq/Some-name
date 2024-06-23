class ComposedPlayer
{
    public VisualComp VisualComp { get; }
    public HealthComp Health { get; }
    public PositionComp PositionComp { get; }
    public MoveComp Movement { get; }
    public IInputComp InputComp { get; }
    public DamageComp DamageComp { get; }

    public ComposedPlayer(string visual, Coords startingPosition)
    {
        VisualComp = new VisualComp(visual);
        Health = new HealthComp();
        PositionComp = new PositionComp(startingPosition);
        InputComp = new KeyboardInputComp();
        Movement = new MoveComp(PositionComp, InputComp);
        DamageComp = new DamageComp(PositionComp);
    }
}
