internal class DamageComp
{
    public int Dmg
    {
        get => basicdmg;
        set => basicdmg = Math.Clamp(value, 5, 120);
    }
    int basicdmg = 5;
    int MaxDmg { get; set; } = 120;
}