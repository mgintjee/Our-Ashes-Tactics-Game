using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Objects.Api
{
    /// <summary>
    /// MvcView Object Api
    /// </summary>
    public interface IMvcViewObject
    {
        /*
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject">
        /// </param>
        void AnimateActionOrderReport(ITalonActionOrderReport talonActionOrderReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameActionReport">
        /// </param>
        void DisplayCombatReportPopUp(IGameActionReport gameActionReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IsAnimating();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IsInitialized();

        /// <summary>
        /// Todo
        /// </summary>
        void UpdateCanvas();
    */

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject"></param>
        void ShowPathObject(IPathObject pathObject);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonOrderReport"></param>
        void Animate(ITalonOrderReport talonOrderReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsAnimating();

        /// <summary>
        /// Todo
        /// </summary>
        void DestroyCanvas();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonOrderReport"></param>
        void DisplayTalonOrderReport(ITalonOrderReport talonOrderReport);
    }
}