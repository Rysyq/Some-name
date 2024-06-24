
internal class HealthComp
{
    public int Hp
    {
        get => hp;
        set => hp = Math.Clamp(value, 0, MaxHp);
    }
    int hp = 100;
    public int MaxHp { get; set; } = 100;

    public void Heal(int amount)
    {
        Console.SetCursorPosition(2, 1);

        Console.WriteLine("You have used a potion!                                                                             ");

        hp += amount;
        if (hp > MaxHp)
        {
            hp = MaxHp;
        }
    }

    public void GettingDamage(int amount)
    {

        hp -= amount;
        if (hp < 0)
        {
            hp = 0;
        }
    }

    public class HealingItem
    {
        public void Healing(HealthComp healthComp)
        {
            healthComp.Heal(30);
        }
    }
}
