using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Loadouts.Models.Gears.Interfaces
{
    /// <summary>
    /// Gear Model Cosntants Interface
    /// </summary>
    public interface IGearModelConstants
    {
        string GetName();

        GearID GetGearID();

        ICombatantAttributes GetCombatantAttributes();

        IWeaponAttributes GetWeaponAttributes();

        ISet<CombatantType> GetCombatantTypes();

        Rarity GetRarity();

        GearSize GetGearSize();

        GearType GetGearType();

        ISet<TraitType> GetTraitTypes();
    }
}