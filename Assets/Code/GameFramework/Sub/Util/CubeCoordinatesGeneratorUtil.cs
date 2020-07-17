using System.Collections.Generic;
using System.Diagnostics;

public static class CubeCoordinatesGeneratorUtil
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Methods

    public static HashSet<CubeCoordinates> GenerateCubeCoordinatesSet(int mapModelRadius)
    {
        logger.Debug("Generating HashSet: CubeCoordinates for Map Radius=?", mapModelRadius);
        HashSet<CubeCoordinates> tileCoordinatesSet = new HashSet<CubeCoordinates>();
        CubeCoordinates currentCubeCoordinates = new CubeCoordinates(0, 0, 0);
        HashSet<CubeCoordinates> visitedCubeCoordinatesSet = new HashSet<CubeCoordinates>();
        HashSet<CubeCoordinates> unvisitedCubeCoordinatesSet = new HashSet<CubeCoordinates> { currentCubeCoordinates };
        while (unvisitedCubeCoordinatesSet.Count > 0)
        {
            currentCubeCoordinates = new List<CubeCoordinates>(unvisitedCubeCoordinatesSet)[0];
            unvisitedCubeCoordinatesSet.Remove(currentCubeCoordinates);
            tileCoordinatesSet.Add(currentCubeCoordinates);
            if (!visitedCubeCoordinatesSet.Contains(currentCubeCoordinates))
            {
                visitedCubeCoordinatesSet.Add(currentCubeCoordinates);
            }

            HashSet<CubeCoordinates> neighborCubeCoordinates = CubeCoordinatesCommonUtil.GenerateNeighborCubeCoordinates(currentCubeCoordinates);
            foreach (CubeCoordinates cubeCoordinates in neighborCubeCoordinates)
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

    #endregion Public Methods
}