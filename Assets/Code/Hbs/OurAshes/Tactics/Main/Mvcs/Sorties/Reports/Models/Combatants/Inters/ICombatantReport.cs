using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Loadouts.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combatants.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ICombatantReport : IReport
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
        CombatantID GetCombatantID();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICombatantAttributes GetCurrentAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ILoadoutReport GetLoadoutReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICombatantAttributes GetMaximumAttributes();
    }
}