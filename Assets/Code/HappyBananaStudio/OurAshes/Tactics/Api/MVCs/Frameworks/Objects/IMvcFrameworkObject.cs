namespace HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Frameworks.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Controllers.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Frameworks.Scripts;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Models.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Views.Objects;

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
        IMvcFrameworkScript GetMvcFrameworkScript();

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
        void StartNewGame();
    }
}