using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Engagements.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Phalanxes.Constructions.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Engagements.Constructions.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IEngagementConstruction
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
        ISet<IPhalanxConstruction> GetPhalanxConstructions();
    }
}