using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Skins;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Combatants.Views.Inters
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