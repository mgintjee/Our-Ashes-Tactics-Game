namespace HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;

    /// <summary>
    /// HexTile Object Api
    /// </summary>
    public interface IHexTileObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        void ClearOccupyingTalonIdentificationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IHexTileInformationReport GetHexTileInformationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        void SetOccupyingTalonIdentificationReport(ITalonIdentificationReport talonIdentificationReport);
    }
}