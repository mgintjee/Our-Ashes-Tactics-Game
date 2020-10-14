
namespace HappyBananaStudio.OurAshes.Tactics.Common.Managers.GameObjects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.HexTiles.Enums;
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
    public class HexTileGameObjectManager
    {
        // Todo
        private static readonly IDictionary<int, GameObject> layerLevelGameObjectDictionary = new Dictionary<int, GameObject>();

        // Todo
        private static readonly string layerGameObjectCollectionName = "layerGameObjectCollection";

        // Todo
        private static readonly string layerLevelGameObjectPrefix = "layerLevel: ";

        // Todo
        private static GameObject layerGameObjectCollection = null;

        // Todo
        private static IDictionary<ICubeCoordinates, GameObject> cubeCoordinatesGameObjectDictionary =
            new Dictionary<ICubeCoordinates, GameObject>();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 GetHexTileWorldPosition(ICubeCoordinates cubeCoordinates)
        {
            if (cubeCoordinatesGameObjectDictionary.ContainsKey(cubeCoordinates))
            {
                return cubeCoordinatesGameObjectDictionary[cubeCoordinates].transform.position;
            }
            else
            {
                return CubeCoordinatesPositionUtil.CubeCoordinatesToWorldVector(cubeCoordinates);
            }
        }

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
                int hexTileLayerLevel = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFromCenter(
                    hexTileConstructionReport.GetCubeCoordinates());
                BuildLayerGameObject(hexTileLayerLevel);
                GameObject hexTileGameObject = GameObjectResourceLoader.HexTiles.LoadHexTileGameObjectResource();
                UpdateHexTileGameObjectVisuals(hexTileGameObject, hexTileConstructionReport.GetHexTileType());
                hexTileGameObject.name = hexTileConstructionReport.GetCubeCoordinates().ToString();
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
        /// <param name="hexTileGameObject">
        /// </param>
        /// <param name="hexTileType">
        /// </param>
        private static void UpdateHexTileGameObjectVisuals(GameObject hexTileGameObject, HexTileTypeEnum hexTileType)
        {
            MeshRenderer meshRenderer = hexTileGameObject.GetComponent<MeshRenderer>();
            Material[] materials = meshRenderer.materials;
            materials[1] = MaterialResourceLoader.HexTile.Top.LoadHexTileTopMaterialResource(hexTileType);
            meshRenderer.materials = materials;
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
