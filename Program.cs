// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using System.Security;

Console.CursorVisible = false;

Coords playerPosition = new Coords(10, 3);

ComposedPlayer composedPlayer = new ComposedPlayer("S", playerPosition);


Level level = new Level();
Coords levelOrigin = new Coords(15, 3);
Console.Clear();
ConsoleKeyInfo pressedKey = Console.ReadKey(true);



level.Display(levelOrigin);

level.DrawSomethingAt(composedPlayer.VisualComp.Visual, composedPlayer.PositionComp.Position);


while (true)
{
    if (pressedKey.Key == ConsoleKey.K)
    {

        Console.WriteLine("Damage!");

    }
    Coords nextPosition = composedPlayer.Move.GetNextPosition();
    if (level.IsCoordsCorrect(nextPosition))
    {
        composedPlayer.Move.Move(nextPosition);

        level.RedrawCellAt(composedPlayer.Move.PreviousPosition);
        level.DrawSomethingAt(composedPlayer.VisualComp.Visual, composedPlayer.PositionComp.Position);
    }
}
