using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public abstract class PathFinderAbstract
    : PathFinder
{
    #region Protected Fields

    protected CubeCoordinates cubeCoordinatesStart;
    protected Dictionary<CubeCoordinates, PathObject> pathObjectDictionary = new Dictionary<CubeCoordinates, PathObject>();

    #endregion Protected Fields

    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Constructors

    public PathFinderAbstract(CubeCoordinates cubeCoordinatesStart)
    {
        this.cubeCoordinatesStart = cubeCoordinatesStart;
    }

    #endregion Public Constructors

    #region Public Methods

    public override HashSet<CubeCoordinates> GetCubeCoordiantesEndSet()
    {
        return new HashSet<CubeCoordinates>(this.pathObjectDictionary.Keys);
    }

    public override Dictionary<CubeCoordinates, PathObject> GetPathObjectDictionary()
    {
        return new Dictionary<CubeCoordinates, PathObject>(this.pathObjectDictionary);
    }

    public override PathObject GetPathObjectForCubeCoordinatesEnd(CubeCoordinates cubeCoordinatesEnd)
    {
        if (cubeCoordinatesEnd != null)
        {
            if (this.pathObjectDictionary.ContainsKey(cubeCoordinatesEnd))
            {
                return this.pathObjectDictionary[cubeCoordinatesEnd];
            }
            else
            {
                logger.Warn("Unable to get PathObject for CubeCoordinates. Parameterized CubeCoordinates=? has no associated PathObject.", cubeCoordinatesEnd);
            }
        }
        else
        {
            logger.Warn("Unable to get PathObject for CubeCoordinates. Parameterized CubeCoordinates is null.");
        }
        return null;
    }

    #endregion Public Methods
}