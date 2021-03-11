namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Utils
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Utils;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Managers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Api;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public class PathObjectValidatorUtil
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

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
                IList<ICubeCoordinates> cubeCoordinatesStepList = pathObject.GetCubeCoordinatesStepList();
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
        public static bool ValidPathObjectConnectivity(IList<ICubeCoordinates> cubeCoordinatesList)
        {
            if (cubeCoordinatesList != null &&
                cubeCoordinatesList.Count > 0)
            {
                ICubeCoordinates previousCubeCoordinates = cubeCoordinatesList[0];

                for (int i = 1; i < cubeCoordinatesList.Count; ++i)
                {
                    ICubeCoordinates currentCubeCoordinates = cubeCoordinatesList[i];
                    if (!GameBoardManager.GetNeighborCubeCoordinates(previousCubeCoordinates)
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
                    int pathCount = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFrom(
                        cubeCoordinatesStart, cubeCoordinatesEnd) + 1;
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