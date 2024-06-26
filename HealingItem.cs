public class HealingItem : Item
{
    public Coords Position { get; private set; }
    public int HealingAmount { get; private set; }
    public bool IsPickedUp { get; private set; }

    public HealingItem(Coords position, int healingAmount)
        : base("Healing Item")
    {
        Position = position;
        HealingAmount = healingAmount;
        IsPickedUp = false;
    }

    public HealingItem(int healingAmount)
        : base("Healing Item")
    {
        Position = new Coords(0, 0);
        HealingAmount = healingAmount;
        IsPickedUp = false;
    }

    public override void Use(ComposedPlayer player)
    {
        if (!IsPickedUp)
        {
            player.Health.Heal(HealingAmount);
            IsPickedUp = true;

            int currentCursorTop = Console.CursorTop;
            int currentCursorLeft = Console.CursorLeft;

            Console.WriteLine($"{Name} used. {HealingAmount} health restored.");

            Console.ReadKey(true);

            ConsoleHelper.ClearCurrentConsoleLine(currentCursorTop);

            Console.SetCursorPosition(currentCursorLeft, currentCursorTop);

            ConsoleHelper.ClearCurrentConsoleLine(currentCursorTop - 1);
        }
    }
}
