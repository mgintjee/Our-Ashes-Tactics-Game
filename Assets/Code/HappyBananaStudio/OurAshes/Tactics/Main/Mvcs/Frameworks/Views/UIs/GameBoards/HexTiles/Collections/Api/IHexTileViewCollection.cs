namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.HexTiles.Collections.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Scripts.Unity.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.HexTiles.Views.Api;

    /// <summary>
    /// Todo
    /// </summary>
    public interface IHexTileViewCollection
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        IHexTileView GetHexTileView(ICubeCoordinates cubeCoordinates);
    }
}