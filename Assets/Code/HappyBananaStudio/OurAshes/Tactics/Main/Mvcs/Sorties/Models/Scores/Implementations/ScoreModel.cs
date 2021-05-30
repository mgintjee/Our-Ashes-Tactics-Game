using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Scores.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Scores.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Scores.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class ScoreModel
        : IScoreModel
    {
        // Todo
        private readonly ScoreType scoreType;

        // Todo
        private IScoreReport _report;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="scoreConstruction"></param>
        public ScoreModel(IScoreConstruction scoreConstruction)
        {
            scoreType = scoreConstruction.GetScoreType();
        }

        /// <inheritdoc/>
        IScoreReport IScoreModel.GetReport()
        {
            return _report;
        }

        void IScoreModel.Process(ISortieControllerRequest controllerRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}