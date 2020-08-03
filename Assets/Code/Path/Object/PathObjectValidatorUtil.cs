using System.Collections.Generic;
using System.Diagnostics;

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

    public static bool ValidPathObject(PathObject pathObject)
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

    public static bool ValidPathObjectCompleteness(PathObject pathObject)
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

    public static bool ValidPathObjectConnectivity(List<CubeCoordinates> cubeCoordinatesList)
    {
        if (cubeCoordinatesList != null &&
            cubeCoordinatesList.Count > 0)
        {
            CubeCoordinates previousCubeCoordinates = cubeCoordinatesList[0];

            for (int i = 1; i < cubeCoordinatesList.Count; ++i)
            {
                CubeCoordinates currentCubeCoordinates = cubeCoordinatesList[i];
                HexTileObject previousTileObject = HexTileObjectFinderUtil.FindHexTileObjectFrom(previousCubeCoordinates);
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
                                logger.Debug("PathObject is not valid. PathObject is not connected.");
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

    public static bool ValidPathObjectCount(PathObject pathObject)
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
                    logger.Debug("PathObject is not valid. PathObject length=?, is not the minimum distance: ? Tiles.", pathObject.GetPathObjectLength(), pathCount);
                    return false;
                }
                return true;
            }
        }
        return false;
    }

    #endregion Public Methods
}