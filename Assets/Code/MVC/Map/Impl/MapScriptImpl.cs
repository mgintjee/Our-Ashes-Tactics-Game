using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Map Script Impl
/// </summary>
public class MapScriptImpl
    : MapScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private MapObject mapObject;
    private MapConstructionReport mapConstructionReport;

    #endregion Private Fields

    #region Public Methods

    public override MapInfoReport GetMapInfoReport()
    {
        if (this.mapConstructionReport != null)
        {
            return this.mapConstructionReport.GetMapInfoReport();
        }
        return null;
    }

    public override MapObject GetMapObject()
    {
        return this.mapObject;
    }

    public override void Initialize(MvcModelScript mcvModelScript, MapConstructionReport mapConstructionReport)
    {
        if (mcvModelScript != null &&
            mapConstructionReport != null)
        {
            logger.Info("Initializing: ?.", this.GetType());
            if (!this.IsInitialized())
            {
                logger.Info("Setting: ?.", typeof(MapConstructionReport));
                this.mapConstructionReport = mapConstructionReport;

                this.BuildLayerLevelGameObjects();

                this.mapObject = new MapObjectImpl(this, mapConstructionReport);
            }
            else
            {
                logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
            }
        }
        else
        {
            throw new ArgumentException("Unable to initialize " +
                this.GetType() + ". Invalid Parameters." +
                "\n>mcvModelScript=" + mcvModelScript +
                "\n>mapConstructionReport=" + mapConstructionReport);
        }
    }

    public override bool IsInitialized()
    {
        return this.mapConstructionReport != null &&
            this.mapObject != null;
    }

    #endregion Public Methods

    #region Private Methods

    private void BuildLayerLevelGameObjects()
    {
        for (int i = 0; i < this.mapConstructionReport.GetMapRadius() + 1; ++i)
        {
            GameObject layerLevelGameObject = new GameObject(MapConstants.Script.GetMapLayerLevelGameObjectPrefix() + i);
            layerLevelGameObject.transform.SetParent(this.transform);
        }
    }

    #endregion Private Methods
}