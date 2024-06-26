using System;
using System.Collections.Generic;

namespace GameNamespace
{
    class Program
    {
        static bool isPlayerAlive = true;
        static bool isBossSpawned = false;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            int X = 20;
            int Y = 10;

            RandomPositionComp randomPositionComp = new RandomPositionComp(X, Y);

            Coords randomPosition = randomPositionComp.GenerateRandomPosition();
            Coords randomPosition1 = randomPositionComp.GenerateRandomPosition();

            // level 1 enemies only
            ComposedEnemy composedEnemy = new ComposedEnemy("D", randomPositionComp);
            ComposedEnemy composedEnemy1 = new ComposedEnemy("v", randomPositionComp);

            Coords playerPosition = new Coords(10, 3);
            ComposedPlayer composedPlayer = new ComposedPlayer("S", playerPosition);

            ILevel level = new Level();
            ILevel level2 = new Level2();

            Coords levelOrigin = new Coords(15, 3);
            Coords levelOrigin2 = new Coords(15, 3);

            DisplayLevel(level, levelOrigin, composedPlayer);

            while (isPlayerAlive)
            {
                ConsoleKey pressedKeyboardKey = composedPlayer.InputComp.GetKeyboardKey();
                Coords nextPlayerPosition = composedPlayer.Movement.GetNextPosition(pressedKeyboardKey);
                if (level.IsCoordsCorrect(nextPlayerPosition))
                {
                    composedPlayer.Movement.Move(nextPlayerPosition);

                    level.RedrawCellAt(composedPlayer.Movement.PreviousPosition);
                    level.DrawSomethingAt(composedPlayer.VisualComp.Visual, composedPlayer.PositionComp.Position);

                    HandleHealing(level, nextPlayerPosition, composedPlayer);
                    HandleEnemyMovement(level, composedEnemy, composedEnemy1);
                    HandlePlayerEnemyInteractions(composedPlayer, composedEnemy, composedEnemy1);

                    HandleItemUsage(composedPlayer, pressedKeyboardKey); // uzywanie przedmiotow

                    if (composedPlayer.PositionComp.Position.X == 57 && composedPlayer.PositionComp.Position.Y == 21)
                    {
                        ClearLevel(level, levelOrigin);
                        Console.Clear();

                        // level 2 enemies only
                        composedEnemy = new ComposedEnemy("D", randomPositionComp);
                        composedEnemy1 = new ComposedEnemy("v", randomPositionComp);

                        DisplayLevel(level2, levelOrigin2, composedPlayer);

                        composedPlayer.PositionComp.Position = new Coords(1, 1);

                        while (isPlayerAlive)
                        {
                            pressedKeyboardKey = composedPlayer.InputComp.GetKeyboardKey();
                            nextPlayerPosition = composedPlayer.Movement.GetNextPosition(pressedKeyboardKey);

                            if (level2.IsCoordsCorrect(nextPlayerPosition))
                            {
                                composedPlayer.Movement.Move(nextPlayerPosition);
                                level2.RedrawCellAt(composedPlayer.Movement.PreviousPosition);
                                level2.DrawSomethingAt(composedPlayer.VisualComp.Visual, composedPlayer.PositionComp.Position);

                                HandleHealing(level2, nextPlayerPosition, composedPlayer);
                                HandleEnemyMovement(level2, composedEnemy, composedEnemy1);
                                HandlePlayerEnemyInteractions(composedPlayer, composedEnemy, composedEnemy1);

                                HandleItemUsage(composedPlayer, pressedKeyboardKey); // uzywanie przedmiotow

                                if (composedPlayer.PositionComp.Position.X == 1 && composedPlayer.PositionComp.Position.Y == 1)
                                {
                                    Console.SetCursorPosition(2, 1);
                                    Console.WriteLine(new string(' ', Console.WindowWidth));
                                    Console.SetCursorPosition(2, 1);
                                    Console.WriteLine("The portal seems do not work...");

                                    // najpierw kill all
                                    if (composedEnemy.Health.Hp <= 0 && composedEnemy1.Health.Hp <= 0 && !isBossSpawned)
                                    {
                                        Console.SetCursorPosition(2, 1);
                                        Console.WriteLine(new string(' ', Console.WindowWidth));
                                        Console.SetCursorPosition(2, 1);
                                        Console.WriteLine("How dare you!");

                                        ComposedEnemy bossLichKing = new ComposedEnemy("L", randomPositionComp);

                                        bossLichKing.Health.Hp = 200;

                                        bossLichKing.DamageComp.Dmg = 25;

                                        isBossSpawned = true;

                                        while (isPlayerAlive && (composedEnemy.Health.Hp > 0 || composedEnemy1.Health.Hp > 0 || bossLichKing.Health.Hp > 0))
                                        {
                                            pressedKeyboardKey = composedPlayer.InputComp.GetKeyboardKey();
                                            nextPlayerPosition = composedPlayer.Movement.GetNextPosition(pressedKeyboardKey);
                                            if (level2.IsCoordsCorrect(nextPlayerPosition))
                                            {
                                                composedPlayer.Movement.Move(nextPlayerPosition);
                                                level2.RedrawCellAt(composedPlayer.Movement.PreviousPosition);
                                                level2.DrawSomethingAt(composedPlayer.VisualComp.Visual, composedPlayer.PositionComp.Position);

                                                HandleHealing(level2, nextPlayerPosition, composedPlayer);
                                                HandleEnemyMovement(level2, composedEnemy, composedEnemy1, bossLichKing);
                                                HandlePlayerEnemyInteractions(composedPlayer, composedEnemy, composedEnemy1, bossLichKing);

                                                HandleItemUsage(composedPlayer, pressedKeyboardKey); // Obsługa używania przedmiotów z ekwipunku

                                                if (bossLichKing.Health.Hp == 0)
                                                {
                                                    Console.SetCursorPosition(2, 1);
                                                    Console.WriteLine("You have killed the Lich King!");
                                                    Console.ReadKey();
                                                    return;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        while (isPlayerAlive)
                                        {
                                            pressedKeyboardKey = composedPlayer.InputComp.GetKeyboardKey();
                                            nextPlayerPosition = composedPlayer.Movement.GetNextPosition(pressedKeyboardKey);
                                            if (level2.IsCoordsCorrect(nextPlayerPosition))
                                            {
                                                composedPlayer.Movement.Move(nextPlayerPosition);
                                                level2.RedrawCellAt(composedPlayer.Movement.PreviousPosition);
                                                level2.DrawSomethingAt(composedPlayer.VisualComp.Visual, composedPlayer.PositionComp.Position);

                                                HandleHealing(level2, nextPlayerPosition, composedPlayer);
                                                HandleEnemyMovement(level2, composedEnemy, composedEnemy1);
                                                HandlePlayerEnemyInteractions(composedPlayer, composedEnemy, composedEnemy1);

                                                HandleItemUsage(composedPlayer, pressedKeyboardKey); // Obsługa używania przedmiotów z ekwipunku
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        static void ClearLevel(ILevel level, Coords levelOrigin)
        {
            for (int y = 0; y < level.Size.Y; y++)
            {
                for (int x = 0; x < level.Size.X; x++)
                {
                    Console.SetCursorPosition(levelOrigin.X + x, levelOrigin.Y + y);
                    Console.Write(" ");
                }
            }
        }

        static void DisplayLevel(ILevel level, Coords levelOrigin, ComposedPlayer composedPlayer)
        {
            level.GenerateRandomHealingItems(8, 20);
            level.InitializeAllHealingItems();
            level.Display(levelOrigin);

            // Aktualizacja pozycji gracza na ekranie
            level.DrawSomethingAt(composedPlayer.VisualComp.Visual, composedPlayer.PositionComp.Position);
        }

        static void HandleHealing(ILevel level, Coords nextPlayerPosition, ComposedPlayer composedPlayer)
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

        static void HandleEnemyMovement(ILevel level, ComposedEnemy composedEnemy, ComposedEnemy composedEnemy1, ComposedEnemy bossLichKing = null)
        {
            if (composedEnemy.Health.Hp > 0)
            {
                Coords nextEnemyPosition = composedEnemy.Movement.GetNextPosition();
                if (level.IsCoordsCorrect(nextEnemyPosition))
                {
                    composedEnemy.Movement.Move(nextEnemyPosition);
                    level.RedrawCellAt(composedEnemy.Movement.PreviousPosition);
                    level.DrawSomethingAt(composedEnemy.VisualComp.Visual, composedEnemy.PositionComp.Position);
                }
            }

            if (composedEnemy1.Health.Hp > 0)
            {
                Coords nextEnemy1Position = composedEnemy1.Movement.GetNextPosition();
                if (level.IsCoordsCorrect(nextEnemy1Position))
                {
                    composedEnemy1.Movement.Move(nextEnemy1Position);
                    level.RedrawCellAt(composedEnemy1.Movement.PreviousPosition);
                    level.DrawSomethingAt(composedEnemy1.VisualComp.Visual, composedEnemy1.PositionComp.Position);
                }
            }

            if (bossLichKing != null && bossLichKing.Health.Hp > 0)
            {
                Coords nextBossPosition = bossLichKing.Movement.GetNextPosition();
                if (level.IsCoordsCorrect(nextBossPosition))
                {
                    bossLichKing.Movement.Move(nextBossPosition);
                    level.RedrawCellAt(bossLichKing.Movement.PreviousPosition);
                    level.DrawSomethingAt(bossLichKing.VisualComp.Visual, bossLichKing.PositionComp.Position);
                }
            }
        }

        static void HandlePlayerEnemyInteractions(ComposedPlayer composedPlayer, ComposedEnemy composedEnemy, ComposedEnemy composedEnemy1, ComposedEnemy bossLichKing = null)
        {
            if (composedPlayer.Health.Hp <= 0)
            {
                Console.SetCursorPosition(2, 1);
                Console.WriteLine(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(2, 1);
                Console.WriteLine("The player is dead.");
                isPlayerAlive = false;
                Console.SetCursorPosition(2, 1);
                Console.ReadKey(true);
                return;
            }

            //enemy and boss attack

            if (composedEnemy.Health.Hp > 0)
            {
                if (composedEnemy.DamageComp.CanEnemyHitInThisRange(composedPlayer.PositionComp.Position))
                {
                    composedEnemy.DamageComp.Attack(composedPlayer.Health);
                    Console.SetCursorPosition(2, 1);
                    Console.WriteLine(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(2, 1);
                    Console.WriteLine($"Player: {composedPlayer.Health.Hp}, Enemy: {composedEnemy.Health.Hp}, Enemy 2: {composedEnemy1.Health.Hp}");
                }
            }

            if (composedEnemy1.Health.Hp > 0)
            {
                if (composedEnemy1.DamageComp.CanEnemyHitInThisRange(composedPlayer.PositionComp.Position))
                {
                    composedEnemy1.DamageComp.Attack(composedPlayer.Health);
                    Console.SetCursorPosition(2, 1);
                    Console.WriteLine(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(2, 1);
                    Console.WriteLine($"Player: {composedPlayer.Health.Hp}, Enemy: {composedEnemy.Health.Hp}, Enemy 2: {composedEnemy1.Health.Hp}");
                }
            }

            if (bossLichKing != null && bossLichKing.Health.Hp > 0)
            {
                if (bossLichKing.DamageComp.CanEnemyHitInThisRange(composedPlayer.PositionComp.Position))
                {
                    bossLichKing.DamageComp.Attack(composedPlayer.Health);
                    Console.SetCursorPosition(2, 1);
                    Console.WriteLine(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(2, 1);
                    Console.WriteLine($"Lich King attacks! Player HP: {composedPlayer.Health.Hp}");
                }
            }

            // player attack

            if (composedPlayer.Health.Hp > 0)
            {
                if (composedPlayer.DamageComp.CanHitInThisRange(composedEnemy.PositionComp.Position))
                {
                    composedPlayer.DamageComp.Attack(composedEnemy.Health);
                    Console.SetCursorPosition(2, 1);
                    Console.WriteLine(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(2, 1);
                    Console.WriteLine($"Player: {composedPlayer.Health.Hp}, Enemy: {composedEnemy.Health.Hp}, Enemy 2: {composedEnemy1.Health.Hp}");
                }

                if (composedPlayer.DamageComp.CanHitInThisRange(composedEnemy1.PositionComp.Position))
                {
                    composedPlayer.DamageComp.Attack(composedEnemy1.Health);
                    Console.SetCursorPosition(2, 1);
                    Console.WriteLine(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(2, 1);
                    Console.WriteLine($"Player: {composedPlayer.Health.Hp}, Enemy: {composedEnemy.Health.Hp}, Enemy 2: {composedEnemy1.Health.Hp}");
                }

                if (bossLichKing != null && bossLichKing.Health.Hp > 0)
                {
                    if (composedPlayer.DamageComp.CanHitInThisRange(bossLichKing.PositionComp.Position))
                    {
                        composedPlayer.DamageComp.Attack(bossLichKing.Health);
                        Console.SetCursorPosition(2, 1);
                        Console.WriteLine(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(2, 1);
                        Console.WriteLine($"Player attacks Lich King! Lich King HP: {bossLichKing.Health.Hp}");
                    }
                }
            }
        }

        static void HandleItemUsage(ComposedPlayer composedPlayer, ConsoleKey key)
        {
            if (key == ConsoleKey.I)
            {
                composedPlayer.Inventory.ShowInventory();
                Console.SetCursorPosition(2, 1);
                Console.WriteLine("Choose item to use (number):");
                if (int.TryParse(Console.ReadLine(), out int itemIndex))
                {
                    composedPlayer.Inventory.UseItemFromInventory(itemIndex, composedPlayer);
                }
            }
        }
    }
}
