public class Coordinates
{
public int X { get; set; }
public int Y { get; set; }
    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Coordinates(Coordinates other)
    {
        X = other.X;
        Y = other.Y;
    }
}