/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api
{
    /// <summary>
    /// HexTile Object Api
    /// </summary>
    public interface IHexTileObject
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        HexTileInformationReport GetHexTileInformationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        HexTileScript GetHexTileScript();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        HexTileTypeEnum GetHexTileType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport"></param>
        void SetOccupyingTalonIdentificationReport(TalonIdentificationReport talonIdentificationReport);

        #endregion Public Methods
    }
}