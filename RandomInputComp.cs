class RandomInputComp : IInputComp
{
    Random rng;

    public RandomInputComp()
    {
        rng = new Random();
    }
    
    public Coords GetDirection()
    {
        return new Coords(rng.Next(-1, 2),  rng.Next(-1, 2));
    }
}