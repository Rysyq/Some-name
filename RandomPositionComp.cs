class RandomPositionComp
{
    Random rps;
    private int maxX;
    private int maxY;

    public RandomPositionComp(int maxX, int maxY)
    {
        rps = new Random();
        this.maxX = maxX;
        this.maxY = maxY;
    }

    public Coords GenerateRandomPosition()
    {
        return new Coords(rps.Next(maxX), rps.Next(maxY));
    }
}