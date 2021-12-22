namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Weapons.Inters
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