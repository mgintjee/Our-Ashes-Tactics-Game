namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.HexTiles.Utils
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.ResourceLoaders.GameObjects;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Enums;
    using UnityEngine;

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