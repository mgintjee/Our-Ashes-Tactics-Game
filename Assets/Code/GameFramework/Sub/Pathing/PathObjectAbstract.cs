using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public abstract class PathObjectAbstract
    : PathObject
{
    #region Protected Fields

    protected int pathObjectCost = int.MaxValue;

    protected CubeCoordinates tileCoordinatesEnd;

    protected CubeCoordinates tileCoordinatesStart;

    protected List<CubeCoordinates> tileCoordinatesStepList = new List<CubeCoordinates>();

    #endregion Protected Fields

    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Constructors

    public PathObjectAbstract(CubeCoordinates tileCoordinatesStart, CubeCoordinates tileCoordinatesEnd, int pathLength)
    {
        if (tileCoordinatesStart != null &&
            tileCoordinatesEnd != null &&
            pathLength > 0)
        {
            List<CubeCoordinates> tileCoordinatesStepList = new List<CubeCoordinates>
            {
                tileCoordinatesStart
            };
            for (int i = 1; i < pathLength - 1; ++i)
            {
                tileCoordinatesStepList.Add(null);
            }
            tileCoordinatesStepList.Add(tileCoordinatesEnd);

            this.SetAttributes(tileCoordinatesStepList, tileCoordinatesStart, tileCoordinatesEnd);
        }
        else
        {
            logger.Warn("Unable To Construct PathObject. List: TileCoordinates is null or not populated fully.");
        }
    }

    public PathObjectAbstract(List<CubeCoordinates> tileCoordinatesStepList)
    {
        if (tileCoordinatesStepList != null &&
            tileCoordinatesStepList.Count > 0)
        {
            int listLength = tileCoordinatesStepList.Count;
            CubeCoordinates cubeCoordinatesStart = tileCoordinatesStepList[0];
            CubeCoordinates cubeCoordinatesEnd = tileCoordinatesStepList[listLength - 1];
            int minimumPathDistance = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFrom(cubeCoordinatesStart, cubeCoordinatesEnd);
            if (listLength >= minimumPathDistance)
            {
                this.SetAttributes(tileCoordinatesStepList, cubeCoordinatesStart, cubeCoordinatesEnd);
            }
            else
            {
                logger.Warn("Unable To Construct PathObject. List: TileObject is not the minimum distance.");
            }
        }
        else
        {
            logger.Warn("Unable To Construct PathObject. List: TileCoordinates is null or not populated fully.");
        }
    }

    public PathObjectAbstract(PathObject pathObject)
    {
        if (PathObjectValidatorUtil.ValidPathObject(pathObject))
        {
            this.SetAttributes(
                pathObject.GetCubeCoordinatesStepList(),
                pathObject.GetCubeCoordinatesStart(),
                pathObject.GetCubeCoordinatesEnd());
        }
        else
        {
            logger.Warn("Unable To Construct PathObject. Parameterized PathObject is invalid.");
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override CubeCoordinates GetCubeCoordinatesEnd()
    {
        return this.tileCoordinatesEnd;
    }

    public override CubeCoordinates GetCubeCoordinatesStart()
    {
        return this.tileCoordinatesStart;
    }

    public override List<CubeCoordinates> GetCubeCoordinatesStepList()
    {
        return new List<CubeCoordinates>(this.tileCoordinatesStepList);
    }

    public override int GetPathObjectCost()
    {
        return this.pathObjectCost;
    }

    public override int GetPathObjectLength()
    {
        return this.GetCubeCoordinatesStepList().Count;
    }

    public override bool IsValid()
    {
        return PathObjectValidatorUtil.ValidPathObject(this);
    }

    public override string ToString()
    {
        return string.Join(", ", this.tileCoordinatesStepList);
    }

    #endregion Public Methods

    #region Protected Methods

    protected void CalculatePathCost()
    {
        this.pathObjectCost = 0;

        for (int i = 1; i < this.GetPathObjectLength(); ++i)
        {
            if (this.GetCubeCoordinatesStepList()[i] != null)
            {
                this.pathObjectCost += this.GetTileObjectPathCost(this.GetCubeCoordinatesStepList()[i]);
            }
            else
            {
                this.pathObjectCost += int.MaxValue;
            }
        }
    }

    protected abstract int GetTileObjectPathCost(CubeCoordinates tileCoordinates);

    #endregion Protected Methods

    #region Private Methods

    private void SetAttributes(List<CubeCoordinates> tileCoordinatesStepList,
                                            CubeCoordinates tileCoordinatesStart,
        CubeCoordinates tileCoordinatesEnd)
    {
        this.tileCoordinatesStepList = new List<CubeCoordinates>(tileCoordinatesStepList);
        this.tileCoordinatesStart = tileCoordinatesStart;
        this.tileCoordinatesEnd = tileCoordinatesEnd;
        this.CalculatePathCost();
    }

    #endregion Private Methods
}