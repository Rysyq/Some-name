internal class MoveComp
{
    private readonly PositionComp positionComp;
    private readonly IInputComp inputComp;

    public Coords PreviousPosition { get; set;}

    public MoveComp(PositionComp positionComp, IInputComp inputComp)
    {
        PreviousPosition = new Coords(positionComp.Position);
        this.positionComp = positionComp;
        this.inputComp = inputComp;
    }

    public void Move(Coords targetPosition)
    {
        PreviousPosition.X = positionComp.Position.X;
        PreviousPosition.Y = positionComp.Position.Y;
        
        positionComp.Position.X = targetPosition.X;
        positionComp.Position.Y = targetPosition.Y;
    }

    public Coords GetNextPosition()
    {
        Coords nextPosition = new Coords(positionComp.Position);
        Coords direction = inputComp.GetDirection();
        nextPosition.X += direction.X;
        nextPosition.Y += direction.Y;

        return nextPosition;
    }
}