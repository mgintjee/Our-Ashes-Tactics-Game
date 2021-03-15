using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Models.Reports.Api;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Reports.Api
{
    /// <summary>
    /// GameBoard Report Api
    /// </summary>
    public interface IGameBoardReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<IHexTileReport> GetHexTileReportSet();
    }
}