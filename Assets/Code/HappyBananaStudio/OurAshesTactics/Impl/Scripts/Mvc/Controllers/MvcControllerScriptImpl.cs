/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Mvc.Controller;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Controllers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Frameworks;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Unity;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Mvc.Controllers;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Scripts.Mvc.Controllers
{
    /// <summary>
    /// MvcController Script Impl
    /// </summary>
    public class MvcControllerScriptImpl
    : UnityScript, IMvcControllerScript
    {
        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private IMvcControllerObject mvcControllerObject;

        // Todo
        private IMvcFrameworkScript mvcFrameworkScript;

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IMvcControllerObject GetMvcControllerObject()
        {
            return this.mvcControllerObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameworkScript">
        /// </param>
        public void Initialize(IMvcFrameworkScript mvcFrameworkScript)
        {
            logger.Info("Initializing: ?", this.GetType());
            if (!this.IsInitialized())
            {
                if (mvcFrameworkScript != null)
                {
                    logger.Info("Setting: ?", typeof(IMvcFrameworkScript));
                    this.mvcFrameworkScript = mvcFrameworkScript;

                    this.mvcControllerObject = new MvcControllerObjectImpl(this);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to initialize ?. Invalid Parameters. " +
                        "\n\t>? is null.", this.GetType(), typeof(IMvcFrameworkScript));
                }
            }
            else
            {
                logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public bool IsInitialized()
        {
            return this.mvcFrameworkScript != null &&
                this.mvcControllerObject != null;
        }
    }
}