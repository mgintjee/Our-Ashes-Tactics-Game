using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// HexTile Visual Impl
/// </summary>
public class HexTileVisualImpl
    : HexTileVisual
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly HexTileObject hexTileObject;
    private MeshRenderer meshRenderer;

    #endregion Private Fields

    #region Public Constructors

    public HexTileVisualImpl(HexTileObject hexTileObject)
    {
        if (hexTileObject != null)
        {
            this.hexTileObject = hexTileObject;
            this.CollectMeshRenderer();
            this.PaintHexTileTopMaterial();
        }
        else
        {
            throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                "\n\t>" + typeof(HexTileObject) + " is null: " + (hexTileObject == null));
        }
    }

    #endregion Public Constructors

    #region Private Methods

    private void CollectMeshRenderer()
    {
        if (this.hexTileObject != null)
        {
            HexTileScript hexTileScript = this.hexTileObject.GetHexTileScript();
            if (hexTileScript != null)
            {
                GameObject tileGameObject = hexTileScript.GetGameObject();
                if (tileGameObject != null)
                {
                    if (tileGameObject.GetComponent<MeshRenderer>())
                    {
                        this.meshRenderer = tileGameObject.GetComponent<MeshRenderer>();
                    }
                    else
                    {
                        logger.Error("Unable to SetCollectMeshRenderer. ? is null.", typeof(MeshRenderer));
                    }
                }
                else
                {
                    logger.Error("Unable to SetCollectMeshRenderer. ? is null.", typeof(GameObject));
                }
            }
            else
            {
                logger.Error("Unable to SetCollectMeshRenderer. ? is null.", typeof(HexTileScript));
            }
        }
        else
        {
            logger.Error("Unable to SetCollectMeshRenderer. ? is null.", typeof(HexTileObject));
        }
    }

    private void PaintHexTileTopMaterial()
    {
        HexTileTypeEnum hexTileType = this.hexTileObject.GetHexTileType();
        Material material = MaterialResourceLoader.HexTile.Top.LoadHexTileTopMaterialResource(hexTileType);
        //TileObjectMaterialUtil.GetTileObjectTopTypeMaterial(tileObjectType);
        if (this.meshRenderer != null)
        {
            // Collect the material for what is occupying it, thos I should make that a parameter
            Material[] materialArray = this.meshRenderer.materials;
            // TODO: Store the integer in the constants file
            materialArray[1] = material;
            this.meshRenderer.materials = materialArray;
        }
        else
        {
            logger.Error("Unable to PaintHexTileTopMaterial. ? is null.", typeof(MeshRenderer));
        }
    }

    #endregion Private Methods

    /// Todo: Have a method to paint the bottom of the tile
}