public class RandomInputComp : IInputComp
{
    public Coords GetDirection()
    {
        Random random = new Random();
        int direction = random.Next(4);
        switch (direction)
        {
            case 0: return new Coords(0, -1); 
            case 1: return new Coords(0, 1);  
            case 2: return new Coords(-1, 0); 
            case 3: return new Coords(1, 0);  
            default: return new Coords(0, 0);
        }
    }
}