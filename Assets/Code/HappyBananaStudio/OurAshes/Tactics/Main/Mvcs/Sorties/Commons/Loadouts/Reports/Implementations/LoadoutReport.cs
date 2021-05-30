using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Loadouts.Reports.Gears.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Loadouts.Reports.Interfaces;
using System;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Loadouts.Reports.Implementations
{
    /// <summary>
    /// Loadout Report Implementation
    /// </summary>
    public class LoadoutReport
        : ILoadoutReport
    {
        ISet<IGearReport> ILoadoutReport.GetGearReports(GearType gearType)
        {
            throw new NotImplementedException();
        }

        ISet<IGearReport> ILoadoutReport.GetGearReports()
        {
            throw new NotImplementedException();
        }
    }
}