using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Gears.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Rarities;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Combatants.Models.Interfaces
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