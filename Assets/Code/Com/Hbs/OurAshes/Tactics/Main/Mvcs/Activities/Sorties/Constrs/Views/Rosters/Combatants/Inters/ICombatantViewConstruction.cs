using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Skins;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Gears.Skins;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Views.Insignias.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Views.Rosters.Combatants.Inters
{
    /// <summary>
    /// Combatant View Construction Interface
    /// </summary>
    public interface ICombatantViewConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        CombatantCallSign GetCombatantCallSign();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        CombatantSkin GetCombatantSkin();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IInsigniaReport GetInsigniaReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IList<GearSkin> GetGearSkins();
    }
}