using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public class PathObjectFire
    : PathObjectAbstract
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Constructors

    public PathObjectFire(List<CubeCoordinates> tileObjectStepList)
        : base(tileObjectStepList)
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
                return tileObject.GetTileObjectFireCost();
            }
            else
            {
                logger.Warn("Unable to determine FireCost for TileObject. Parameterized TileCoordiantes is not tracked in the MapModelObject.");
            }
        }
        else
        {
            logger.Warn("Unable to determine FireCost for TileObject. Parameterized TileCoordiantes is null.");
        }
        return int.MaxValue;
    }

    #endregion Protected Methods
}