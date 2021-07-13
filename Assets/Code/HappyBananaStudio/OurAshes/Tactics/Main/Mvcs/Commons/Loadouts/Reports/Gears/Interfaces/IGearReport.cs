using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Traits.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Gears.Interfaces
{
    /// <summary>
    /// Gear Report Interface
    /// </summary>
    public interface IGearReport : IReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICombatantAttributes GetCombatantAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        GearID GetGearID();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ITraitReport GetTraitReport();
    }
}