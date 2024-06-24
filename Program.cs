

Console.CursorVisible = false;

///

int X = 20;
int Y = 10;

RandomPositionComp randomPositionComp = new RandomPositionComp(X, Y);

Coords randomPosition = randomPositionComp.GenerateRandomPosition();
Coords randomPosition1 = randomPositionComp.GenerateRandomPosition();

ComposedEnemy composedEnemy = new ComposedEnemy("D", randomPositionComp);
ComposedEnemy composedEnemy1 = new ComposedEnemy("v", randomPositionComp);

Coords playerPosition = new Coords(10, 3);
ComposedPlayer composedPlayer = new ComposedPlayer("S", playerPosition);

Level level = new Level();

Coords levelOrigin = new Coords(15, 3);
Console.Clear();
level.GenerateRandomHealingItems(8, 20);
level.InitializeAllHealingItems();

// Console.WriteLine("After initializing healing items:");
// Console.WriteLine($"{level.HealingItemPositions}");
// Console.ReadKey();

if (level.Size.X + levelOrigin.X >= 0 && level.Size.X + levelOrigin.X < Console.BufferWidth
    && level.Size.Y + levelOrigin.Y >= 0 && level.Size.Y + levelOrigin.Y < Console.BufferHeight)
{

    level.Display(levelOrigin);



    level.DrawSomethingAt(composedPlayer.VisualComp.Visual, composedPlayer.PositionComp.Position);
    level.DrawSomethingAt(composedEnemy.VisualComp.Visual, composedEnemy.PositionComp.Position);
    level.DrawSomethingAt(composedEnemy1.VisualComp.Visual, composedEnemy1.PositionComp.Position);



    bool isPlayerAlive = true;

    while (isPlayerAlive)
    {
        // player move
        Coords nextPlayerPosition = composedPlayer.Movement.GetNextPosition();
        if (level.IsCoordsCorrect(nextPlayerPosition))
        {
            composedPlayer.Movement.Move(nextPlayerPosition);

            level.RedrawCellAt(composedPlayer.Movement.PreviousPosition);
            level.DrawSomethingAt(composedPlayer.VisualComp.Visual, composedPlayer.PositionComp.Position);


            //healing thing
            bool CheckTwoCoords(Coords coords1, List<Coords> lista)
            {

                foreach (Coords coords in lista)
                {

                    if (coords1 != null && coords != null)
                    {
                        if (coords1.X == coords.X && coords1.Y == coords.Y)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

            // to sprawdza 

            if (CheckTwoCoords(nextPlayerPosition, level.HealingItemPositions))
            {

                composedPlayer.Health.Heal(100);
                level.RemoveHealingItemAt(composedPlayer.PositionComp.Position);

                level.RedrawCellAt(composedPlayer.PositionComp.Position);

                Console.SetCursorPosition(2, 1);
                Console.WriteLine($"Player healed! Current health: {composedPlayer.Health.Hp}");
                Console.ReadKey();
            }


            // is enemy dead???

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
            else
            {
                Console.SetCursorPosition(2, 0);
                Console.WriteLine("The enemy is dead.                                                                                   ");
                Console.SetCursorPosition(2, 0);
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
            else
            {
                Console.SetCursorPosition(2, 0);
                Console.WriteLine("The enemy 2 is dead.                                                                                  ");
                Console.SetCursorPosition(2, 0);
            }

            // enemy attack
            if (composedEnemy.DamageComp.CanEnemyHitInThisRange(composedPlayer.PositionComp.Position)
                || composedEnemy1.DamageComp.CanEnemyHitInThisRange(composedPlayer.PositionComp.Position))
            {
                Console.SetCursorPosition(2, 0);
                composedEnemy.DamageComp.Attack(composedPlayer.Health);
                composedEnemy1.DamageComp.Attack(composedPlayer.Health);
                Console.SetCursorPosition(2, 0);
                Console.WriteLine($"Player: {composedPlayer.Health}, Enemy: {composedEnemy1.Health}, {composedEnemy1.Health}");
                Console.SetCursorPosition(2, 0);
            }
            else if (composedEnemy.DamageComp.CanEnemyHitInThisRange(composedPlayer.PositionComp.Position))
            {
                Console.SetCursorPosition(2, 0);
                composedEnemy.DamageComp.Attack(composedPlayer.Health);
                Console.SetCursorPosition(2, 0);
                Console.WriteLine($"Player health: {composedPlayer.Health.Hp}, Enemy: {composedEnemy.Health}                                                         ");
                Console.SetCursorPosition(2, 0);
            }
            else if (composedEnemy1.DamageComp.CanEnemyHitInThisRange(composedPlayer.PositionComp.Position))
            {
                Console.SetCursorPosition(2, 0);
                composedEnemy1.DamageComp.Attack(composedPlayer.Health);
                Console.SetCursorPosition(2, 0);
                Console.WriteLine($"Player health: {composedPlayer.Health.Hp}, Enemy: {composedEnemy1.Health}                                                        ");
                Console.SetCursorPosition(2, 0);
            }
            else
            {
                Console.SetCursorPosition(2, 0);
                Console.WriteLine("                                                                                                                                                 ");
                Console.SetCursorPosition(2, 0);
            }

            //player attack
            if (composedPlayer.DamageComp.CanHitInThisRange(composedEnemy.PositionComp.Position)
                && composedPlayer.DamageComp.CanHitInThisRange(composedEnemy1.PositionComp.Position))
            {
                Console.SetCursorPosition(2, 0);
                Console.WriteLine($"Enemy with health nearby!                                                                   ");
                Console.ReadKey(true);
                Console.SetCursorPosition(2, 0);
                composedPlayer.DamageComp.Attack(composedEnemy.Health);
                composedPlayer.DamageComp.Attack(composedEnemy1.Health);
                Console.SetCursorPosition(2, 0);
                Console.WriteLine($"Player: {composedPlayer.Health.Hp}, Enemy: {composedEnemy.Health.Hp}, and Enemy 2: {composedEnemy1.Health.Hp}");
                Console.SetCursorPosition(2, 0);
            }
            else if (composedPlayer.DamageComp.CanHitInThisRange(composedEnemy.PositionComp.Position))
            {
                Console.SetCursorPosition(2, 0);
                Console.WriteLine($"Enemy with health nearby!                                                                    ");
                Console.ReadKey(true);
                Console.SetCursorPosition(2, 0);
                composedPlayer.DamageComp.Attack(composedEnemy.Health);
                Console.SetCursorPosition(2, 0);
                Console.WriteLine($"Player: {composedPlayer.Health.Hp}, Enemy: {composedEnemy.Health.Hp}                                                         ");
                Console.SetCursorPosition(2, 0);
            }
            else if (composedPlayer.DamageComp.CanHitInThisRange(composedEnemy1.PositionComp.Position))
            {
                Console.SetCursorPosition(2, 0);
                Console.WriteLine($"Enemy with health nearby!                                                                        ");
                Console.ReadKey(true);
                Console.SetCursorPosition(2, 0);
                composedPlayer.DamageComp.Attack(composedEnemy1.Health);
                Console.SetCursorPosition(2, 0);
                Console.WriteLine($"Player: {composedPlayer.Health.Hp},Enemy 2: {composedEnemy1.Health.Hp}                                                        ");
                Console.SetCursorPosition(2, 0);
            }
            else
            {
                Console.SetCursorPosition(2, 0);
                Console.WriteLine("                                                                                                                                                 ");
                Console.SetCursorPosition(2, 0);
            }

            // is player dead???
            if (composedPlayer.Health.Hp <= 0)
            {
                Console.SetCursorPosition(2, 0);
                Console.WriteLine("The player is dead.                                                                                 ");
                isPlayerAlive = false;
                Console.SetCursorPosition(2, 0);
                Console.ReadKey();
            }
        }
    }
}
else
{
    Console.WriteLine("Terminal window is too small, make it bigger");
}


