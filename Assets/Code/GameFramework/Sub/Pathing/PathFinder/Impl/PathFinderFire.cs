using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public class PathFinderFire
    : PathFinderAbstract
{
    #region Protected Fields

    protected int mechTeam;

    #endregion Protected Fields

    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Constructors

    public PathFinderFire(CubeCoordinates cubeCoordinatesStart, int mechTeam)
        : base(cubeCoordinatesStart)
    {
        this.mechTeam = mechTeam;
    }

    #endregion Public Constructors

    #region Public Methods

    public override void BeginPathFinding()
    {
        HashSet<CubeCoordinates> allCubeCoordinatesEndSet = TileObjectFinderUtil.GetTileCoordinatesSet();
        HashSet<CubeCoordinates> validCubeCoordinatesEndSet = new HashSet<CubeCoordinates>();
        foreach (CubeCoordinates cubeCoordinates in allCubeCoordinatesEndSet)
        {
            TileObject tileObject = TileObjectFinderUtil.FindTileObjectFrom(cubeCoordinates);
            if (tileObject != null &&
                tileObject.GetTileInfoReport().GetOccupyingMechObject() != null &&
                tileObject.GetTileInfoReport().GetOccupyingMechObject().GetMechTeam() != this.mechTeam)
            {
                validCubeCoordinatesEndSet.Add(cubeCoordinates);
            }
        }
        foreach (CubeCoordinates cubeCoordinates in validCubeCoordinatesEndSet)
        {
            List<CubeCoordinates> straightLinePath = this.PathFindFor(this.cubeCoordinatesStart, cubeCoordinates);
            this.pathObjectDictionary[cubeCoordinates] = new PathObjectFire(straightLinePath);
        }
    }

    #endregion Public Methods

    #region Private Methods

    private CubeCoordinates GetNextCubeCoordinates(int pathIndex, int distance, CubeCoordinates cubeCoordinatesEnd)
    {
        float t = 1f / distance * pathIndex;
        int roundX, roundY, roundZ;
        float lerpX = Lerp(this.cubeCoordinatesStart.GetX(), cubeCoordinatesEnd.GetX(), t);
        float lerpY = Lerp(this.cubeCoordinatesStart.GetY(), cubeCoordinatesEnd.GetY(), t);
        float lerpZ = Lerp(this.cubeCoordinatesStart.GetZ(), cubeCoordinatesEnd.GetZ(), t);

        logger.Debug("lerpX=?, lerpY=?, lerpZ=?", lerpX, lerpY, lerpZ);

        roundX = (int)System.Math.Round(lerpX);
        roundY = (int)System.Math.Round(lerpY);
        roundZ = (int)System.Math.Round(lerpZ);

        logger.Debug("roundX=?, roundY=?, roundZ=?", roundX, roundY, roundZ);

        bool updateX = System.Math.Abs(lerpX) % 1 == 0.5f;
        bool updateY = System.Math.Abs(lerpY) % 1 == 0.5f;
        bool updateZ = System.Math.Abs(lerpZ) % 1 == 0.5f;

        logger.Debug("updateX=?, updateY=?, updateZ=?", updateX, updateY, updateZ);

        if (updateX ||
            updateY ||
            updateZ)
        {
            int newX = roundX + System.Math.Sign(lerpX);
            int newY = roundY + System.Math.Sign(lerpY);
            int newZ = roundZ + System.Math.Sign(lerpZ);

            logger.Debug("newX=?, newY=?, newZ=?", newX, newY, newZ);
            logger.Debug("UPDATE X: X=?, Y=?, Z=?", newX, roundY, roundZ);
            logger.Debug("UPDATE Y: X=?, Y=?, Z=?", roundX, newY, roundZ);
            logger.Debug("UPDATE Z: X=?, Y=?, Z=?", roundX, roundY, newZ);

            int newXFireCost = (updateX && newX + roundY + roundZ == 0)
                ? TileObjectFinderUtil.FindTileObjectFireCostFrom(new CubeCoordinates(newX, roundY, roundZ))
                : -1;
            int newYFireCost = (updateY && roundX + newY + roundZ == 0)
                ? TileObjectFinderUtil.FindTileObjectFireCostFrom(new CubeCoordinates(roundX, newY, roundZ))
                : -1;
            int newZFireCost = (updateZ && roundX + roundY + newZ == 0)
                ? TileObjectFinderUtil.FindTileObjectFireCostFrom(new CubeCoordinates(roundX, roundY, newZ))
                : -1;
            SortedSet<int> newFireCostSortedSet = new SortedSet<int> { newXFireCost, newYFireCost, newZFireCost };
            if (newFireCostSortedSet.Max != -1)
            {
                //this.logger.Debug("New Fire Cost: ?", string.Join(", ", newFireCostSortedSet));
                if (newXFireCost == newFireCostSortedSet.Max)
                {
                    //this.logger.Debug("Updated X=", newX);
                    roundX = newX;
                }
                else if (newYFireCost == newFireCostSortedSet.Max)
                {
                    //this.logger.Debug("Updated Y=", newY);
                    roundY = newY;
                }
                else if (newZFireCost == newFireCostSortedSet.Max)
                {
                    //this.logger.Debug("Updated Z=", newZ);
                    roundZ = newZ;
                }
            }
        }
        logger.Debug("finalX=?, finalY=?, finalZ=?", roundX, roundY, roundZ);
        return new CubeCoordinates(roundX, roundY, roundZ);
    }

    private float Lerp(int a, int b, float t)
    {
        return a + (b - a) * t;
    }

    private List<CubeCoordinates> PathFindFor(CubeCoordinates cubeCoordinatesStart, CubeCoordinates cubeCoordinatesEnd)
    {
        int distance = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFrom(cubeCoordinatesStart, cubeCoordinatesEnd);
        List<CubeCoordinates> cubeCoordinatesList = new List<CubeCoordinates>();
        for (int i = 0; i < distance + 1; ++i)
        {
            cubeCoordinatesList.Add(this.GetNextCubeCoordinates(i, distance, cubeCoordinatesEnd));
        }
        return cubeCoordinatesList;
    }

    #endregion Private Methods
}