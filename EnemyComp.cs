
class ComposedEnemy
{
    public VisualComp VisualComp { get; }
    public HealthComp Health { get; }
    public PositionComp PositionComp { get; }
    public MoveComp Movement { get; }
    public IInputComp InputComp { get; }
    public DamageComp DamageComp { get; }

    public RandomPositionComp RandomPosition { get; }

    public ComposedEnemy(string visual, RandomPositionComp randomPositionComp)
    {

        Coords randomPosition = randomPositionComp.GenerateRandomPosition();

        VisualComp = new VisualComp(visual);
        Health = new HealthComp();
        PositionComp = new PositionComp(randomPosition);
        InputComp = new RandomInputComp();
        Movement = new MoveComp(PositionComp, InputComp);
        DamageComp = new DamageComp(PositionComp);
    }

//this do not reallly wokr for now >>>>
    public void SetHealth(int health)
    {
        Health.Hp = health;
    }

    public void SetDamage(int newDamage)
    {
        DamageComp.Dmg = newDamage;
    }

}

