/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Common.UnityScript;
using HappyBananaStudio.OurAshesTactics.Mvc.Framework.Api;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Mvc.View.Api
{
    /// <summary>
    /// MvcView Script Api
    /// </summary>
    public abstract class MvcViewScript
    : AbstractUnityScript
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract IMvcViewObject GetMvcViewObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameworkScript"></param>
        public abstract void Initialize(MvcFrameworkScript mvcFrameworkScript);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract bool IsInitialized();

        #endregion Public Methods
    }
}