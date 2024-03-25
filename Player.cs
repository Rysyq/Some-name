class Player
{
    //hp -  patrz properities; => - skrót 
    public int Hp
    {
        get => hp;
        set => hp = Math.Clamp(value, 0, MaxHp);
    }
    int hp = 100;
    int MaxHp {get; set; } = 100;
}