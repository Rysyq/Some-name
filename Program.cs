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

            // Create enemies for level 1 (level)
            ComposedEnemy composedEnemy = new ComposedEnemy("D", randomPositionComp);
            ComposedEnemy composedEnemy1 = new ComposedEnemy("v", randomPositionComp);

            Coords playerPosition = new Coords(10, 3);
            ComposedPlayer composedPlayer = new ComposedPlayer("S", playerPosition);

            ILevel level = new Level();
            ILevel level2 = new Level2();

            Coords levelOrigin = new Coords(15, 3);
            Coords levelOrigin2 = new Coords(15, 3);

            DisplayLevel(level, levelOrigin);

            while (isPlayerAlive)
            {
                Coords nextPlayerPosition = composedPlayer.Movement.GetNextPosition();
                if (level.IsCoordsCorrect(nextPlayerPosition))
                {
                    composedPlayer.Movement.Move(nextPlayerPosition);

                    level.RedrawCellAt(composedPlayer.Movement.PreviousPosition);
                    level.DrawSomethingAt(composedPlayer.VisualComp.Visual, composedPlayer.PositionComp.Position);

                    HandleHealing(level, nextPlayerPosition, composedPlayer);
                    HandleEnemyMovement(level, composedEnemy, composedEnemy1);
                    HandlePlayerEnemyInteractions(composedPlayer, composedEnemy, composedEnemy1);

                    if (composedPlayer.PositionComp.Position.X == 57 && composedPlayer.PositionComp.Position.Y == 21)
                    {
                        ClearLevel(level, levelOrigin);
                        Console.Clear();

                        // Create new enemies for level 2 (level2)
                        composedEnemy = new ComposedEnemy("D", randomPositionComp);
                        composedEnemy1 = new ComposedEnemy("v", randomPositionComp);

                        DisplayLevel(level2, levelOrigin2);

                        composedPlayer.PositionComp.Position = new Coords(1, 1);

                        while (isPlayerAlive)
                        {
                            nextPlayerPosition = composedPlayer.Movement.GetNextPosition();

                            if (level2.IsCoordsCorrect(nextPlayerPosition))
                            {
                                composedPlayer.Movement.Move(nextPlayerPosition);
                                level2.RedrawCellAt(composedPlayer.Movement.PreviousPosition);
                                level2.DrawSomethingAt(composedPlayer.VisualComp.Visual, composedPlayer.PositionComp.Position);

                                HandleHealing(level2, nextPlayerPosition, composedPlayer);
                                HandleEnemyMovement(level2, composedEnemy, composedEnemy1);
                                HandlePlayerEnemyInteractions(composedPlayer, composedEnemy, composedEnemy1);

                                if (composedPlayer.PositionComp.Position.X == 1 && composedPlayer.PositionComp.Position.Y == 1)
                                {
                                    Console.SetCursorPosition(2, 1);
                                    Console.WriteLine(new string(' ', Console.WindowWidth));
                                    Console.SetCursorPosition(2, 1);
                                    Console.WriteLine("How dare you!");

                                    // Spawn boss only if not already spawned
                                    if (!isBossSpawned)
                                    {
                                        ComposedEnemy bossLichKing = new ComposedEnemy("L", randomPositionComp);
                                        isBossSpawned = true;

                                        while (isPlayerAlive && (composedEnemy.Health.Hp > 0 || composedEnemy1.Health.Hp > 0 || bossLichKing.Health.Hp > 0))
                                        {
                                            nextPlayerPosition = composedPlayer.Movement.GetNextPosition();
                                            if (level2.IsCoordsCorrect(nextPlayerPosition))
                                            {
                                                composedPlayer.Movement.Move(nextPlayerPosition);
                                                level2.RedrawCellAt(composedPlayer.Movement.PreviousPosition);
                                                level2.DrawSomethingAt(composedPlayer.VisualComp.Visual, composedPlayer.PositionComp.Position);

                                                HandleHealing(level2, nextPlayerPosition, composedPlayer);
                                                HandleEnemyMovement(level2, composedEnemy, composedEnemy1, bossLichKing);
                                                HandlePlayerEnemyInteractions(composedPlayer, composedEnemy, composedEnemy1, bossLichKing);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        while (isPlayerAlive)
                                        {
                                            nextPlayerPosition = composedPlayer.Movement.GetNextPosition();
                                            if (level2.IsCoordsCorrect(nextPlayerPosition))
                                            {
                                                composedPlayer.Movement.Move(nextPlayerPosition);
                                                level2.RedrawCellAt(composedPlayer.Movement.PreviousPosition);
                                                level2.DrawSomethingAt(composedPlayer.VisualComp.Visual, composedPlayer.PositionComp.Position);

                                                HandleHealing(level2, nextPlayerPosition, composedPlayer);
                                                HandleEnemyMovement(level2, composedEnemy, composedEnemy1);
                                                HandlePlayerEnemyInteractions(composedPlayer, composedEnemy, composedEnemy1);
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

        static void DisplayLevel(ILevel level, Coords levelOrigin)
        {
            level.GenerateRandomHealingItems(8, 20);
            level.InitializeAllHealingItems();
            level.Display(levelOrigin);
        }

        static void HandleHealing(ILevel level, Coords nextPlayerPosition, ComposedPlayer composedPlayer)
        {
            // Find the healing item position in the list
            for (int i = 0; i < level.HealingItemPositions.Count; i++)
            {
                Coords healingItemPosition = level.HealingItemPositions[i];

                if (nextPlayerPosition != null && healingItemPosition != null &&
                    nextPlayerPosition.X == healingItemPosition.X && nextPlayerPosition.Y == healingItemPosition.Y)
                {
                    composedPlayer.Health.Heal(25);

                    level.HealingItemPositions.RemoveAt(i);

                    level.RedrawCellAt(healingItemPosition);

                    Console.SetCursorPosition(2, 1);
                    Console.WriteLine(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(2, 1);
                    Console.WriteLine($"Player healed! Current health: {composedPlayer.Health.Hp}");
                    Console.ReadKey(true);
                    Console.SetCursorPosition(2, 1);
                    Console.WriteLine(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(2, 1);

                    break;
                }
            }
        }

        static bool CheckTwoCoords(Coords coords1, List<Coords> lista)
        {
            foreach (Coords coords in lista)
            {
                if (coords1 != null && coords != null && coords1.X == coords.X && coords1.Y == coords.Y)
                {
                    return true;
                }
            }
            return false;
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

            //attack

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
            }
        }
    }
}
