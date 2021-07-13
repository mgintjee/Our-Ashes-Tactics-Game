using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities;
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