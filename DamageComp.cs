public class DamageComp
{
    public int Dmg
    {
        get => basicDmg;
        set => basicDmg = Math.Clamp(value, 5, MaxDmg);
    }
    private int basicDmg = 10;
    public int MaxDmg { get; set; } = 100;
    private int range = 2;
    private int enemyRange = 1;
    private readonly PositionComp positionComp;

    public DamageComp(PositionComp positionComp)
    {
        this.positionComp = positionComp;
    }

    public bool CanHitInThisRange(Coords targetPosition)
    {
        int distanceX = Math.Abs(positionComp.Position.X - targetPosition.X);
        int distanceY = Math.Abs(positionComp.Position.Y - targetPosition.Y);

        return (distanceX <= range && distanceY == 0) || (distanceX == 0 && distanceY <= range);
    }

    public bool CanEnemyHitInThisRange(Coords targetPosition)
    {
        int distanceX = Math.Abs(positionComp.Position.X - targetPosition.X);
        int distanceY = Math.Abs(positionComp.Position.Y - targetPosition.Y);

        return (distanceX <= enemyRange && distanceY == 0) || (distanceX == 0 && distanceY <= enemyRange);
    }

    public void Attack(HealthComp targetHealthComp)
    {
        targetHealthComp.GettingDamage(basicDmg);
    }
}
