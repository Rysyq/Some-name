public class PositionComp
{
    public Coords Position { get; set; }

    public PositionComp(Coords startingPosition)
    {
        Position = new Coords(startingPosition);
    }
}