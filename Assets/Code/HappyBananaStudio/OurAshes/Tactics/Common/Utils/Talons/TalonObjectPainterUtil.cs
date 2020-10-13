/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>

namespace HappyBananaStudio.OurAshesTactics.Common.Utils.Talons
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.HexTiles.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Talons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Weapons;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using System;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class TalonObjectPainterUtil
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonObject">
        /// </param>
        /// <param name="tileObjectType">
        /// </param>
        public static void PaintMechGameObjectBase(ITalonObject talonObject, HexTileTypeEnum tileObjectType)
        {
            if (talonObject != null &&
                !tileObjectType.Equals(HexTileTypeEnum.None))
            {
                /*
                ITalonScript talonScript = talonObject.GetTalonScript();
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
                        "\n\t>" + typeof(ITalonScript) + " is null: " + (talonScript == null));
                }
                */
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
        /// <param name="mechGameObject">
        /// </param>
        /// <param name="primaryPaintColor">
        /// </param>
        public static void PaintTalonObject(ITalonObject talonObject, IColorSchemeReport talonPaintSchemeReport)
        {
            if (talonObject != null &&
                talonPaintSchemeReport != null)
            {
                /*
                ITalonScript talonScript = talonObject.GetTalonScript();
                if (talonScript != null)
                {
                    GameObject talonGameObject = talonScript.GetGameObject();
                    if (talonGameObject != null)
                    {
                        Material colorMaterial = MaterialResourceLoader.Color.LoadColorMaterialResource(
                            talonPaintSchemeReport.GetPrimaryPaintColorId());
                        if (colorMaterial != null)
                        {
                            RecursivelyPaintGameObject(talonGameObject, colorMaterial);
                        }
                        else
                        {
                            logger.Warn("Unable to PaintTalonObject. ? is not supported.",
                                talonPaintSchemeReport.GetPrimaryPaintColorId());
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
                        "\n\t>" + typeof(ITalonScript) + " is null: " + (talonScript == null));
                }
                */
            }
            else
            {
                throw new ArgumentException("Unable to PaintTalonObject. Invalid Parameters." +
                    "\n\t>" + typeof(ITalonObject) + " is null: " + (talonObject == null) +
                    "\n\t>" + typeof(IColorSchemeReport) + " is null: " + (talonPaintSchemeReport == null));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameObject">
        /// </param>
        /// <param name="paintIndex">
        /// </param>
        /// <param name="material">
        /// </param>
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
        /// <param name="gameObject">
        /// </param>
        /// <param name="material">
        /// </param>
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
    }
}
