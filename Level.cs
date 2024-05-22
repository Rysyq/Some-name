public class Level
{
    private string[] levelData;

    public Level()
    {
        levelData = new string[] {
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
"╚══════════════════════════════════════════════════════════════╩══════════════════════════════════════════════════════╝"
};
    }

     public void Display()
    {
        foreach (string row in levelData)
        {
            Console.WriteLine(row);
        }
    }

    public char GetCellAt(Coordinates coords)
    {
        string previousRow = levelData[coords.Y];
        char previousCell = previousRow[coords.X];

        return previousCell;
    }
}