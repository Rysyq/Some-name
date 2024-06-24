

public interface ILevel
{
    Coords Size { get; }
    List<Coords> HealingItemPositions { get; }
    void GenerateRandomHealingItems(int count, int maxSize);
    void InitializeAllHealingItems();
    void Display(Coords origin);
    void RedrawCellAt(Coords position);
    void DrawSomethingAt(string visual, Coords position);
    bool IsCoordsCorrect(Coords coords);
    void RemoveHealingItemAt(Coords position);
}
