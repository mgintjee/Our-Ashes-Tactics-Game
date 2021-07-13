using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Engagements.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Reports.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Scores.Interfaces
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
        void Process(ISortieRequest controllerRequest, ISortieMapReport mapReport, IRosterReport rosterReport, IEngagementReport engagementReport);
    }
}