﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Gears.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Interfaces
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