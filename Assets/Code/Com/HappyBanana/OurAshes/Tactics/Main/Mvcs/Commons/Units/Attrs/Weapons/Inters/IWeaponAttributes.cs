namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Weapons.Inters
{
    /// <summary>
    /// Weapon Attributes Interface
    /// </summary>
    public interface IWeaponAttributes
    {
        float GetArmorDamage();

        float GetArmorPenetration();

        float GetAccuracy();

        float GetHealthDamage();

        float GetRange();

        float GetSalvo();
    }
}