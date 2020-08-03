using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// HexTile Script Impl
/// </summary>
public class HexTileScriptImpl
    : HexTileScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private HexTileConstructionReport hexTileConstructionReport = null;
    private HexTileObject hexTileObject = null;

    #endregion Private Fields

    #region Public Methods

    public override HexTileObject GetHexTileObject()
    {
        return this.hexTileObject;
    }

    public override void Initialize(HexTileConstructionReport hexTileConstructionReport)
    {
        if (!this.IsInitialized())
        {
            if (hexTileConstructionReport != null)
            {
                logger.Info("Initializing: ?", this.GetType());
                this.hexTileConstructionReport = hexTileConstructionReport;

                this.hexTileObject = new HexTileObjectImpl(this, this.hexTileConstructionReport);
                this.UpdateTilePosition();
                this.SetGameObjectName();
            }
            else
            {
                throw new ArgumentException("Unable to initialize " + this.GetType() + ". Invalid Parameters." +
                    "\n>" + typeof(HexTileConstructionReport) + "=" + hexTileConstructionReport);
            }
        }
        else
        {
            logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
        }
    }

    public override bool IsInitialized()
    {
        return this.hexTileConstructionReport != null &&
            this.hexTileObject != null;
    }

    #endregion Public Methods

    #region Private Methods

    private void SetGameObjectName()
    {
        this.name = HexTileScriptConstants.GetHexTileGameObjectNamePrefix() +
            this.hexTileConstructionReport.GetCubeCoordinates().ToString();
    }

    private void UpdateTilePosition()
    {
        Vector3 tileGameObjectWorldPosition = CubeCoordinatesPositionUtil.CubeCoordinatesToWorldVector(
            this.hexTileConstructionReport.GetCubeCoordinates());
        this.transform.position = tileGameObjectWorldPosition;
    }

    #endregion Private Methods
}