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
    public Coords GetDirection()
    {
        Coords nextPosition = new Coords(0, 0);
        
        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
        if (directions.ContainsKey(pressedKey.Key))
        {
            nextPosition.X = directions[pressedKey.Key].X;
            nextPosition.Y = directions[pressedKey.Key].Y;
        }

        return nextPosition;
    }
}