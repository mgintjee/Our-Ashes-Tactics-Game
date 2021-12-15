using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Gears.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Gears.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Loadouts.Inters
{
    /// <summary>
    /// Loadout Report Interface
    /// </summary>
    public interface ILoadoutReport : IReport
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