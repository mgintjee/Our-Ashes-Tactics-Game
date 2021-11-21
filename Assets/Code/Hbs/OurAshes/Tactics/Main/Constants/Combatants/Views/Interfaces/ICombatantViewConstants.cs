using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Skins;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Combatants.Views.Interfaces
{
    /// <summary>
    /// Combatant View Constants Interface
    /// </summary>
    public interface ICombatantViewConstants
    {
        CombatantID GetCombatantID();

        ISet<CombatantSkin> GetCombatantSkins();
    }
}