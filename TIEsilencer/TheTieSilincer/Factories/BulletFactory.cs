﻿namespace TheTieSilincer.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using TheTieSilincer.Enums;
    using TheTieSilincer.Interfaces;
    using TheTieSilincer.Models;

    public class BulletFactory : IBulletFactory
    {
        public IBullet CreateBullet(BulletType bulletType, Position position)
        {
            Type typeOfBullet = Assembly.GetExecutingAssembly().GetTypes().
                FirstOrDefault(v => v.Name == bulletType.ToString());

            IBullet bullet = (IBullet)Activator.CreateInstance(typeOfBullet, position);

            return bullet;
        }
    }
}