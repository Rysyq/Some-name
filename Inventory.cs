using System;
using System.Collections.Generic;

public class Inventory
{
    private List<Item> items;

    public Inventory()
    {
        items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        Console.SetCursorPosition(2, 1);
        Console.WriteLine($"{item.Name} added to inventory.");
    }

    public void UseItemFromInventory(int index, ComposedPlayer player)
    {
        if (index >= 0 && index < items.Count)
        {
            items[index].Use(player);
            items.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Invalid item index.");
        }
    }

    public void ShowInventory()
    {
        Console.SetCursorPosition(3, 2);
        Console.WriteLine("Inventory:");
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i}: {items[i].Name}");
        }
    }

    // HandleHealing do Inventory
    public void HandleHealing(ILevel level, Coords nextPlayerPosition, ComposedPlayer composedPlayer)
    {
        for (int i = 0; i < level.HealingItemPositions.Count; i++)
        {
            Coords healingItemPosition = level.HealingItemPositions[i];

            if (nextPlayerPosition != null && healingItemPosition != null &&
                nextPlayerPosition.X == healingItemPosition.X && nextPlayerPosition.Y == healingItemPosition.Y)
            {
                var healingItem = new HealingItem(25);
                composedPlayer.Inventory.AddItem(healingItem);

                level.HealingItemPositions.RemoveAt(i);
                level.RedrawCellAt(healingItemPosition);

                Console.SetCursorPosition(2, 1);
                Console.WriteLine(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(2, 1);
                Console.WriteLine($"Healing item picked up!");
                Console.ReadKey(true);
                Console.SetCursorPosition(2, 1);
                Console.WriteLine(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(2, 1);

                break;
            }
        }
    }

    // Method to handle item usage from player input
    public void HandleItemUsage(ComposedPlayer composedPlayer)
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        if (keyInfo.Key == ConsoleKey.I)
        {
            composedPlayer.Inventory.ShowInventory();
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Choose item to use (number):");
            if (int.TryParse(Console.ReadLine(), out int itemIndex))
            {
                composedPlayer.Inventory.UseItemFromInventory(itemIndex, composedPlayer);
            }
        }
    }
}
