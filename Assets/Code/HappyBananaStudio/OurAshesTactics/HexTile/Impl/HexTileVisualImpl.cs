/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.ResourceLoader;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Enums;
using System;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Impl
{
    /// <summary>
    /// HexTile Visual Impl
    /// </summary>
    public class HexTileVisualImpl
    : IHexTileVisual
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IHexTileObject hexTileObject;

        // Todo
        private MeshRenderer meshRenderer;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileObject"></param>
        public HexTileVisualImpl(IHexTileObject hexTileObject)
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
                    "\n\t>" + typeof(IHexTileObject) + " is null: " + (hexTileObject == null));
            }
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        private void CollectMeshRenderer()
        {
            if (this.meshRenderer == null)
            {
                if (this.hexTileObject != null)
                {
                    HexTileScript hexTileScript = this.hexTileObject.GetHexTileScript();
                    if (hexTileScript != null)
                    {
                        GameObject tileGameObject = hexTileScript.GetGameObject();
                        if (tileGameObject != null)
                        {
                            // Todo: Clean this up when you get bored
                            if (tileGameObject.transform.GetComponent<MeshRenderer>())
                            {
                                this.meshRenderer = tileGameObject.transform.GetComponent<MeshRenderer>();
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
                    logger.Error("Unable to SetCollectMeshRenderer. ? is null.", typeof(IHexTileObject));
                }
            }
            else
            {

            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void PaintHexTileTopMaterial()
        {
            HexTileTypeEnum hexTileType = this.hexTileObject.GetHexTileType();
            Material material = MaterialResourceLoader.HexTile.Top.LoadHexTileTopMaterialResource(hexTileType);
            //TileObjectMaterialUtil.GetTileObjectTopTypeMaterial(tileObjectType);
            if (this.meshRenderer != null)
            {
                // Collect the material for what is occupying it, thought I should make that a parameter
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
    }
}