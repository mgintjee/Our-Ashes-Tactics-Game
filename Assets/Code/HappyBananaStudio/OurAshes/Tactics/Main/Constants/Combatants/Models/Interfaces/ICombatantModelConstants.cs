using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Combatants.Models.Interfaces
{
    /// <summary>
    /// Combatant Model Constants Interface
    /// </summary>
    public interface ICombatantModelConstants
    {
        string GetName();

        CombatantID GetCombatantID();

        CombatantType GetCombatantType();

        Rarity GetRarity();

        ICombatantAttributes GetCombatantAttributes();

        ISet<GearType> GetGearTypes();
    }
}