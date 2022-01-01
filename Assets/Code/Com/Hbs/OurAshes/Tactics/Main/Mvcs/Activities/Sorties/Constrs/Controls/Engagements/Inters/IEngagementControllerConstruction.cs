using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Engagements.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Controls.Engagements.Phalanxes.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Controls.Engagements.Inters
{
    /// <summary>
    /// Engagement Control Construction Interface
    /// </summary>
    public interface IEngagementControlConstruction
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
        ISet<IPhalanxControlConstruction> GetPhalanxConstrs();
    }
}