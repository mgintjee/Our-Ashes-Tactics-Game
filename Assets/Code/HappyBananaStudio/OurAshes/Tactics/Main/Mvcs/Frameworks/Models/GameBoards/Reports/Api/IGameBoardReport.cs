namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Reports.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Reports.Api;
    using System.Collections.Generic;

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