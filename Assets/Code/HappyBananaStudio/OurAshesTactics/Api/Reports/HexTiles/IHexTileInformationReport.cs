/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Api.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.HexTiles
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IHexTileInformationReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IHexTileAttributes GetHexTileAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IHexTileConstructionReport GetHexTileConstructionReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonIdentificationReport GetTalonIdentificationReport();
    }
}