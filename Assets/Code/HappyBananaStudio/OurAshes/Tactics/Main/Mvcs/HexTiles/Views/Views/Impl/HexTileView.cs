using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.ResourceLoaders.Materials;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Scripts.Unity.Abs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Common.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Views.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Views.Views.Api;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Views.Views.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public class HexTileView
        : AbstractUnityScript, IHexTileView
    {
        // Todo
        private ICubeCoordinates cubeCoordinates;

        // Todo
        [SerializeField] private HexTileType hexTileType;

        /// <inheritdoc/>
        ICubeCoordinates IHexTileView.GetCubeCoordinates()
        {
            return this.cubeCoordinates;
        }

        /// <inheritdoc/>
        HexTileType IHexTileView.GetHexTileType()
        {
            return this.hexTileType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        private void SetCubeCoordinates(ICubeCoordinates cubeCoordinates)
        {
            this.cubeCoordinates = cubeCoordinates;
            this.transform.localPosition = HexTileViewWorldPositionUtil
                .CubeCoordinatesToWorldVector(this.cubeCoordinates);
            // Todo: Move the HexTile gameObject to the proper location here
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileType"></param>
        private void SetHexTileType(HexTileType hexTileType)
        {
            this.hexTileType = hexTileType;
            Material material = MaterialResourceLoader.HexTile.Top.LoadMaterial(this.hexTileType);
            MeshRenderer meshRenderer = this.GetComponent<MeshRenderer>();
            Material[] materialArray = meshRenderer.materials;
            materialArray[1] = material;
            meshRenderer.materials = materialArray;
            // Todo: Add doodads when more competant
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ICubeCoordinates cubeCoordinates = null;

            // Todo
            private HexTileType hexTileType = HexTileType.None;

            // Todo
            private Transform parentTransform = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IHexTileView Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    HexTileView hexTile = HexTileViewConstructorUtil
                        .ConstructGameObject(this.hexTileType, this.cubeCoordinates)
                        .AddComponent<HexTileView>();
                    hexTile.GetTransform().SetParent(this.parentTransform);
                    hexTile.SetHexTileType(this.hexTileType);
                    hexTile.SetCubeCoordinates(this.cubeCoordinates);
                    return hexTile;
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="cubeCoordinates"></param>
            /// <returns></returns>
            public Builder SetCubeCoordinates(ICubeCoordinates cubeCoordinates)
            {
                this.cubeCoordinates = cubeCoordinates;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="hexTileType"></param>
            /// <returns></returns>
            public Builder SetHexTileType(HexTileType hexTileType)
            {
                this.hexTileType = hexTileType;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="parentTransform"></param>
            /// <returns></returns>
            public Builder SetParentTransform(Transform parentTransform)
            {
                this.parentTransform = parentTransform;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                if (this.cubeCoordinates == null)
                {
                    argumentExceptionSet.Add(typeof(ICubeCoordinates).Name + " cannot be null.");
                }
                if (this.hexTileType == HexTileType.None)
                {
                    argumentExceptionSet.Add(typeof(HexTileType).Name + " cannot be null.");
                }
                if (this.parentTransform == null)
                {
                    argumentExceptionSet.Add("Parent " + typeof(Transform).Name + " cannot be null.");
                }

                return argumentExceptionSet;
            }
        }
    }
}