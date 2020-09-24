/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Api;
using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Manager
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MapObjectManager
    {
        #region Private Fields

        // Todo
        private static IMapObject mapObject;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        public static int FindHexTileObjectFireCostFrom(CubeCoordinates cubeCoordinates)
        {
            if (mapObject != null)
            {
                return mapObject.GetHexTileObjectFireCostFrom(cubeCoordinates);
            }
            else
            {
                throw new ArgumentException("Unable to FindHexTileObjectFireCostFrom. " + typeof(IMapObject) + " is null.");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        public static IHexTileObject FindHexTileObjectFrom(CubeCoordinates cubeCoordinates)
        {
            if (mapObject != null)
            {
                return mapObject.GetHexTileObjectFrom(cubeCoordinates);
            }
            else
            {
                throw new ArgumentException("Unable to FindHexTileObjectFrom. " + typeof(IMapObject) + " is null.");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static HashSet<CubeCoordinates> GetAllCubeCoordinatesSet()
        {
            if (mapObject != null)
            {
                return mapObject.GetCubeCoordinatesSet();
            }
            else
            {
                throw new ArgumentException("Unable to GetTileCoordinatesSet. " + typeof(IMapObject) + " is null.");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        public static HashSet<CubeCoordinates> GetNeighborCubeCoordinates(CubeCoordinates cubeCoordinates)
        {
            if (mapObject != null)
            {
                return mapObject.GetNeighborCubeCoordinates(cubeCoordinates);
            }
            else
            {
                throw new ArgumentException("Unable to GetNeighborCubeCoordinates. " + typeof(IMapObject) + " is null.");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="newMapObject"></param>
        public static void SetMapObject(IMapObject newMapObject)
        {
            mapObject = newMapObject;
        }

        #endregion Public Methods
    }
}