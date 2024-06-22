internal class HealthComp
{   public int Hp 
    { 
        get => hp;
        set => hp = Math.Clamp(value, 0, MaxHp);
    }
    int hp = 100;
    public int MaxHp { get; set; } = 100;
}