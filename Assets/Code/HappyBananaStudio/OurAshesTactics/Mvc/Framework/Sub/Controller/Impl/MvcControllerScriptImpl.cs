/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Mvc.Controller.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Framework.Api;
using System;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Controller.Impl
{
    /// <summary>
    /// MvcController Script Impl
    /// </summary>
    public class MvcControllerScriptImpl
    : MvcControllerScript
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private IMvcControllerObject mvcControllerObject;

        // Todo
        private MvcFrameworkScript mvcFrameworkScript;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override IMvcControllerObject GetMvcControllerObject()
        {
            return this.mvcControllerObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameworkScript"></param>
        public override void Initialize(MvcFrameworkScript mvcFrameworkScript)
        {
            if (mvcFrameworkScript != null)
            {
                logger.Info("Initializing: ?", this.GetType());
                if (!this.IsInitialized())
                {
                    logger.Info("Setting: ?", typeof(MvcFrameworkScript));
                    this.mvcFrameworkScript = mvcFrameworkScript;

                    this.mvcControllerObject = new MvcControllerObjectImpl(this);
                }
                else
                {
                    logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
                }
            }
            else
            {
                throw new ArgumentException("Unable to initialize ?" + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(MvcFrameworkScript) + " is null: " + (mvcFrameworkScript == null));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override bool IsInitialized()
        {
            return this.mvcFrameworkScript != null &&
                this.mvcControllerObject != null;
        }

        #endregion Public Methods
    }
}