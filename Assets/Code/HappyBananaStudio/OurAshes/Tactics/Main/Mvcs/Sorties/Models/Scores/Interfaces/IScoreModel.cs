using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Interfaces;

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
        /// <returns></returns>
        void Process(ISortieControllerRequest controllerRequest);
    }
}