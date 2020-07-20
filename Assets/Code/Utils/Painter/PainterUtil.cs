using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Todo
/// </summary>
public class PainterUtil
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="mechGameObject">   </param>
    /// <param name="primaryPaintColor"></param>
    public static void PaintMechGameObject(GameObject mechGameObject, PaintSchemeReport paintSchemeReport)
    {
        Material colorMaterial = MaterialResourceLoader.Paint.LoadPaintMaterialResource(paintSchemeReport.GetPrimaryPaintColor());
        if (colorMaterial != null)
        {
            RecursivelyPaintGameObject(mechGameObject, colorMaterial);
        }
        else
        {
            logger.Warn("Unable to paint MechGameObject. ? is not supported.", paintSchemeReport.GetPrimaryPaintColor());
        }
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="mechGameObject"></param>
    /// <param name="tileObjectType"></param>
    public static void PaintMechGameObjectBase(GameObject mechGameObject, TileTypeEnum tileObjectType)
    {
        // Todo: Clean this crap up as well
        Material colorMaterial = MaterialResourceLoader.Tile.Top.LoadTileTopMaterialResource(tileObjectType);
        GameObject mechLegsGameObject = mechGameObject.transform.GetChild(0).GetChild(0).gameObject;
        string gameObjectName = mechLegsGameObject.name;
        int paintIndex = MechPaintConstants.GetTilePaintIndexForMechName(gameObjectName);
        logger.Debug("Painting Base=? for Mech=?, Index=?, Material=?", gameObjectName, tileObjectType, paintIndex, colorMaterial);
        PaintGameObject(mechLegsGameObject, paintIndex, colorMaterial);
    }

    #endregion Public Methods

    #region Private Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="paintIndex"></param>
    /// <param name="material">  </param>
    private static void PaintGameObject(GameObject gameObject, int paintIndex, Material material)
    {
        if (paintIndex >= 0 &&
            gameObject != null &&
            material != null)
        {
            MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                Material[] materialArray = meshRenderer.materials;
                materialArray[paintIndex] = material;
                meshRenderer.materials = materialArray;
            }
            else
            {
                logger.Warn("Unable to paint gameObject. MeshRenderer is null.");
            }
        }
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="material">  </param>
    private static void RecursivelyPaintGameObject(GameObject gameObject, Material material)
    {
        // Check that the parameters are non-null
        if (gameObject != null &&
            material != null)
        {
            string gameObjectName = gameObject.name;
            int paintIndex = (gameObjectName.Contains(WeaponPaintConstants.GetWeaponKeyword()))
                ? WeaponPaintConstants.GetPaintIndexForWeaponName(gameObjectName)
                : MechPaintConstants.GetMechPaintIndexForMechName(gameObjectName);
            PaintGameObject(gameObject, paintIndex, material);

            foreach (Transform childTransform in gameObject.transform)
            {
                RecursivelyPaintGameObject(childTransform.gameObject, material);
            }
        }
    }

    #endregion Private Methods
}