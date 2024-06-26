public class HealthComp
{
    private int hp = 100;

    public int Hp
    {
        get => hp;
        set => hp = Math.Clamp(value, 0, MaxHp);
    }

    public int MaxHp { get; set; } = 100;

    public HealthComp(int initialHp = 100, int maxHp = 100)
    {
        hp = initialHp;
        MaxHp = maxHp;
    }

    public void Heal(int amount)
    {
        hp += amount;
        if (hp > MaxHp)
        {
            hp = MaxHp;
        }

        int currentCursorTop = Console.CursorTop;

        Console.SetCursorPosition(2, 1);
        Console.WriteLine($"Health increased by {amount}. Current health: {hp}");

        Console.ReadKey(true);

        ConsoleHelper.ClearCurrentConsoleLine(1);

        Console.SetCursorPosition(0, currentCursorTop);
    }

    public void GettingDamage(int amount)
    {
        hp -= amount;
        if (hp < 0)
        {
            hp = 0;
        }

        int currentCursorTop = Console.CursorTop;

        Console.SetCursorPosition(2, 1);
        Console.WriteLine($"Health decreased by {amount}. Current health: {hp}");

        Console.ReadKey(true);

        ConsoleHelper.ClearCurrentConsoleLine(1);

        Console.SetCursorPosition(0, currentCursorTop);
    }

    public class HealingItem
    {
        public int HealingAmount { get; private set; }

        public HealingItem(int healingAmount)
        {
            HealingAmount = healingAmount;
        }

        public void Heal(HealthComp healthComp)
        {
            healthComp.Heal(HealingAmount);
        }
    }
}