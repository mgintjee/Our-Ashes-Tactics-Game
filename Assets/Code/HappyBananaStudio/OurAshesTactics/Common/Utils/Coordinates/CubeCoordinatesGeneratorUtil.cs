/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Coordinates.Cube;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Coordinates
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class CubeCoordinatesGeneratorUtil
    {
        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mapModelRadius">
        /// </param>
        /// <returns>
        /// </returns>
        public static HashSet<ICubeCoordinates> GenerateHexagonCubeCoordinatesSet(int mapModelRadius)
        {
            logger.Debug("Generating HashSet: CubeCoordinates for Map Radius=?", mapModelRadius);
            HashSet<ICubeCoordinates> tileCoordinatesSet = new HashSet<ICubeCoordinates>();
            ICubeCoordinates currentCubeCoordinates = new CubeCoordinatesImpl(0, 0, 0);
            HashSet<ICubeCoordinates> visitedCubeCoordinatesSet = new HashSet<ICubeCoordinates>();
            HashSet<ICubeCoordinates> unvisitedCubeCoordinatesSet = new HashSet<ICubeCoordinates> { currentCubeCoordinates };
            while (unvisitedCubeCoordinatesSet.Count > 0)
            {
                currentCubeCoordinates = new List<ICubeCoordinates>(unvisitedCubeCoordinatesSet)[0];
                unvisitedCubeCoordinatesSet.Remove(currentCubeCoordinates);
                tileCoordinatesSet.Add(currentCubeCoordinates);
                if (!visitedCubeCoordinatesSet.Contains(currentCubeCoordinates))
                {
                    visitedCubeCoordinatesSet.Add(currentCubeCoordinates);
                }

                HashSet<ICubeCoordinates> neighborCubeCoordinates = CubeCoordinatesCommonUtil.GenerateNeighborCubeCoordinatesSet(
                    currentCubeCoordinates, mapModelRadius);
                foreach (ICubeCoordinates cubeCoordinates in neighborCubeCoordinates)
                {
                    if (!visitedCubeCoordinatesSet.Contains(cubeCoordinates) &&
                        CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFromCenter(cubeCoordinates) <= mapModelRadius)
                    {
                        unvisitedCubeCoordinatesSet.Add(cubeCoordinates);
                    }
                }
            }
            logger.Debug("? CubeCoordinates: ?", tileCoordinatesSet.Count, string.Join(", ", tileCoordinatesSet));
            return tileCoordinatesSet;
        }
    }
}