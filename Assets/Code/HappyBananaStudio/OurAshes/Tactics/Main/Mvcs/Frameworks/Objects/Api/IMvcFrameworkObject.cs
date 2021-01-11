namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Objects.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Objects.Api;

    /// <summary>
    /// MvcFramework Object Api
    /// </summary>
    public interface IMvcFrameworkObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool ContinueGame();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IMvcControllerObject GetMvcControllerObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IMvcModelObject GetMvcModelObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IMvcViewObject GetMvcViewObject();

        /// <summary>
        /// Todo
        /// </summary>
        void Initialize();

        /// <summary>
        /// Todo
        /// </summary>
        void Start();
    }
}