using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.ResourceLoaders.GameObjects;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Common.Types.Enums;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Views.Utils
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class HexTileViewConstructorUtil
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileType"></param>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        public static GameObject ConstructGameObject(HexTileType hexTileType, ICubeCoordinates cubeCoordinates)
        {
            GameObject gameObject = GameObjectResourceLoader.HexTiles.LoadHexTileGameObjectResource();
            gameObject.name = cubeCoordinates + ": " + hexTileType;
            return gameObject;
        }
    }
}