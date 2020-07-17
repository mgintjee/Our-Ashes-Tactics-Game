using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public class PathObjectWait
    : PathObjectAbstract
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Constructors

    public PathObjectWait(List<CubeCoordinates> tileObjectStepList)
        : base(tileObjectStepList)
    {
        if (tileObjectStepList.Count != 1)
        {
            logger.Error("Error creating a PathObjectWait. List: CubeCoordinates should be of length 1. Parameterized List: CubeCoordinates is length=?", tileObjectStepList.Count);
        }
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