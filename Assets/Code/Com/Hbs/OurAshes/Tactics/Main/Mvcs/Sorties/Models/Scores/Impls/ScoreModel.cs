using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Phalanxes.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Scores.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Commons.Scores.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Scores.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Engagements.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Maps.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Rosters.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Scores.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Scores.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Tallies.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Tallies.Inters;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Scores.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class ScoreModel 
        : IScoreModel
    {
        // Todo
        private readonly IClassLogger _logger = LoggerManager.GetLogger(MvcType.Sortie)
            .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly ScoreType _scoreType;

        // Todo
        private readonly ISet<IScoreModelTally> _scoreTallies = new HashSet<IScoreModelTally>();

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
        void IScoreModel.Process(IMvcControlSortieRequest ModelRequest, ISortieMapReport mapReport, IRosterModelReport rosterReport, IEngagementReport engagementReport)
        {
            if (ModelRequest != null)
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
            foreach (IScoreModelTally scoreTally in _scoreTallies)
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
        private void BuildScoreTallies(ISortieMapReport mapReport, IRosterModelReport rosterReport, IEngagementReport engagementReport)
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
        private IScoreModelTally BuildScoreTally(PhalanxCallSign callSign, IEngagementReport engagementReport, ISortieMapReport mapReport, IRosterModelReport rosterReport)
        {
            float score = 0.0f;
            switch (_scoreType)
            {
                case ScoreType.Skirmish:
                    score = CalculateSkirmishScoreTally(callSign, engagementReport, mapReport, rosterReport);
                    break;
            }

            return ScoreModelTally.Builder.Get()
                .SetPhalanxCallSign(callSign)
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
        private float CalculateSkirmishScoreTally(PhalanxCallSign callSign, IEngagementReport engagementReport, ISortieMapReport mapReport, IRosterModelReport rosterReport)
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
        private int GetHostileCombatantCount(PhalanxCallSign callSign, IEngagementReport engagementReport, IRosterModelReport rosterReport)
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
        private int GetFriendlyCombatantCount(PhalanxCallSign callSign, IEngagementReport engagementReport, IRosterModelReport rosterReport)
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