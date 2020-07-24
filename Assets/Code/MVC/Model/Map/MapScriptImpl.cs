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
        if (mapConstructionReport != null &&
            mcvModelScript != null)
        {
            logger.Info("Initializing Script: ?.", this.GetType());
            if (!this.IsInitialized())
            {
                logger.Info("Setting Report: ?.", typeof(MapConstructionReport));
                this.mapConstructionReport = mapConstructionReport;

                this.BuildLayerLevelGameObjects();

                this.mapObject = new MapObjectImpl(this, mapConstructionReport);
                this.mapObject.Initialize();
            }
            else
            {
                logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
            }
        }
        else
        {
            logger.Error("Unable to Initialize: ?. Invalid Parameters", this.GetType());
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
            GameObject layerLevelGameObject = new GameObject(MvcModelConstants.Script.GetMapLayerLevelGameObjectPrefix() + i);
            layerLevelGameObject.transform.SetParent(this.transform);
        }
    }

    #endregion Private Methods
}