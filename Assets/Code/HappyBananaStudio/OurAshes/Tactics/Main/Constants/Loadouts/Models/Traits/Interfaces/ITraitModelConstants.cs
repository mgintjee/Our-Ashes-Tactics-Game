namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Loadouts.Models.Traits.Interfaces
{
    /// <summary>
    /// Trait Model Constants Interface
    /// </summary>
    public interface ITraitModelConstants
    {
        string GetName();

        TraitID GetTraitID();

        ICombatantAttributes GetCombatantAttributes();

        IWeaponAttributes GetWeaponAttributes();

        Rarity GetRarity();

        TraitType GetTraitType();
    }
}