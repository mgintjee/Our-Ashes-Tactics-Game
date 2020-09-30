/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Mvc.Controller;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Mvc.Models;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Mvc.Views;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Frameworks;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Mvc.Frameworks
{
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
        bool IsInitialized();

        /// <summary>
        /// Todo
        /// </summary>
        void StartNewGame();
    }
}