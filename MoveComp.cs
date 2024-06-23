internal class MoveComp
{
    private readonly PositionComp positionComp;
    private readonly IInputComp inputComp;

    public Coords PreviousPosition { get; set; }

    private readonly RandomPositionComp randomPositionComp;

    public MoveComp(PositionComp positionComp, IInputComp inputComp, RandomPositionComp randomPositionComp)
    {
        this.positionComp = positionComp;
        this.inputComp = inputComp;
        this.randomPositionComp = randomPositionComp;
        PreviousPosition = new Coords(positionComp.Position); // Ensure this is correctly initialized
    }

    public void MoveRandomly()
    {
        Coords newPos = randomPositionComp.GenerateRandomPosition();
        positionComp.Position = newPos;
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