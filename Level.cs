public class Level
{
    public Coords Origin { get; set; }
    public Coords Size { get; }

    private int[][] levelData;

    /// 

    /// 
    private Dictionary<CellTypes, char> cellVisuals = new Dictionary<CellTypes, char>{
        { CellTypes.WallCorner, '■'},
        { CellTypes.WallHorizontal, '═'},
        { CellTypes.WallVertical, '║'},
        { CellTypes.Grass, '.'},
        { CellTypes.Empty, ' '},
        { CellTypes.Cross, '†'},
        {CellTypes.HealingItem, '+'},
    };

    public List<Coords> HealingItemPositions { get; private set; } = new List<Coords>();

    //stąd: https://pl.piliapp.com/symbol/square/
    private Dictionary<CellTypes, ConsoleColor> colorLevel = new Dictionary<CellTypes, ConsoleColor> {
        { CellTypes.WallCorner, ConsoleColor.Yellow},
        { CellTypes.WallHorizontal, ConsoleColor.Yellow},
        { CellTypes.WallVertical, ConsoleColor.Yellow},
        { CellTypes.Grass, ConsoleColor.Green},
        { CellTypes.Empty, ConsoleColor.Black},
        { CellTypes.Cross, ConsoleColor.White},
    };

    private CellTypes[] walkableCellTypes = new CellTypes[] {
        CellTypes.Grass,
        CellTypes.Cross,
        CellTypes.Empty,
        CellTypes.HealingItem
    };



    public Level()
    {
        levelData = new int[][] {
            new []{1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,},
            new []{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,},
            new []{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,},
            new []{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,},
            new []{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,},
            new []{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,},
            new []{3,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,},
            new []{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,},
            new []{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,},
            new []{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,},
            new []{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,},
            new []{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,},
            new []{3,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,},
            new []{3,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,},
            new []{3,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,},
            new []{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,},
            new []{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,},
            new []{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,},
            new []{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,},
            new []{3,0,0,0,0,0,0,0,0,0,0,0,0,0,4,4,0,0,0,4,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,},
            new []{3,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,},
            new []{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,},
            new []{1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,},
        };

        int y = levelData.Length;
        int x = 0;

        foreach (int[] row in levelData)
        {
            if (row.Length > x)
            {
                x = row.Length;
            }
        }

        Size = new Coords(x, y);
        Origin = new Coords(0, 0);

        

        InitializeHealingItems();

    }


    private List<HealingItem> healingItems = new List<HealingItem>();

     public void GenerateRandomHealingItems(int numberOfItems, int healingAmount)
{
    Random random = new Random();

    for (int i = 0; i < numberOfItems; i++)
    {
        Coords randomPosition;
        do
        {
            int x = random.Next(0, Size.X);
            int y = random.Next(0, Size.Y);
            randomPosition = new Coords(x, y);
        } while (!IsCoordsCorrect(randomPosition) || healingItems.Any(item => item.Position.Equals(randomPosition)));

        HealingItem newItem = new HealingItem(randomPosition, healingAmount);
        healingItems.Add(newItem);
        levelData[randomPosition.Y][randomPosition.X] = (int)CellTypes.HealingItem;
    }
}

    public void InitializeHealingItems()
    {
        for (int y = 0; y < levelData.Length; y++)
        {
            for (int x = 0; x < levelData[y].Length; x++)
            {
                if (levelData[y][x] == 8) 
                {
                    HealingItemPositions.Add(new Coords(x, y));
                }
            }
        }
    }

    public bool RemoveHealingItemAt(Coords position)
    {
        for (int i = 0; i < healingItems.Count; i++)
        {
            if (healingItems[i].Position.Equals(position))
            {
                healingItems.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public CellTypes GetCellAt(Coords Coords)
    {
        return GetCellAt(Coords.X, Coords.Y);
    }

    private CellTypes GetCellAt(int x, int y)
    {
        return (CellTypes)levelData[y][x];
    }

    public char GetCellVisualAt(Coords Coords)
    {
        return cellVisuals[GetCellAt(Coords)];
    }

    public void Display(Coords origin)
    {
        Origin = origin;
        Console.CursorTop = origin.Y;

        for (int y = 0; y < levelData.Length; y++)
        {
            Console.CursorLeft = origin.X; 

            for (int x = 0; x < levelData[y].Length; x++)
            {
                var cellValue = GetCellAt(x, y);
                var cellVisual = cellVisuals[cellValue];
                var cellColor = GetCellColorByValue(cellValue);
                Console.ForegroundColor = cellColor;
                Console.Write(cellVisual);
                Console.ResetColor();
            }

            Console.WriteLine(); 
        }
        foreach (var healingItemPosition in HealingItemPositions)
    {
        Console.SetCursorPosition(origin.X + healingItemPosition.X, origin.Y + healingItemPosition.Y);
        Console.Write(cellVisuals[CellTypes.HealingItem]);
    }
    }

    internal bool IsCoordsCorrect(Coords Coords)
    {
        if (Coords.Y >= 0 && Coords.Y < levelData.Length)
        {
            if (Coords.X >= 0 && Coords.X < levelData[Coords.Y].Length)
            {
                if (walkableCellTypes.Contains(GetCellAt(Coords)))
                {
                    return true;
                }
            }
        }

        return false;
    }

    internal void DrawSomethingAt(char visual, Coords position)
    {
        Console.SetCursorPosition(position.X + Origin.X, position.Y + Origin.Y);
        Console.Write(visual);
    }

    internal void DrawSomethingAt(string visual, Coords position)
    {
        Console.SetCursorPosition(position.X + Origin.X, position.Y + Origin.Y);
        Console.Write(visual);
    }

    private ConsoleColor GetCellColorByValue(CellTypes value)
    {
        return colorLevel.GetValueOrDefault(value, ConsoleColor.Black);
    }

    internal void RedrawCellAt(Coords position)
    {
        var cellValue = GetCellAt(position);
        var cellVisual = GetCellVisualAt(position);
        var cellColor = GetCellColorByValue(cellValue);
        Console.ForegroundColor = cellColor;
        DrawSomethingAt(cellVisual, position);
        Console.ResetColor();
    }
}