internal class DamageComp
{
    public int Dmg
    {
        get => basicdmg;
        set => basicdmg = Math.Clamp(value, 5, 100);
    }
    int basicdmg = 10;
    int MaxDmg { get; set; } = 100;
    int range = 2;

    int enemyrange = 1;
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

        return (distanceX <= enemyrange && distanceY == 0) || (distanceX == 0 && distanceY <= enemyrange);
    }

    public void Attack(HealthComp targetHealthComp)
    {
        targetHealthComp.GettingDamage(basicdmg);
    }
}