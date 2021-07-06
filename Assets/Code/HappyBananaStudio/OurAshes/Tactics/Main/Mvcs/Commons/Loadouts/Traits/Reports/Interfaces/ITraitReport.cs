﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Reports.Interfaces
{
    /// <summary>
    /// Trait Report Interface
    /// </summary>
    public interface ITraitReport
        : IReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<TraitID> GetTraitIDs();
    }
}