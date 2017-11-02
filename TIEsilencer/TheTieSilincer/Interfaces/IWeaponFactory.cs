namespace TheTieSilincer.Interfaces
{
    using TheTieSilincer.Enums;
    using TheTieSilincer.Models.Weapons;

    public interface IWeaponFactory
    {
        Weapon CreateWeapon(WeaponType weaponType);
    }
}