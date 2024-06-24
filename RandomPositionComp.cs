public class RandomPositionComp
{
    Random rps;
    private int X;
    private int Y;

    public Coords RandomPosition { get; set; }

    public RandomPositionComp(Coords startingRandomPosition)
    {
        RandomPosition = new Coords(startingRandomPosition);
    }

    public RandomPositionComp(int X, int Y)
    {
        rps = new Random();
        this.X = X;
        this.Y = Y;
    }

    public Coords GenerateRandomPosition()
    {
        int randomX = rps.Next(X);
        int randomY = rps.Next(Y);
        return new Coords(randomX, randomY);
    }
}
