namespace HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Maps.Games.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Maps.Games.Reports;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public class GameMapObjectManager
    {
        // Todo
        private static IGameMapObject gameMapObject;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        public static int FindHexTileObjectFireCostFrom(ICubeCoordinates cubeCoordinates)
        {
            if (gameMapObject != null)
            {
                return gameMapObject.GetHexTileObjectFireCostFrom(cubeCoordinates);
            }
            else
            {
                throw new ArgumentException("Unable to FindHexTileObjectFireCostFrom. " + typeof(IGameMapObject) + " is null.");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static ISet<ICubeCoordinates> GetAllCubeCoordinatesSet()
        {
            if (gameMapObject != null)
            {
                return gameMapObject.GetCubeCoordinatesSet();
            }
            else
            {
                throw new ArgumentException("Unable to GetTileCoordinatesSet. " + typeof(IGameMapObject) + " is null.");
            }
        }

        public static IGameMapInformationReport GetGameMapInformationReport()
        {
            return gameMapObject.GetGameMapInformationReport();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        public static IHexTileObject GetHexTileObjectFrom(ICubeCoordinates cubeCoordinates)
        {
            if (gameMapObject != null)
            {
                return gameMapObject.GetHexTileObjectFrom(cubeCoordinates);
            }
            else
            {
                throw new ArgumentException("Unable to FindHexTileObjectFrom. " + typeof(IGameMapObject) + " is null.");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        public static ISet<ICubeCoordinates> GetNeighborCubeCoordinates(ICubeCoordinates cubeCoordinates)
        {
            if (gameMapObject != null)
            {
                return gameMapObject.GetNeighborCubeCoordinates(cubeCoordinates);
            }
            else
            {
                throw new ArgumentException("Unable to GetNeighborCubeCoordinates. " + typeof(IGameMapObject) + " is null.");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="newMapObject">
        /// </param>
        public static void SetMapObject(IGameMapObject newMapObject)
        {
            gameMapObject = newMapObject;
        }
    }
}