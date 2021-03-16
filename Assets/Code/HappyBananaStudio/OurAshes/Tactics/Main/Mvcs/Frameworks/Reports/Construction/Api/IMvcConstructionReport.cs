using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Reports.Phalanxes.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Canvases.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Constructions.Reports.Api;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Reports.Construction.Api
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IMvcConstructionReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        SimulationType GetSimulationType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        MatchType GetMatchType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<IPhalanxReport> GetPhalanxReports();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<ITalonConstructionReport> GetTalonConstructionReports();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        GameBoardShape GetGameBoardShape();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        int GetGameBoardLimit();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool GetMirroredBoard();

        /// <summary>
        /// Todo
        /// </summary>
        ICanvasConfigurationReport GetViewConfigurationReport();
    }
}