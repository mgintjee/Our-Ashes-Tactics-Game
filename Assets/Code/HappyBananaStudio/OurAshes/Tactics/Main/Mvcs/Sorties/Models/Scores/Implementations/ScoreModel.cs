using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scores.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Engagements.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Reports.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Tallies.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Tallies.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Scores.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Scores.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class ScoreModel
        : IScoreModel
    {
        // Todo
        private readonly ILogger _logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly ScoreType _scoreType;

        private readonly ISet<IScoreTally> _scoreTallies = new HashSet<IScoreTally>();

        // Todo
        private IScoreReport _report;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="scoreConstruction"></param>
        public ScoreModel(IScoreConstruction scoreConstruction)
        {
            _scoreType = scoreConstruction.GetScoreType();
        }

        /// <inheritdoc/>
        IScoreReport IScoreModel.GetReport()
        {
            if (_report == null)
            {
                this.BuildReport();
            }
            return _report;
        }

        /// <inheritdoc/>
        void IScoreModel.Process(ISortieControllerRequest controllerRequest, IMapReport mapReport, IRosterReport rosterReport, IEngagementReport engagementReport)
        {
            if (controllerRequest != null)
            {
                this.BuildScoreTallies(mapReport, rosterReport, engagementReport);
            }
            this.BuildReport();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildReport()
        {
            _report = new ScoreReport.Builder()
                .SetIsScoreReached(this.IsScoreReached())
                .SetScoreTallies(_scoreTallies)
                .SetScoreType(_scoreType)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private bool IsScoreReached()
        {
            foreach (IScoreTally scoreTally in _scoreTallies)
            {
                if (scoreTally.GetScore() == 100)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mapReport">       </param>
        /// <param name="rosterReport">    </param>
        /// <param name="engagementReport"></param>
        private void BuildScoreTallies(IMapReport mapReport, IRosterReport rosterReport, IEngagementReport engagementReport)
        {
            _scoreTallies.Clear();
            foreach (PhalanxCallSign callSign in engagementReport.GetAllPhalanxCallSigns())
            {
                _scoreTallies.Add(BuildScoreTally(callSign, engagementReport, mapReport, rosterReport));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign">        </param>
        /// <param name="engagementReport"></param>
        /// <param name="mapReport">       </param>
        /// <param name="rosterReport">    </param>
        /// <returns></returns>
        private IScoreTally BuildScoreTally(PhalanxCallSign callSign, IEngagementReport engagementReport, IMapReport mapReport, IRosterReport rosterReport)
        {
            float score = 0.0f;
            switch (_scoreType)
            {
                case ScoreType.Skirmish:
                    score = CalculateSkirmishScoreTally(callSign, engagementReport, mapReport, rosterReport);
                    break;
            }

            return new ScoreTally.Builder()
                .SetCallSign(callSign)
                .SetScore(score)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign">    </param>
        /// <param name="mapReport">   </param>
        /// <param name="rosterReport"></param>
        /// <returns></returns>
        private float CalculateSkirmishScoreTally(PhalanxCallSign callSign, IEngagementReport engagementReport, IMapReport mapReport, IRosterReport rosterReport)
        {
            int hostileCount = this.GetHostileCombatantCount(callSign, engagementReport, rosterReport);
            int friendlyCount = this.GetFriendlyCombatantCount(callSign, engagementReport, rosterReport);
            return (hostileCount + friendlyCount != 0)
                    ? 100f * friendlyCount / (friendlyCount + hostileCount)
                    : 0.0f;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign">        </param>
        /// <param name="engagementReport"></param>
        /// <returns></returns>
        private int GetHostileCombatantCount(PhalanxCallSign callSign, IEngagementReport engagementReport, IRosterReport rosterReport)
        {
            return rosterReport.GetActiveCombatantCallSigns().Count - this.GetFriendlyCombatantCount(callSign, engagementReport, rosterReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign">        </param>
        /// <param name="engagementReport"></param>
        /// <param name="rosterReport">    </param>
        /// <returns></returns>
        private int GetFriendlyCombatantCount(PhalanxCallSign callSign, IEngagementReport engagementReport, IRosterReport rosterReport)
        {
            int friendlyCount = 0;
            engagementReport.GetPhalanxReport(callSign).IfPresent(phalanxReport =>
            {
                ISet<PhalanxCallSign> friendlyPhalanxCallSigns = phalanxReport.GetPhalanxCallSigns();
                ISet<CombatantCallSign> friendlyCombatantCallSigns = phalanxReport.GetCombatantCallSigns();
                foreach (PhalanxCallSign phalanxCallSign in friendlyPhalanxCallSigns)
                {
                    engagementReport.GetPhalanxReport(phalanxCallSign).IfPresent(friendlyPhalanxReport =>
                    { friendlyCombatantCallSigns.UnionWith(friendlyPhalanxReport.GetCombatantCallSigns()); });
                }
                friendlyCombatantCallSigns.IntersectWith(rosterReport.GetActiveCombatantCallSigns());
                friendlyCount = friendlyCombatantCallSigns.Count;
            });
            return friendlyCount;
        }
    }
}