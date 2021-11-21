using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Requests.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Engagements.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Maps.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Rosters.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Scores.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Scores.Interfaces
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
        /// <param name="controllerRequest"></param>
        /// <param name="mapReport">        </param>
        /// <param name="rosterReport">     </param>
        /// <param name="engagementReport"> </param>
        void Process(ISortieRequest controllerRequest, ISortieMapReport mapReport, IRosterModelReport rosterReport, IEngagementReport engagementReport);
    }
}