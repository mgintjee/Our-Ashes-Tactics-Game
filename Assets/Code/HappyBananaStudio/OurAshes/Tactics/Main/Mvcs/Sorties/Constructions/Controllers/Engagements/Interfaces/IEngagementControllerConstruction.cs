﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Engagements.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Controllers.Engagements.Phalanxes.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Controllers.Engagements.Interfaces
{
    /// <summary>
    /// Engagement Controller Construction Interface
    /// </summary>
    public interface IEngagementControllerConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        EngagementType GetEngagementType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<IPhalanxControllerConstruction> GetPhalanxConstructions();
    }
}