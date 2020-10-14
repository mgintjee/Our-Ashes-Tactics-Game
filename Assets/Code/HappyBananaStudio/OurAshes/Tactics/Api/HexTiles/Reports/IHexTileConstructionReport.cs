
namespace HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.HexTiles;

    /// <summary>
    /// Todo
    /// </summary>
    public interface IHexTileConstructionReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ICubeCoordinates GetCubeCoordinates();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        HexTileTypeEnum GetHexTileType();
    }
}
