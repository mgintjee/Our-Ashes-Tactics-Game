/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Util.Finder;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Util
{
    /// <summary>
    /// Todo
    /// </summary>
    public class HexTileObjectFinderUtil
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

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
            IHexTileObject tileObject = FindHexTileObjectFrom(cubeCoordinates);
            int tileObjectFireCost = int.MaxValue;

            if (tileObject != null)
            {
                HexTileInformationReport hexTileInformationReport = tileObject.GetHexTileInformationReport();
                if (hexTileInformationReport != null)
                {
                    HexTileAttributes hexTileAttributes = hexTileInformationReport.GetHexTileAttributes();
                    if (hexTileAttributes != null)
                    {
                        tileObjectFireCost = hexTileAttributes.GetFireCost();
                        if (hexTileInformationReport.GetTalonIdentificationReport() != null)
                        {
                            tileObjectFireCost += 15; // TODO: Store in a const file
                        }
                    }
                }
            }
            return tileObjectFireCost;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        public static IHexTileObject FindHexTileObjectFrom(CubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                if (mapObject == null)
                {
                    CollectMapModelObject();
                }
                Dictionary<CubeCoordinates, IHexTileObject> tileCoordinatesTileObjectDictionary = mapObject.GetCubeCoordinatesHexTileObjectDictionary();
                if (tileCoordinatesTileObjectDictionary.ContainsKey(cubeCoordinates))
                {
                    return tileCoordinatesTileObjectDictionary[cubeCoordinates];
                }
            }

            return null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        public static HashSet<CubeCoordinates> GetNeighborCubeCoordinates(CubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinates != null)
            {
                IHexTileObject tileObject = FindHexTileObjectFrom(cubeCoordinates);
                if (tileObject != null)
                {
                    HexTileInformationReport hexTileInformationReport = tileObject.GetHexTileInformationReport();
                    if (hexTileInformationReport != null)
                    {
                        HexTileConstructionReport hexTileConstructionReport = hexTileInformationReport.GetHexTileConstructionReport();
                        if (hexTileConstructionReport != null)
                        {
                            return hexTileConstructionReport.GetNeighborCubeCoordinatesSet();
                        }
                    }
                }
            }
            return new HashSet<CubeCoordinates>();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static HashSet<CubeCoordinates> GetTileCoordinatesSet()
        {
            if (mapObject == null)
            {
                CollectMapModelObject();
            }
            return mapObject.GetCubeCoordinatesSet();
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

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        private static void CollectMapModelObject()
        {
            GameObject gameObject = FinderUtil.FindGameObjectType(typeof(MapScript));
            if (gameObject.GetComponent<MapScript>())
            {
                IMapObject newMapObject = gameObject.GetComponent<MapScript>().GetMapObject();
                if (newMapObject != null)
                {
                    mapObject = newMapObject;
                }
            }
        }

        #endregion Private Methods
    }
}