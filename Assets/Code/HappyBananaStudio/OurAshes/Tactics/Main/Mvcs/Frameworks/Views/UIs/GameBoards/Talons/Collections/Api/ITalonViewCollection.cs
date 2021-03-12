namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Talons.Collections.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Scripts.Unity.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Talons.Views.Api;

    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonViewCollection
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <returns></returns>
        ITalonView GetTalonView(TalonCallSign talonCallSign);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <returns></returns>
        void DestroyTalonView(TalonCallSign talonCallSign);
    }
}