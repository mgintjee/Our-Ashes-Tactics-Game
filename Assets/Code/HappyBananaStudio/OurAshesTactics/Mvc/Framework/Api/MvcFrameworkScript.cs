/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.UnityScript;
using HappyBananaStudio.OurAshesTactics.Mvc.Controller.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Initializer.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.View.Api;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Framework.Api
{
    /// <summary>
    /// MvcFramework Script Api
    /// </summary>
    public abstract class MvcFrameworkScript
    : AbstractUnityScript
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract MvcControllerScript GetMvcControllerScript();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract IMvcFrameworkObject GetMvcFrameworkObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract MvcModelScript GetMvcModelScript();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract MvcViewScript GetMvcViewScript();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcInitializationReport"></param>
        public abstract void Initialize(MvcInitializationReport mvcInitializationReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract bool IsGameActive();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract bool IsInitialized();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract void ResetMvcFramework();

        #endregion Public Methods
    }
}