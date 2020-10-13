/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>

namespace HappyBananaStudio.OurAshesTactics.Common.Utils.HexTiles
{
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Common.ResourceLoaders;
    using HappyBananaStudio.OurAshesTactics.Common.ResourceLoaders;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Coordinates;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public static class HexTileGameObjectBuilderUtil
    {
        // Todo
        private static readonly IDictionary<int, GameObject> layerLevelGameObjectDictionary = new Dictionary<int, GameObject>();

        // Todo
        private static readonly string layerGameObjectCollectionName = "layerGameObjectCollection";

        // Todo
        private static readonly string layerLevelGameObjectPrefix = "layerLevel: ";

        // Todo
        private static GameObject layerGameObjectCollection = null;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileConstructionReport">
        /// </param>
        /// <returns>
        /// </returns>
        public static void BuildHexTileGameObject(IHexTileConstructionReport hexTileConstructionReport)
        {
            BuildLayerGameObjectCollection();
            if (hexTileConstructionReport != null)
            {
                GameObject hexTileGameObject = GameObjectResourceLoader.HexTiles
                    .LoadHexTileGameObjectResource();
                MeshRenderer meshRenderer = hexTileGameObject.GetComponent<MeshRenderer>();
                meshRenderer.materials[1] = MaterialResourceLoader.HexTile.Top.LoadHexTileTopMaterialResource(
                    hexTileConstructionReport.GetHexTileType());
                hexTileGameObject.name = hexTileConstructionReport.GetCubeCoordinates().ToString();
                int hexTileLayerLevel = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFromCenter(
                    hexTileConstructionReport.GetCubeCoordinates());
                BuildLayerGameObject(hexTileLayerLevel);
                hexTileGameObject.transform.SetParent(layerLevelGameObjectDictionary[hexTileLayerLevel].transform);
                hexTileGameObject.transform.position = CubeCoordinatesPositionUtil.CubeCoordinatesToWorldVector(
                    hexTileConstructionReport.GetCubeCoordinates());
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid parameters. ? is null.",
                    new StackFrame().GetMethod().Name, typeof(IHexTileConstructionReport));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileLayerLevel">
        /// </param>
        private static void BuildLayerGameObject(int hexTileLayerLevel)
        {
            if (!layerLevelGameObjectDictionary.ContainsKey(hexTileLayerLevel))
            {
                GameObject layerGameObject = new GameObject(layerLevelGameObjectPrefix + hexTileLayerLevel);
                layerGameObject.transform.SetParent(layerGameObjectCollection.transform);
                layerLevelGameObjectDictionary.Add(hexTileLayerLevel, layerGameObject);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        private static void BuildLayerGameObjectCollection()
        {
            if (layerGameObjectCollection == null)
            {
                layerGameObjectCollection = new GameObject(layerGameObjectCollectionName);
            }
        }
    }
}
