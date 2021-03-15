using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Scripts.Unity.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Reports.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Animators.Api
{
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