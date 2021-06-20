using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scores.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Reports.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Tallies.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Scores.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Scores.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class ScoreModel
        : IScoreModel
    {
        // Todo
        private readonly ScoreType _scoreType;

        // Todo
        private IScoreReport _report;

        private ISet<IScoreTally> _scoreTallies = new HashSet<IScoreTally>();

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
        void IScoreModel.Process(ISortieControllerRequest controllerRequest)
        {
            if (controllerRequest != null)
            {
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
            if (_scoreTallies.Count == 0)
            {
                return true;
            }
            foreach (IScoreTally scoreTally in _scoreTallies)
            {
                if (scoreTally.GetScoreTally() > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}