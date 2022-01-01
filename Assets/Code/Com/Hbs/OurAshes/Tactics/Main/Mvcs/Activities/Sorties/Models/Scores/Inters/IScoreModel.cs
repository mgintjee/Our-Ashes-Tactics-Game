using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Engagements.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Maps.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Rosters.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Scores.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Scores.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IScoreModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IScoreReport GetReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="ModelRequest">    </param>
        /// <param name="mapReport">       </param>
        /// <param name="rosterReport">    </param>
        /// <param name="engagementReport"></param>
        void Process(IMvcControlSortieRequest ModelRequest, ISortieMapReport mapReport, IRosterModelReport rosterReport, IEngagementReport engagementReport);
    }
}