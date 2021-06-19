using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Reports.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Interfaces
{
    /// <summary>
    /// Loadout Report Interface
    /// </summary>
    public interface ILoadoutReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gearType"></param>
        /// <returns></returns>
        ISet<IGearReport> GetGearReports(GearType gearType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<IGearReport> GetGearReports();
    }
}