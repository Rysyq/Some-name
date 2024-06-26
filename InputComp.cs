public interface IInputComp
{
    Coords GetDirection(ConsoleKey key);
    Coords GetDirection();
    ConsoleKey GetKeyboardKey();
}
