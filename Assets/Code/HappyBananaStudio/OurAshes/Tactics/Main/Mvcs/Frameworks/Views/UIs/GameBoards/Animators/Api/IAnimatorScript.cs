namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Animators.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Scripts.Unity.Api;

    /// <summary>
    /// Animator Object Api
    /// </summary>
    public interface IAnimatorScript
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonOrderReport"></param>
        void BeginAnimating(ITalonOrderReport talonOrderReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsAnimating();
    }
}