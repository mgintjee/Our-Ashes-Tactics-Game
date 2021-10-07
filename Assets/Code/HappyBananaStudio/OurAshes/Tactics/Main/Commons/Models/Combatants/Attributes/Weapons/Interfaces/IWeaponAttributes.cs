namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Weapons.Interfaces
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