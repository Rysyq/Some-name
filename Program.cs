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

while (true)
{
    Console.SetCursorPosition(player.X, player.Y);
    Console.WriteLine("S");
    player.Move();
}