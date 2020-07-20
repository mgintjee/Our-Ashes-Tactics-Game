using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// View Object Impl
/// </summary>
public class ViewObjectImpl
    : ViewObject
{
    #region Protected Fields

    protected GameFrameworkObject gameFrameworkObject;
    protected Dictionary<CubeCoordinates, TileObject> tileCoordsTileObjectDictionary;

    #endregion Protected Fields

    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private ViewScript mapScript;
    private HashSet<CubeCoordinates> validTileCoordinatesSet = new HashSet<CubeCoordinates>();

    #endregion Private Fields

    #region Public Constructors

    public ViewObjectImpl(GameFrameworkObject gameFrameworkObject)
    {
        this.gameFrameworkObject = gameFrameworkObject;
        Random.InitState(this.gameFrameworkObject.GetMapModelSeed());
        this.gameFrameworkObject.SetMapModelObject(this);
        this.mapScript = this.gameFrameworkObject.GetGameFrameworkScript().GetMapModelScript();
        CubeCoordinatesGeneratorUtil.GenerateCubeCoordinatesSet(this.gameFrameworkObject.GetMapModelRadius());
        this.tileCoordsTileObjectDictionary = new Dictionary<CubeCoordinates, TileObject>();
        TileObjectFinderUtil.SetMapModelObject(this);
        this.GenerateTileObjectSet();
    }

    #endregion Public Constructors

    #region Public Methods

    public override void AddNewMechObject(MechObject mechObject, int team, int position)
    {
        int mapModelRadius = this.gameFrameworkObject.GetMapModelRadius();
        int maxMechPerTeam = this.gameFrameworkObject.GetMaxMechPerTeam();
        if (position > -1 && position < maxMechPerTeam)
        {
            CubeCoordinates mechStartingTileCoordinates = this.CalculateMechSpawnCoordinates(mapModelRadius, maxMechPerTeam, position);
            if (team == 1)
            {
                mechStartingTileCoordinates = CubeCoordinatesCommonUtil.GetNegatedCubeCoordinates(mechStartingTileCoordinates);
            }
            mechObject.SetCubeCoordinates(mechStartingTileCoordinates);
            TileObject tileObject = TileObjectFinderUtil.FindTileObjectFrom(mechStartingTileCoordinates);
            tileObject.SetOccupyingMechObject(mechObject);
        }
    }

    public override void GenerateTileObjectSet()
    {
        HashSet<TileInfoReport> tileInfoReportSet = this.GenerateTileInfoReportSet(this.gameFrameworkObject.GetMapModelRadius());
        foreach (TileInfoReport tileInfoReport in tileInfoReportSet)
        {
            this.GenerateTileObject(tileInfoReport);
        }
    }

    public override ViewScript GetMapModelScript()
    {
        return this.mapScript;
    }

    public override Dictionary<CubeCoordinates, TileObject> GetTileCoordsTileObjectDictionary()
    {
        return new Dictionary<CubeCoordinates, TileObject>(this.tileCoordsTileObjectDictionary);
    }

    public override HashSet<CubeCoordinates> GetValidTileCoordinatesSet()
    {
        return new HashSet<CubeCoordinates>(this.validTileCoordinatesSet);
    }

    #endregion Public Methods

    #region Private Methods

    private CubeCoordinates CalculateMechSpawnCoordinates(int mapModelRadius, int maxMechPerTeam, int mechPosition)
    {
        // The Middle of the spawning zone is (0, (+/-) Radius, (+/-) Radius)
        int middleSpawnPosition = maxMechPerTeam / 2;
        int positionDifference = Mathf.Abs(mechPosition - middleSpawnPosition);
        int newPositionValue = mapModelRadius - positionDifference;
        int xCoordinate;
        int yCoordinate;
        int zCoordinate;
        if (mechPosition < middleSpawnPosition)
        {
            xCoordinate = -positionDifference;
            yCoordinate = mapModelRadius;
            zCoordinate = -newPositionValue;
        }
        else if (mechPosition > middleSpawnPosition)
        {
            xCoordinate = positionDifference;
            yCoordinate = newPositionValue;
            zCoordinate = -mapModelRadius;
        }
        else
        {
            xCoordinate = 0;
            yCoordinate = mapModelRadius;
            zCoordinate = -mapModelRadius;
        }
        logger.Debug("middleSpawn=?, posDiff=?, mechPos=?", middleSpawnPosition, positionDifference, mechPosition);
        logger.Debug("xCoordinate=?, yCoordinate=?, zCoordinate=?", xCoordinate, yCoordinate, zCoordinate);
        return new CubeCoordinates(xCoordinate, yCoordinate, zCoordinate);
    }

    private HashSet<TileInfoReport> GenerateTileInfoReportSet(int mapRadius)
    {
        this.validTileCoordinatesSet = CubeCoordinatesGeneratorUtil.GenerateCubeCoordinatesSet(mapRadius);
        HashSet<TileInfoReport> tileInfoReportSet = TileInfoReportGeneratorUtil.GenerateTileInfoReportSet(
            validTileCoordinatesSet, this.gameFrameworkObject.GetMapModelIsMirrored());
        return tileInfoReportSet;
    }

    private void GenerateTileObject(TileInfoReport tileInfoReport)
    {
        logger.Debug("Generating TileObject for : ?", tileInfoReport);
        GameObject tileGameObject = GameObjectSpawnerUtil.SpawnTile();
        TileScript tileScript = tileGameObject.AddComponent<TileScriptImpl>();
        tileScript.Initialize(tileInfoReport);
        tileCoordsTileObjectDictionary[tileInfoReport.GetCubeCoordinates()] = tileScript.GetTileObject();

        int tileObjectLayerLevel = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFromCenter(tileInfoReport.GetCubeCoordinates());
        Transform mapModelGameObjectTransform = this.GetMapModelScript().GetGameObject().transform;

        // Todo: Store prefix into constants file
        Transform mapModelTileCollectionTransform = mapModelGameObjectTransform.Find("TileCollection");
        if (mapModelTileCollectionTransform == null)
        {
            logger.Debug("Generating MapModel TileCollection");
            GameObject mapModelTileCollection = new GameObject("TileCollection");
            mapModelTileCollection.transform.parent = mapModelGameObjectTransform;
            mapModelTileCollectionTransform = mapModelTileCollection.transform;
        }
        // Todo: Store prefix into constants file
        Transform mapModelLayerLevelTransform = mapModelTileCollectionTransform.Find("LayerLevel:" + tileObjectLayerLevel.ToString());
        if (mapModelLayerLevelTransform == null)
        {
            logger.Debug("Generating MapModel LayerLevel for LayerLevel=?", tileObjectLayerLevel);
            GameObject mapModelLayerLevel = new GameObject("LayerLevel:" + tileObjectLayerLevel.ToString());
            mapModelLayerLevel.transform.parent = mapModelTileCollectionTransform;
            mapModelLayerLevelTransform = mapModelLayerLevel.transform;
        }
        tileGameObject.transform.parent = mapModelLayerLevelTransform;
    }

    #endregion Private Methods
}