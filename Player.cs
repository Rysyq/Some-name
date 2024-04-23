using System.Security.Cryptography.X509Certificates;

class Player
{
    //hp -  patrz properities; => - skrót 
    public int Hp
    {
        get => hp;
        set => hp = Math.Clamp(value, 0, MaxHp);
    }
    int hp = 100;
    int MaxHp { get; set; } = 100;

    public int Dmg
    {
        get => basicdmg;
        set => basicdmg = Math.Clamp(value, 5, 120);
    }
    int basicdmg = 5;
    int MaxDmg { get; set; } = 120;
    //trzeba będzie trochę przebudować dmg, jak już będą itemy od dmg - na chwilę obecną jest tak

    public int X { get; set; }
    public int Y { get; set; }

    public void Move()
    {
        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
        if (pressedKey.Key == ConsoleKey.A)
        {
            X -= 1;
        }
        else if (pressedKey.Key == ConsoleKey.D)
        {
            X += 1;
        }
        else if (pressedKey.Key == ConsoleKey.W)
        {
            Y -= 1;
        }
        else if (pressedKey.Key == ConsoleKey.S)
        {
            Y += 1;
        }
}
}