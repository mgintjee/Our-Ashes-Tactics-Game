using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Models.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Models.Objects.Api
{
    /// <summary>
    /// HexTile Object Api
    /// </summary>
    public interface IHexTileObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        void ClearTalonCallSign();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IHexTileReport GetHexTileReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign">
        /// </param>
        void SetTalonCallSign(TalonCallSign talonCallSign);
    }
}