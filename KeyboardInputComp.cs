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
}