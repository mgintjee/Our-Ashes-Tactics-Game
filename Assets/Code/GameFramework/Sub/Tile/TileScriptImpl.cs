using System.Diagnostics;
using UnityEngine;

/// <summary>
/// TileScript Impl
/// </summary>
public class TileScriptImpl
    : TileScript
{
    #region Protected Fields

    // Todo
    protected TileObject tileObject;

    #endregion Protected Fields

    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    ////////////////////////
    // TileScript Methods
    ////////////////////////

    #region Public Methods

    public override CubeCoordinates GetCubeCoordinates()
    {
        return this.GetTileInfoReport().GetCubeCoordinates();
    }

    public override TileBehavior GetTileBehavior()
    {
        return this.GetTileObject().GetTileBehavior();
    }

    public override TileInfoReport GetTileInfoReport()
    {
        return this.GetTileObject().GetTileInfoReport();
    }

    public override TileObject GetTileObject()
    {
        return this.tileObject;
    }

    public override TileTypeEnum GetTileObjectType()
    {
        return this.GetTileInfoReport().GetTileObjectType();
    }

    public override TileVisual GetTileVisual()
    {
        return this.GetTileObject().GetTileVisual();
    }

    /// <summary>
    /// TileScript method, to initialize the TileScript
    /// </summary>
    public override void Initialize(TileInfoReport tileInfoReport)
    {
        logger.Debug("Initializing Script=? with: ?",
            this.GetType().ToString(), tileInfoReport.ToString());

        this.tileObject = new TileObjectImpl(this, tileInfoReport);
        this.UpdateTilePosition();
        this.name = TileScriptConstants.GetTileGameObjectNamePrefix() +
            this.tileObject.GetCubeCoordinates().ToString();

        logger.Debug("Initialized Script=? with: ?",
            this.GetType().ToString(), tileInfoReport.ToString());
    }

    #endregion Public Methods

    #region Private Methods

    private void UpdateTilePosition()
    {
        Vector3 tileGameObjectWorldPosition = CubeCoordinatesPositionUtil.CubeCoordinatesToWorldVector(this.GetCubeCoordinates());
        this.transform.position = tileGameObjectWorldPosition;
    }

    #endregion Private Methods
}