// See https://aka.ms/new-console-template for more information
Player player = new Player();
//Console.WriteLine(player.Dmg);

while (true)
{
    Console.Clear();
    Console.SetCursorPosition(player.X, player.Y);
    Console.WriteLine("S");
    player.Move();
}
