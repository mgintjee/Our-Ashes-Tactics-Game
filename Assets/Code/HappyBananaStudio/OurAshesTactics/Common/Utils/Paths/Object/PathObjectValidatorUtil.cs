/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.HexTile;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Paths.Object;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Managers;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Paths.Object
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PathObjectValidatorUtil
    {
        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject">
        /// </param>
        /// <returns>
        /// </returns>
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
                    logger.Debug("?/?/?",!validPathObjectCount,!validPathObjectConnectivity,!validPathObjectCompleteness);
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
        /// <param name="pathObject">
        /// </param>
        /// <returns>
        /// </returns>
        public static bool ValidPathObjectCompleteness(IPathObject pathObject)
        {
            if (pathObject != null)
            {
                ICubeCoordinates cubeCoordinatesEnd = pathObject.GetCubeCoordinatesEnd();
                List<ICubeCoordinates> cubeCoordinatesStepList = pathObject.GetCubeCoordinatesStepList();
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
        /// <param name="cubeCoordinatesList">
        /// </param>
        /// <returns>
        /// </returns>
        public static bool ValidPathObjectConnectivity(List<ICubeCoordinates> cubeCoordinatesList)
        {
            if (cubeCoordinatesList != null &&
                cubeCoordinatesList.Count > 0)
            {
                ICubeCoordinates previousCubeCoordinates = cubeCoordinatesList[0];

                for (int i = 1; i < cubeCoordinatesList.Count; ++i)
                {
                    ICubeCoordinates currentCubeCoordinates = cubeCoordinatesList[i];
                    IHexTileObject previousTileObject = GameMapObjectManager.FindHexTileObjectFrom(previousCubeCoordinates);
                    if (GameMapObjectManager.GetNeighborCubeCoordinates(previousCubeCoordinates)
                        .Contains(currentCubeCoordinates))
                    {
                        return false;
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
        /// <param name="pathObject">
        /// </param>
        /// <returns>
        /// </returns>
        public static bool ValidPathObjectCount(IPathObject pathObject)
        {
            if (pathObject != null)
            {
                ICubeCoordinates cubeCoordinatesStart = pathObject.GetCubeCoordinatesStart();
                ICubeCoordinates cubeCoordinatesEnd = pathObject.GetCubeCoordinatesEnd();
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
    }
}