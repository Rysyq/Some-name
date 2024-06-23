class ComposedPlayer
{
    public HealthComp Health { get; }
    public PositionComp PositionComp { get; }
    public IInputComp InputComp { get; }
    public VisualComp VisualComp { get; }
    public MoveComp Move { get; }
    public ComposedPlayer(string visual, Coords startingPosition)
    {
        Health = new HealthComp();
        PositionComp = new PositionComp(startingPosition);
        InputComp = new KeyboardInputComp();
        VisualComp = new VisualComp(visual);
        Move = new MoveComp(PositionComp, InputComp);
    }
}
