/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.HexTiles;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Maps.Game
{
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
        HashSet<IHexTileInformationReport> GetHexTileInformationReportSet();
    }
}