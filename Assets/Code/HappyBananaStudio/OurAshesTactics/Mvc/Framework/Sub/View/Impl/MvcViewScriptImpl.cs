/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.ResourceLoader;
using HappyBananaStudio.OurAshesTactics.Mvc.Framework.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.View.Api;
using System;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.View.Impl
{
    /// <summary>
    /// MvcView Script Impl
    /// </summary>
    public class MvcViewScriptImpl
    : MvcViewScript
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private GameObject mvcCanvasGameObject;

        // Todo
        private MvcFrameworkScript mvcFrameworkScript;

        // Todo
        private IMvcViewObject mvcViewObject;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override IMvcViewObject GetMvcViewObject()
        {
            return this.mvcViewObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameworkScript"></param>
        public override void Initialize(MvcFrameworkScript mvcFrameworkScript)
        {
            if (!this.IsInitialized())
            {
                if (mvcFrameworkScript != null)
                {
                    logger.Info("Initializing Script: ?", this.GetType());
                    logger.Info("Setting Script: ?", typeof(MvcFrameworkScript));
                    this.mvcFrameworkScript = mvcFrameworkScript;

                    this.mvcCanvasGameObject = this.BuildMvcCanvas();

                    this.mvcViewObject = new MvcViewObjectImpl(this, this.mvcCanvasGameObject);
                }
                else
                {
                    throw new ArgumentException("Unable to initialize " + this.GetType() + ". Invalid Parameters." +
                        "\n\t>mvcFrameworkScript=" + mvcFrameworkScript);
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
        /// <returns></returns>
        public override bool IsInitialized()
        {
            return this.mvcFrameworkScript != null &&
                this.mvcViewObject != null &&
                this.mvcCanvasGameObject != null;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private GameObject BuildMvcCanvas()
        {
            GameObject mvcCanvasGameObject = GameObjectResourceLoader.Canvas.LoadMvcCanvasGameObject();
            mvcCanvasGameObject.transform.SetParent(this.transform);
            return mvcCanvasGameObject;
        }

        #endregion Private Methods
    }
}