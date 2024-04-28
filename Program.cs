// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using System.Security;

Player player = new Player();

string[] level = {
"╔═════════════╦════════════════════════════════════════════════╦══════════════════════════════════════════════════════╗",
"║             ║                                                ║                                                      ║",
"║             ║                                                ║                                                      ║",
"║             ║                                                ║                                                      ║",
"║             ║                                                ║                                                      ║",
"║                                                              ║                                                      ║",
"║                                                              ║                                                      ║",
"║                                                              ║                                                      ║",
"║                                                              ║                                                      ║",
"║                                                              ║                                                      ║",
"║                                                              ║                                                      ║",
"║                                                              ║                                                      ║",
"║                                                              ║                                                      ║",
"║                                                              ║                                                      ║",
"║                                                                                                                     ║",
"║                                                                                                                     ║",
"║                                                              ║                                                      ║",
"║                                                              ║                                                      ║",
"║                                                              ║                                                      ║",
"║                                                              ║                                                      ║",
"╚══════════════════════════════════════════════════════════════╩══════════════════════════════════════════════════════╝",
};

foreach (string wall in level)
{
    Console.WriteLine(wall);
}

player.X = 4;
player.Y = 2;

int x = 4;
int y = 2;
int oldX;
int oldY;
string obstacle = "═║╩";
string logicChars = "A";
ConsoleKey PlayerInput;

Console.CursorVisible = false;
while (true)
{
    oldY = y;
    oldX = x;

    PlayerInput = Console.ReadKey(true).Key;
    player.Move();
    Console.SetCursorPosition(player.X, player.Y);
    Console.WriteLine("S");
    UpdatePos();
}

void UpdatePos()
{
    player.Move();

    if (logicChars.Contains(level[x][y]))
    {
        Console.Clear();
        Console.WriteLine("You Won !!!");
    }
    else if (!(obstacle.Contains(level[x][y])))
    {
        Console.SetCursorPosition(oldY, oldX);
        Console.Write(" ");

        Console.SetCursorPosition(y, x);
        Console.Write("S");
    }
    else 
    {
        x = oldX;
        y = oldY;
    }
}

//aby zrobić to poniżej - coordy, coordy do movementu - przerobienie poruszania 
//poruszanie done > pozycja, a mapa, żeby nie zżerało - map tu może być, I quess 
//skoro i tak jest potrzebny X i Y, aby była poprzednia pozycja to równie dobrze można wrzucić to w osobną klasę

//o co chodzi dół >

// /int row = 1;
// int col = 1;
// int oldRow;
// int oldCol;
// ConsoleKey playerInput;
// string obstacle = "WP5";
// string logicChars = "A";

// string[] map =
// {
//     "WWWWWWWWW",
//     "W     A W",
//     "W       W",
//     "W   WWWWW",
//     "W   W",
//     "W   W",
//     "WWWWW",

// };
// InitializeMap(map);
// InitializeplayerAvatar();
// Console.CursorVisible = false;

// while (true)
// {
//     oldCol = col;
//     oldRow = row;

//     playerInput = Console.ReadKey(true).Key;
//     UpdatePos(playerInput);
    
    

// }

// void UpdatePos(ConsoleKey toCoNacisnalGracz)
// {
//     switch (toCoNacisnalGracz)
//     {
//         case ConsoleKey.W: row--; break;
//         case ConsoleKey.S: row++; break;
//         case ConsoleKey.A: col--; break;
//         case ConsoleKey.D: col++; break;
//     }

//     if (logicChars.Contains(map[row][col]))
//     {
//         Console.Clear();
//         Console.WriteLine("You Won !!!");
//     }
//     else if (!(obstacle.Contains(map[row][col])))
//     {
//         Console.SetCursorPosition(oldCol, oldRow);
//         Console.Write(" ");
        
//         Console.SetCursorPosition(col, row);
//         Console.Write("#");
//     }
//     else 
//     {
//         row = oldRow;
//         col = oldCol;
//     }

// }

// void Movement()
// {

// }

// void InitializeplayerAvatar()
// {
//     Console.SetCursorPosition(col, row);
//     Console.Write("#");

// }

// void InitializeMap(string[] mapToPrint)
// {
//     Console.Clear();
//     foreach( string row in mapToPrint)
//     {
//         Console.WriteLine(row);
//     }
// }