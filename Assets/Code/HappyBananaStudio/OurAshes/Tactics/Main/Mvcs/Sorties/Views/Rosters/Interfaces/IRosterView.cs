using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Rosters.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IRosterView
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsProcessing();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="modelResponse"></param>
        void Process(ISortieModelResponse modelResponse);
    }
}