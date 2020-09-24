/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.UnityScript;
using HappyBananaStudio.OurAshesTactics.Mvc.Framework.Api;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Controller.Api
{
    /// <summary>
    /// MvcController Script Api
    /// </summary>
    public abstract class MvcControllerScript
    : AbstractUnityScript
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract IMvcControllerObject GetMvcControllerObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameFrameworkScript"></param>
        public abstract void Initialize(MvcFrameworkScript gameFrameworkScript);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract bool IsInitialized();

        #endregion Public Methods
    }
}