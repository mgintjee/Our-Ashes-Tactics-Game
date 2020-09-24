/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.ResourceLoader;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Constants;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Constants;
using HappyBananaStudio.OurAshesTactics.Talon.Object.Api;
using System;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Util
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TalonObjectPainterUtil
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonObject">   </param>
        /// <param name="tileObjectType"></param>
        public static void PaintMechGameObjectBase(ITalonObject talonObject, HexTileTypeEnum tileObjectType)
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
                        string gameObjectName = talonGameObject.name;
                        int paintIndex = TalonPaintConstants.GetTilePaintIndexForName(gameObjectName);
                        if (paintIndex >= 0)
                        {
                            PaintGameObject(talonGameObject, paintIndex, colorMaterial);
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Unable to PaintTalonObject. Invalid Parameters." +
                            "\n\t>" + typeof(GameObject) + " is null: " + (talonGameObject == null));
                    }
                }
                else
                {
                    throw new ArgumentException("Unable to PaintTalonObject. Invalid Parameters." +
                        "\n\t>" + typeof(TalonScript) + " is null: " + (talonScript == null));
                }
            }
            else
            {
                throw new ArgumentException("Unable to PaintTalonObject. Invalid Parameters." +
                    "\n\t>" + typeof(ITalonObject) + " is null: " + (talonObject == null) +
                    "\n\t>" + typeof(HexTileTypeEnum) + " is invalid.");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mechGameObject">   </param>
        /// <param name="primaryPaintColor"></param>
        public static void PaintTalonObject(ITalonObject talonObject, TalonPaintSchemeReport talonPaintSchemeReport)
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
                            "\n\t>" + typeof(GameObject) + " is null: " + (talonGameObject == null));
                    }
                }
                else
                {
                    throw new ArgumentException("Unable to PaintTalonObject. Invalid Parameters." +
                        "\n\t>" + typeof(TalonScript) + " is null: " + (talonScript == null));
                }
            }
            else
            {
                throw new ArgumentException("Unable to PaintTalonObject. Invalid Parameters." +
                    "\n\t>" + typeof(ITalonObject) + " is null: " + (talonObject == null) +
                    "\n\t>" + typeof(TalonPaintSchemeReport) + " is null: " + (talonPaintSchemeReport == null));
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
            else
            {
                throw new ArgumentException("Unable to PaintGameObject. Invalid Parameters." +
                    "\n\t>" + typeof(GameObject) + " is null: " + (gameObject == null) +
                    "\n\t>paintIndex is invalid: " + (paintIndex) +
                    "\n\t>" + typeof(Material) + " is null: " + (material == null));
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
                    : TalonPaintConstants.GetPaintIndexForTalonName(gameObjectName);

                logger.Debug("Paint GO=?, Mat=?, PaintIndex=?", gameObjectName, material, paintIndex);
                if (paintIndex >= 0)
                {
                    PaintGameObject(gameObject, paintIndex, material);
                }

                foreach (Transform childTransform in gameObject.transform)
                {
                    RecursivelyPaintGameObject(childTransform.gameObject, material);
                }
            }
        }

        #endregion Private Methods
    }
}