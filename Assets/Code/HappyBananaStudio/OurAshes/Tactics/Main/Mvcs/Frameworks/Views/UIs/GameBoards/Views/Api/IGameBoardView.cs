using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Scripts.Unity.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Views.Views.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Pathing.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Views.Views.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Views.Api
{
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