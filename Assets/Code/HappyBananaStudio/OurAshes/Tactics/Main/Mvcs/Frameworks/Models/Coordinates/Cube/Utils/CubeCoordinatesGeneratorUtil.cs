namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Utils
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Impl;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class CubeCoordinatesGeneratorUtil
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mapModelRadius">
        /// </param>
        /// <returns>
        /// </returns>
        public static ISet<ICubeCoordinates> GenerateHexagonCubeCoordinatesSet(int mapModelRadius)
        {
            logger.Debug("Generating ISet: ? for Map Radius=?", typeof(ICubeCoordinates), mapModelRadius);
            ISet<ICubeCoordinates> tileCoordinatesSet = new HashSet<ICubeCoordinates>();
            ICubeCoordinates currentCubeCoordinates = new CubeCoordinates.Builder()
                .SetX(0)
                .SetY(0)
                .SetZ(0)
                .Build();
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
            logger.Debug("? ?: ?", tileCoordinatesSet.Count, typeof(ICubeCoordinates), string.Join(", ", tileCoordinatesSet));
            return tileCoordinatesSet;
        }
    }
}