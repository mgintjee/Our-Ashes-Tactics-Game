using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Todo
/// </summary>
public class TalonObjectPainterUtil
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="mechGameObject"></param>
    /// <param name="tileObjectType"></param>
    public static void PaintMechGameObjectBase(TalonObject talonObject, HexTileTypeEnum tileObjectType)
    {
        if (talonObject != null &&
            !tileObjectType.Equals(HexTileTypeEnum.NULL))
        {
            TalonScript talonScript = talonObject.GetTalonScript();
            if (talonScript != null)
            {
                GameObject talonGameObject = talonScript.GetGameObject();
                if (talonGameObject != null)
                {
                    // Todo: Clean this crap up as well
                    Material colorMaterial = MaterialResourceLoader.HexTile.Top.LoadHexTileTopMaterialResource(tileObjectType);
                    GameObject talonLegsGameObject = talonGameObject.transform.GetChild(0).GetChild(0).gameObject;
                    string gameObjectName = talonLegsGameObject.name;
                    int paintIndex = TalonPaintConstants.GetTilePaintIndexForName(gameObjectName);
                    PaintGameObject(talonLegsGameObject, paintIndex, colorMaterial);
                }
                else
                {
                    throw new ArgumentException("Unable to PaintTalonObject. Invalid Parameters." +
                        "\n>" + typeof(GameObject) + " is null: " + (talonGameObject == null));
                }
            }
            else
            {
                throw new ArgumentException("Unable to PaintTalonObject. Invalid Parameters." +
                    "\n>" + typeof(TalonScript) + " is null: " + (talonScript == null));
            }
        }
        else
        {
            throw new ArgumentException("Unable to PaintTalonObject. Invalid Parameters." +
                "\n>" + typeof(TalonObject) + " is null: " + (talonObject == null) +
                "\n>" + typeof(HexTileTypeEnum) + " is invalid.");
        }
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="mechGameObject">   </param>
    /// <param name="primaryPaintColor"></param>
    public static void PaintTalonObject(TalonObject talonObject, TalonPaintSchemeReport talonPaintSchemeReport)
    {
        if (talonObject != null &&
            talonPaintSchemeReport != null)
        {
            TalonScript talonScript = talonObject.GetTalonScript();
            if (talonScript != null)
            {
                GameObject talonGameObject = talonScript.GetGameObject();
                if (talonGameObject != null)
                {
                    Material colorMaterial = MaterialResourceLoader.Paint.LoadPaintMaterialResource(talonPaintSchemeReport.GetPrimaryPaintColor());
                    if (colorMaterial != null)
                    {
                        RecursivelyPaintGameObject(talonGameObject, colorMaterial);
                    }
                    else
                    {
                        logger.Warn("Unable to PaintTalonObject. ? is not supported.", talonPaintSchemeReport.GetPrimaryPaintColor());
                    }
                }
                else
                {
                    throw new ArgumentException("Unable to PaintTalonObject. Invalid Parameters." +
                        "\n>" + typeof(GameObject) + " is null: " + (talonGameObject == null));
                }
            }
            else
            {
                throw new ArgumentException("Unable to PaintTalonObject. Invalid Parameters." +
                    "\n>" + typeof(TalonScript) + " is null: " + (talonScript == null));
            }
        }
        else
        {
            throw new ArgumentException("Unable to PaintTalonObject. Invalid Parameters." +
                "\n>" + typeof(TalonObject) + " is null: " + (talonObject == null) +
                "\n>" + typeof(TalonPaintSchemeReport) + " is null: " + (talonPaintSchemeReport == null));
        }
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
                : TalonPaintConstants.GetPaintIndexForName(gameObjectName);
            PaintGameObject(gameObject, paintIndex, material);

            foreach (Transform childTransform in gameObject.transform)
            {
                RecursivelyPaintGameObject(childTransform.gameObject, material);
            }
        }
    }

    #endregion Private Methods
}