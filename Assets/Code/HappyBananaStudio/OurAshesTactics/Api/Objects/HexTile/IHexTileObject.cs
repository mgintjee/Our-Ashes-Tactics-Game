/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.HexTile
{
    /// <summary>
    /// HexTile Object Api
    /// </summary>
    public interface IHexTileObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IHexTileInformationReport GetHexTileInformationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IHexTileScript GetHexTileScript();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        HexTileTypeEnum GetHexTileType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        void SetOccupyingTalonIdentificationReport(ITalonIdentificationReport talonIdentificationReport);
    }
}