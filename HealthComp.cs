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
        Console.SetCursorPosition(2, 1);
        Console.WriteLine($"Health increased by {amount}. Current health: {hp}");
    }

    public void GettingDamage(int amount)
    {
        hp -= amount;
        if (hp < 0)
        {
            hp = 0;
        }
        Console.SetCursorPosition(2, 1);
        Console.WriteLine($"Health decreased by {amount}. Current health: {hp}");
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
