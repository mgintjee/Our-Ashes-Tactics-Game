/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Util;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Manager;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Api;
using System.Collections.Generic;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Pathing.Object.Util
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PathObjectValidatorUtil
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject"></param>
        /// <returns></returns>
        public static bool ValidPathObject(IPathObject pathObject)
        {
            if (pathObject != null)
            {
                bool validPathObjectCount = ValidPathObjectCount(pathObject);
                bool validPathObjectConnectivity = ValidPathObjectConnectivity(pathObject.GetCubeCoordinatesStepList());
                bool validPathObjectCompleteness = ValidPathObjectCompleteness(pathObject);

                if (!validPathObjectCount
                    || !validPathObjectConnectivity
                    || !validPathObjectCompleteness)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject"></param>
        /// <returns></returns>
        public static bool ValidPathObjectCompleteness(IPathObject pathObject)
        {
            if (pathObject != null)
            {
                CubeCoordinates cubeCoordinatesEnd = pathObject.GetCubeCoordinatesEnd();
                List<CubeCoordinates> cubeCoordinatesStepList = pathObject.GetCubeCoordinatesStepList();
                if (cubeCoordinatesStepList != null &&
                    cubeCoordinatesStepList.Count > 0)
                {
                    int tileStepListCount = cubeCoordinatesStepList.Count;
                    if (cubeCoordinatesEnd != cubeCoordinatesStepList[tileStepListCount - 1])
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesList"></param>
        /// <returns></returns>
        public static bool ValidPathObjectConnectivity(List<CubeCoordinates> cubeCoordinatesList)
        {
            if (cubeCoordinatesList != null &&
                cubeCoordinatesList.Count > 0)
            {
                CubeCoordinates previousCubeCoordinates = cubeCoordinatesList[0];

                for (int i = 1; i < cubeCoordinatesList.Count; ++i)
                {
                    CubeCoordinates currentCubeCoordinates = cubeCoordinatesList[i];
                    IHexTileObject previousTileObject = MapObjectManager.FindHexTileObjectFrom(previousCubeCoordinates);
                    if (previousTileObject != null)
                    {
                        HexTileInformationReport hexTileInformationReport = previousTileObject.GetHexTileInformationReport();
                        if (hexTileInformationReport != null)
                        {
                            HexTileConstructionReport hexTileConstructionReport = hexTileInformationReport.GetHexTileConstructionReport();
                            if (hexTileConstructionReport != null)
                            {
                                if (!hexTileConstructionReport.GetNeighborCubeCoordinatesSet().Contains(currentCubeCoordinates))
                                {
                                    return false;
                                }
                            }
                        }
                    }

                    previousCubeCoordinates = currentCubeCoordinates;
                }

                return true;
            }
            return false;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject"></param>
        /// <returns></returns>
        public static bool ValidPathObjectCount(IPathObject pathObject)
        {
            if (pathObject != null)
            {
                CubeCoordinates cubeCoordinatesStart = pathObject.GetCubeCoordinatesStart();
                CubeCoordinates cubeCoordinatesEnd = pathObject.GetCubeCoordinatesEnd();
                if (cubeCoordinatesStart != null &&
                    cubeCoordinatesEnd != null)
                {
                    int pathCount = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFrom(cubeCoordinatesStart, cubeCoordinatesEnd) + 1;
                    if (pathCount <= 0 || pathObject.GetPathObjectLength() < pathCount)
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        #endregion Public Methods
    }
}