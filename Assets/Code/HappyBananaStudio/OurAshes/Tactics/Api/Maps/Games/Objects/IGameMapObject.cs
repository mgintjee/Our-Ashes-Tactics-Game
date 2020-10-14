
namespace HappyBananaStudio.OurAshes.Tactics.Api.Maps.Games.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Maps.Games.Reports;
    using System.Collections.Generic;

    /// <summary>
    /// Map Object Api
    /// </summary>
    public interface IGameMapObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IDictionary<ICubeCoordinates, IHexTileObject> GetCubeCoordinatesHexTileObjectDictionary();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<ICubeCoordinates> GetCubeCoordinatesSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IGameMapConstructionReport GetGameMapConstructionReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IGameMapInformationReport GetGameMapInformationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        int GetHexTileObjectFireCostFrom(ICubeCoordinates cubeCoordinates);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        IHexTileObject GetHexTileObjectFrom(ICubeCoordinates cubeCoordinates);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int GetMaxDistanceFromCenter();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        ISet<ICubeCoordinates> GetNeighborCubeCoordinates(ICubeCoordinates cubeCoordinates);
    }
}
