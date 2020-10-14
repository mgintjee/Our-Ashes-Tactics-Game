
namespace HappyBananaStudio.OurAshes.Tactics.Common.Utils.Coordinates
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class CubeCoordinatesGeneratorUtil
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mapModelRadius">
        /// </param>
        /// <returns>
        /// </returns>
        public static ISet<ICubeCoordinates> GenerateHexagonCubeCoordinatesSet(int mapModelRadius)
        {
            logger.Debug("Generating ISet: CubeCoordinates for Map Radius=?", mapModelRadius);
            ISet<ICubeCoordinates> tileCoordinatesSet = new HashSet<ICubeCoordinates>();
            ICubeCoordinates currentCubeCoordinates = new CubeCoordinatesImpl(0, 0, 0);
            ISet<ICubeCoordinates> visitedCubeCoordinatesSet = new HashSet<ICubeCoordinates>();
            ISet<ICubeCoordinates> unvisitedCubeCoordinatesSet = new HashSet<ICubeCoordinates> { currentCubeCoordinates };
            while (unvisitedCubeCoordinatesSet.Count > 0)
            {
                currentCubeCoordinates = new List<ICubeCoordinates>(unvisitedCubeCoordinatesSet)[0];
                unvisitedCubeCoordinatesSet.Remove(currentCubeCoordinates);
                tileCoordinatesSet.Add(currentCubeCoordinates);
                if (!visitedCubeCoordinatesSet.Contains(currentCubeCoordinates))
                {
                    visitedCubeCoordinatesSet.Add(currentCubeCoordinates);
                }

                ISet<ICubeCoordinates> neighborCubeCoordinates = CubeCoordinatesCommonUtil.GenerateNeighborCubeCoordinatesSet(
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
