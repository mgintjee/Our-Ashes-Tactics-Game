/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshes.Tactics.Api.Maps.Games.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Reports;
    using System.Collections.Generic;

    /// <summary>
    /// Report used to describe the Map
    /// </summary>
    public interface IGameMapInformationReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<IHexTileInformationReport> GetHexTileInformationReportSet();
    }
}
