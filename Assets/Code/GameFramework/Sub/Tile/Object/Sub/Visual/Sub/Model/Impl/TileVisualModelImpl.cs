using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Implementation for TileVisualModel
/// </summary>
public class TileVisualModelImpl
    : TileVisualModel
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Constructors

    public TileVisualModelImpl(TileObject tileObject)
    {
        this.tileObject = tileObject;
        this.SetMeshRenderer();
        this.PaintTopMaterial();
    }

    #endregion Public Constructors

    #region Private Methods

    private void PaintTopMaterial()
    {
        TileObjectTypeEnum tileObjectType = this.tileObject.GetTileObjectType();
        Material material = MaterialResourceLoader.Tile.Top.LoadTileTopMaterialResource(tileObjectType);
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
            logger.Error("Unable to paint Top Material. MeshRenderer is null.");
        }
    }

    private void SetMeshRenderer()
    {
        TileScript tileScript = this.tileObject.GetTileScript();
        if (tileScript != null)
        {
            GameObject tileGameObject = tileScript.GetGameObject();
            if (tileGameObject != null)
            {
                if (tileGameObject.GetComponent<MeshRenderer>())
                {
                    this.meshRenderer = tileGameObject.GetComponent<MeshRenderer>();
                }
                else
                {
                    logger.Error("Unable to Set MeshRenderer. Tile GameObject does not have a MeshRenderer.");
                }
            }
            else
            {
                logger.Error("Unable to Set MeshRenderer. Tile GameObject is null.");
            }
        }
        else
        {
            logger.Error("Unable to Set MeshRenderer. TileScript is null.");
        }
    }

    #endregion Private Methods
}