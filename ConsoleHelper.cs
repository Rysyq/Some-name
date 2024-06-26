using System;

public static class ConsoleHelper
{
    public static void ClearCurrentConsoleLine(int top)
    {
        Console.SetCursorPosition(0, top);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, top);
    }
}
