namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Objects.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Objects.Api;
    using System.Collections.Generic;

    /// <summary>
    /// GameBoard Object Api
    /// </summary>
    public interface IGameBoardObject
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
        /// <returns></returns>
        bool GetMirroredBoard();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IGameBoardReport GetGameBoardReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        float GetHexTileObjectFireCostFrom(ICubeCoordinates cubeCoordinates);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        IHexTileObject GetHexTileObject(ICubeCoordinates cubeCoordinates);

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