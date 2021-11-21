using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Skins;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Gears.Skins;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Views.Insignias.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Rosters.Combatants.Interfaces
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