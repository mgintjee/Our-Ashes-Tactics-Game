using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public class PathObjectMove
    : PathObjectAbstract
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Constructors

    public PathObjectMove(List<CubeCoordinates> tileObjectStepList)
        : base(tileObjectStepList)
    {
    }

    public PathObjectMove(PathObject pathObject)
        : base(pathObject)
    {
    }

    public PathObjectMove(CubeCoordinates tileCoordinatesStart, CubeCoordinates tileCoordinatesEnd, int pathLength)
        : base(tileCoordinatesStart, tileCoordinatesEnd, pathLength)
    {
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override int GetTileObjectPathCost(CubeCoordinates tileCoordinates)
    {
        if (tileCoordinates != null)
        {
            TileObject tileObject = TileObjectFinderUtil.FindTileObjectFrom(tileCoordinates);
            if (tileObject != null)
            {
                return tileObject.GetTileObjectMoveCost();
            }
            else
            {
                logger.Warn("Unable to determine MoveCost for TileObject. Parameterized TileCoordiantes is not tracked in the MapModelObject.");
            }
        }
        else
        {
            logger.Warn("Unable to determine MoveCost for TileObject. Parameterized TileCoordiantes is null.");
        }
        return int.MaxValue;
    }

    #endregion Protected Methods
}