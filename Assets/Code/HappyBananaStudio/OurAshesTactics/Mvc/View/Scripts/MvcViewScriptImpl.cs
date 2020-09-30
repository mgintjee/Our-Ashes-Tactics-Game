/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Mvc.Views;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Frameworks;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Views;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.ResourceLoaders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Unity;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Mvc.View.Objects;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Mvc.View.Scripts
{
    /// <summary>
    /// MvcView Script Impl
    /// </summary>
    public class MvcViewScriptImpl
    : UnityScript, IMvcViewScript
    {
        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private GameObject mvcCanvasGameObject;

        // Todo
        private IMvcFrameworkScript mvcFrameworkScript;

        // Todo
        private IMvcViewObject mvcViewObject;

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IMvcViewObject GetMvcViewObject()
        {
            return this.mvcViewObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameworkScript">
        /// </param>
        public void Initialize(IMvcFrameworkScript mvcFrameworkScript)
        {
            if (!this.IsInitialized())
            {
                if (mvcFrameworkScript != null)
                {
                    logger.Info("Initializing Script: ?", this.GetType());
                    logger.Info("Setting Script: ?", typeof(IMvcFrameworkScript));
                    this.mvcFrameworkScript = mvcFrameworkScript;

                    //this.mvcCanvasGameObject = this.BuildMvcCanvas();
                    this.mvcCanvasGameObject = new GameObject();
                    this.mvcViewObject = new MvcViewObjectImpl(this, this.mvcCanvasGameObject);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is null.",
                        this.GetType(), typeof(IMvcFrameworkScript));
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
                this.mvcViewObject != null &&
                this.mvcCanvasGameObject != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        private GameObject BuildMvcCanvas()
        {
            GameObject mvcCanvasGameObject = GameObjectResourceLoader.Canvas.LoadMvcCanvasGameObject();
            mvcCanvasGameObject.transform.SetParent(this.transform);
            return mvcCanvasGameObject;
        }
    }
}