
public class HealingItem
{
    public Coords Position { get; private set; }
    public int HealingAmount { get; private set; }
    public bool IsPickedUp { get; private set; }

    public HealingItem(Coords position, int healingAmount)
    {
        Position = position;
        HealingAmount = healingAmount;
        IsPickedUp = false;
    }

    // public void Healing(HealthComp healthComp)
    // {
    //     if (!IsPickedUp)
    //     {
    //         healthComp.Heal(80);
    //         IsPickedUp = true;
    //     }
    // }

    
}
