namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Scripts.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Scripts.Unity.Api;

    /// <summary>
    /// MvcView Script Api
    /// </summary>
    public interface IMvcViewScript
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsAnimating();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonOrderReport"></param>
        void Animate(ITalonOrderReport talonOrderReport);
    }
}