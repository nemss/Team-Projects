﻿namespace TheTieSilincer.Models.Bullets
{
    using System;
    using System.Collections.Generic;
    using TheTieSilincer.Enums;

    public class PlayerRocket : Bullet
    {
        private const char bulletType = '↑';

        private const BulletType rocket = BulletType.PlayerRocket;

        public PlayerRocket(Position position) : base(position, rocket)
        {
        }

        public void UpdatePositionByY(List<Position> positions)
        {
            Position nearestPoint = null;
            double dis = double.MaxValue;

            if (positions != null)
            {
                foreach (var pos in positions)
                {
                    double d = Math.Sqrt((this.Position.X - pos.X) * (this.Position.X - pos.X)
                        + (this.Position.Y - pos.Y) * (this.Position.Y - pos.Y));

                    if (d < dis)
                    {
                        dis = d;
                        nearestPoint = pos;
                    }
                }

                if (nearestPoint != null)
                {
                    if (nearestPoint.Y < Position.Y)
                    {
                        this.PreviousPosition = new Position(this.Position.X, this.Position.Y);
                        this.Position.Y--;
                    }
                    else
                    {
                        this.PreviousPosition = new Position(this.Position.X, this.Position.Y);
                        this.Position.Y++;
                    }
                }
            }
        }

        public override void Draw()
        {
            Console.SetCursorPosition(Position.Y, Position.X);
            Console.WriteLine(bulletType);
        }

        public override bool InBounds()
        {
            if (Position.X > 0)
            {
                return true;
            }

            return false;
        }

        public override void Update()
        {
            this.Position.X--;
        }
    }
}