﻿namespace TheTieSilincer.Models
{
    using System;
    using System.Collections.Generic;
    using TheTieSilincer.Enums;
    using TheTieSilincer.Models.Weapons;
    using TheTieSilincer.Support;

    public class PlayerShip : Ship
    {
        private Position nextPosition;

        public PlayerShip(List<Weapon> weapons) : base(weapons)
        {
            this.ShipType = ShipType.PlayerShip;
            this.Position = new Position(Constants.WindowHeight - 8, Constants.WindowWidth / 3 + 5);
            this.CollisionAOE = 3;
            this.Armor = 999;
        }

        public override void Clear()
        {
            if (PreviousPosition != null)
            {
                Console.SetCursorPosition(PreviousPosition.Y + 4, PreviousPosition.X);
                Console.WriteLine(" ");
                Console.SetCursorPosition(PreviousPosition.Y + 4, PreviousPosition.X + 1);
                Console.WriteLine(" ");
                Console.SetCursorPosition(PreviousPosition.Y + 3, PreviousPosition.X + 2);
                Console.WriteLine("   ");
                Console.SetCursorPosition(PreviousPosition.Y, PreviousPosition.X + 3);
                Console.WriteLine("         ");
                Console.SetCursorPosition(PreviousPosition.Y, PreviousPosition.X + 4);
                Console.WriteLine("         ");
            }
        }

        public override void ClearCurrentPosition()
        {
            Console.SetCursorPosition(Position.Y + 4, Position.X);
            Console.WriteLine(" ");
            Console.SetCursorPosition(Position.Y + 4, Position.X + 1);
            Console.WriteLine(" ");
            Console.SetCursorPosition(Position.Y + 3, Position.X + 2);
            Console.WriteLine("   ");
            Console.SetCursorPosition(Position.Y, Position.X + 3);
            Console.WriteLine("         ");
            Console.SetCursorPosition(Position.Y, Position.X + 4);
            Console.WriteLine("         ");
        }

        public override void Draw()
        {
            Console.SetCursorPosition(Position.Y + 4, Position.X);
            Console.WriteLine(@"^");
            Console.SetCursorPosition(Position.Y + 4, Position.X + 1);
            Console.WriteLine("o");
            Console.SetCursorPosition(Position.Y + 3, Position.X + 2);
            Console.WriteLine(@"|o|");
            Console.SetCursorPosition(Position.Y, Position.X + 3);
            Console.WriteLine(@"/\\\o///\");
            Console.SetCursorPosition(Position.Y, Position.X + 4);
            Console.WriteLine(@"  </o\>  ");
        }

        public override bool InBounds()
        {
            if (NextDirection == null) return false;
            nextPosition = new Position
               (Position.X + NextDirection.X, Position.Y + NextDirection.Y * 2);

            if (nextPosition.X > Constants.WindowHeight - 7 || nextPosition.Y > Constants.WindowWidth - 9 ||
                nextPosition.X < 0 || nextPosition.Y < 0)
            {
                return false;
            }

            return true;
        }

        public override void Update()
        {
            if (InBounds())
            {
                this.PreviousPosition = this.Position;
                this.Position = nextPosition;
            }
        }
    }
}