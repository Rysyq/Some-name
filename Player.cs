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

    public Coordinates LastCoords { get; set; }
    public Coordinates PreviousCoords { get; set; }

     private Dictionary<ConsoleKey, Coordinates> directions = new()
    {
        { ConsoleKey.A, new Coordinates(-1, 0)}
    };

    public Player(int x, int y)
    {
        LastCoords = new Coordinates(x, y);
        PreviousCoords = new Coordinates(x, y);
    }

    public Player(Coordinates startingCoords)
    {
        LastCoords = new Coordinates(startingCoords);
        PreviousCoords = new Coordinates(startingCoords);
        directions[ConsoleKey.D] = new Coordinates(1, 0);
        directions[ConsoleKey.W] = new Coordinates(0, -1);
        directions[ConsoleKey.S] = new Coordinates(0, 1);
        directions[ConsoleKey.E] = new Coordinates(1, -1);
    }

    public Coordinates GetNextCoords()
    {
        Coordinates nextCoords = new Coordinates(LastCoords);
        
        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
        
        if (directions.ContainsKey(pressedKey.Key))
        {
            nextCoords.X += directions[pressedKey.Key].X;
            nextCoords.Y += directions[pressedKey.Key].Y;
        }

        return nextCoords;
    }

    public void Move(Coordinates targetCoords)
    {
        PreviousCoords.X = LastCoords.X;
        PreviousCoords.Y = LastCoords.Y;
        
        LastCoords.X = targetCoords.X;
        LastCoords.Y = targetCoords.Y;
    }


//     public int X { get; set; }
//     public int Y { get; set; }

//     public void Move()
//     {
//         ConsoleKeyInfo pressedKey = Console.ReadKey(true);
//         if (pressedKey.Key == ConsoleKey.A)
//         {
//             X -= 1;
//         }
//         else if (pressedKey.Key == ConsoleKey.D)
//         {
//             X += 1;
//         }
//         else if (pressedKey.Key == ConsoleKey.W)
//         {
//             Y -= 1;
//         }
//         else if (pressedKey.Key == ConsoleKey.S)
//         {
//             Y += 1;
//         }
// }
}