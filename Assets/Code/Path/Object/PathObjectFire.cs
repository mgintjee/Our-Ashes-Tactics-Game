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

    protected override int GetTileObjectPathCost(CubeCoordinates cubeCoordinates)
    {
        if (cubeCoordinates != null)
        {
            HexTileObject hexTileObject = HexTileObjectFinderUtil.FindHexTileObjectFrom(cubeCoordinates);
            if (hexTileObject != null)
            {
                HexTileInformationReport hexTileInformationReport = hexTileObject.GetHexTileInformationReport();
                if (hexTileInformationReport != null)
                {
                    HexTileAttributes hexTileAttributes = hexTileInformationReport.GetHexTileAttributes();
                    if (hexTileAttributes != null)
                    {
                        return hexTileAttributes.GetFireCost();
                    }
                    else
                    {
                        logger.Warn("Unable GetTileObjectPathCost. {} is null.", typeof(HexTileAttributes));
                    }
                }
                else
                {
                    logger.Warn("Unable GetTileObjectPathCost. {} is null.", typeof(HexTileInformationReport));
                }
            }
            else
            {
                logger.Warn("Unable GetTileObjectPathCost. {} is null.", typeof(HexTileObject));
            }
        }
        else
        {
            logger.Warn("Unable GetTileObjectPathCost. {} is null.", typeof(CubeCoordinates));
        }
        return int.MaxValue;
    }

    #endregion Protected Methods
}