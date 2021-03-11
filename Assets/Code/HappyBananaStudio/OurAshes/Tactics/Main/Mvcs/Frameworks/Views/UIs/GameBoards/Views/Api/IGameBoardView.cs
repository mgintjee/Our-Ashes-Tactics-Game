namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Views.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.HexTiles.Views.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Talons.Views.Api;

    /// <summary>
    /// Todo
    /// </summary>
    public interface IGameBoardView
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject"></param>
        void ShowPathObject(IPathObject pathObject);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonOrderReport"></param>
        void BeginAnimating(ITalonOrderReport talonOrderReport);

        /// <summary>
        /// Todo
        /// </summary>
        bool IsAnimating();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        IHexTileView GetHexTileView(ICubeCoordinates cubeCoordinates);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <returns></returns>
        ITalonView GetTalonView(TalonCallSign talonCallSign);
    }
}