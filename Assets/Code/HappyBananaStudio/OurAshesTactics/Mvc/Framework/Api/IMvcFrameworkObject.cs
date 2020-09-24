/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Controller.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.View.Api;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Framework.Api
{
    /// <summary>
    /// MvcFramework Object Api
    /// </summary>
    public interface IMvcFrameworkObject
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool ContinueGame();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcControllerObject GetMvcControllerObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        MvcFrameworkScript GetMvcFrameworkScript();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcModelObject GetMvcModelObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcViewObject GetMvcViewObject();

        /// <summary>
        /// Todo
        /// </summary>
        void Initialize();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsInitialized();

        /// <summary>
        /// Todo
        /// </summary>
        void StartNewGame();

        #endregion Public Methods
    }
}