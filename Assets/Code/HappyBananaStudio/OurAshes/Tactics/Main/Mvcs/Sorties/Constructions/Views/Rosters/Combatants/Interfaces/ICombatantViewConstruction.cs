using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Skins;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Skins;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Views.Insignias.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Rosters.Combatants.Interfaces
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