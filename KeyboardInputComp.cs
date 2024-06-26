using System.ComponentModel;

internal class KeyboardInputComp : IInputComp
{    
    private Dictionary<ConsoleKey, Coords> directions;
    
    public KeyboardInputComp()
    {
        directions = new()
        {
            [ConsoleKey.A] = new Coords(-1, 0),
            [ConsoleKey.D] = new Coords(1, 0),
            [ConsoleKey.W] = new Coords(0, -1),
            [ConsoleKey.S] = new Coords(0, 1),
        };   
    }
    public Coords GetDirection(ConsoleKey key)
    {
        Coords nextPosition = new Coords(0, 0);
        
        if (directions.ContainsKey(key))
        {
            nextPosition.X = directions[key].X;
            nextPosition.Y = directions[key].Y;
        }

        return nextPosition;
    }

    public Coords GetDirection()
    {
        Coords nextPosition = new Coords(0, 0);

        return nextPosition;
    }

    public ConsoleKey GetKeyboardKey()
    {
        return Console.ReadKey(true).Key;
    }
}