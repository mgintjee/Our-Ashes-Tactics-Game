namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Talons.Views.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Scripts.Unity.Api;

    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonView
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICubeCoordinates GetCubeCoordinates();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        TalonCallSign GetTalonCallSign();

        // Todo: Add a method called MoveAlongPath or something
    }
}