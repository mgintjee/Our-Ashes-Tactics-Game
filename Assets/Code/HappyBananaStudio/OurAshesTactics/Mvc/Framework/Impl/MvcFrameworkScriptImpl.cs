/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Controller.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Controller.Constants;
using HappyBananaStudio.OurAshesTactics.Mvc.Controller.Impl;
using HappyBananaStudio.OurAshesTactics.Mvc.Framework.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Initializer.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Constants;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Impl;
using HappyBananaStudio.OurAshesTactics.Mvc.Util.RandomNumberGenerator;
using HappyBananaStudio.OurAshesTactics.Mvc.Util.Renderer;
using HappyBananaStudio.OurAshesTactics.Mvc.View.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.View.Constants;
using HappyBananaStudio.OurAshesTactics.Mvc.View.Impl;
using System;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Framework.Impl
{
    /// <summary>
    /// MvcFramework Script Api
    /// </summary>
    public class MvcFrameworkScriptImpl
    : MvcFrameworkScript
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private bool isGameActive = false;

        // Todo
        private MvcControllerScript mvcControllerScript;

        // Todo
        private IMvcFrameworkObject mvcFrameworkObject;

        // Todo
        private MvcInitializationReport mvcInitializationReport;

        // Todo
        private MvcModelScript mvcModelScript;

        // Todo
        private MvcViewScript mvcViewScript;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        public void FixedUpdate()
        {
            if (this.IsReadyToStart() &&
                !this.isGameActive)
            {
                logger.Debug("Starting New Game");
                this.StartNewGame();
            }

            if (this.isGameActive)
            {
                logger.Debug("Continuing Game");
                this.ContinueGame();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override MvcControllerScript GetMvcControllerScript()
        {
            return this.mvcControllerScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override IMvcFrameworkObject GetMvcFrameworkObject()
        {
            return this.mvcFrameworkObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override MvcModelScript GetMvcModelScript()
        {
            return this.mvcModelScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override MvcViewScript GetMvcViewScript()
        {
            return this.mvcViewScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcInitializationReport"></param>
        public override void Initialize(MvcInitializationReport mvcInitializationReport)
        {
            if (mvcInitializationReport != null)
            {
                logger.Info("Initializing: ?", this.GetType());
                if (!this.IsInitialized())
                {
                    RandomNumberGeneratorUtil.SetSeed(mvcInitializationReport.GetGameSeed());
                    this.mvcInitializationReport = mvcInitializationReport;

                    this.mvcFrameworkObject = new MvcFrameworkObjectImpl(this, this.mvcInitializationReport);

                    this.mvcControllerScript = this.BuildMvcController();
                    this.mvcModelScript = this.BuildMvcModel();
                    this.mvcViewScript = this.BuildMvcView();

                    this.mvcControllerScript.Initialize(this);
                    this.mvcModelScript.Initialize(this,
                        this.mvcInitializationReport.GetMapConstructionReport(),
                        this.mvcInitializationReport.GetRosterConstructionReport());
                    this.mvcViewScript.Initialize(this);
                    this.mvcFrameworkObject.Initialize();
                }
                else
                {
                    logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
                }
            }
            else
            {
                throw new ArgumentException("Unable to initialize " + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(MvcInitializationReport) + " is null: " + (mvcInitializationReport == null));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override bool IsGameActive()
        {
            return this.isGameActive;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override bool IsInitialized()
        {
            return this.mvcFrameworkObject != null &&
                this.mvcControllerScript != null &&
                this.mvcModelScript != null &&
                this.mvcViewScript != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public override void ResetMvcFramework()
        {
            this.mvcInitializationReport = null;
            GameObject.Destroy(this.mvcControllerScript.GetGameObject());
            GameObject.Destroy(this.mvcModelScript.GetGameObject());
            GameObject.Destroy(this.mvcViewScript.GetGameObject());
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private MvcControllerScript BuildMvcController()
        {
            logger.Info("Building: ?", typeof(MvcControllerScript));
            GameObject mvcControllerGameObject = new GameObject(MvcControllerConstants.Script.GetMvcControllerGameObjectName());
            MvcControllerScript mvcControllerScript = mvcControllerGameObject.AddComponent<MvcControllerScriptImpl>();
            mvcControllerGameObject.transform.SetParent(this.transform);
            return mvcControllerScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private MvcModelScript BuildMvcModel()
        {
            logger.Info("Building: ?", typeof(MvcModelScript));
            GameObject mvcModelGameObject = new GameObject(MvcModelConstants.Script.GetMvcModelGameObjectName());
            MvcModelScript mvcModelScript = mvcModelGameObject.AddComponent<MvcModelScriptImpl>();
            mvcModelGameObject.transform.SetParent(this.transform);
            return mvcModelScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private MvcViewScript BuildMvcView()
        {
            logger.Info("Building: ?", typeof(MvcViewScript));
            GameObject mvcViewGameObject = new GameObject(MvcViewConstants.Script.GetMvcViewGameObjectName());
            MvcViewScript mvcViewScript = mvcViewGameObject.AddComponent<MvcViewScriptImpl>();
            mvcViewGameObject.transform.SetParent(this.transform);
            return mvcViewScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void ContinueGame()
        {
            this.isGameActive = this.GetMvcFrameworkObject().ContinueGame();
            logger.Info("Continue Game=?", this.isGameActive);
            // Todo: Game is over. Do something
            if (!this.isGameActive)
            {
                LineRendererUtil.ErasePath();
                this.ResetMvcFramework();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private bool IsReadyToStart()
        {
            return this.IsInitialized() &&
                this.mvcInitializationReport != null &&
                this.mvcFrameworkObject.IsInitialized() &&
                this.mvcControllerScript.IsInitialized() &&
                this.mvcModelScript.IsInitialized() &&
                this.mvcViewScript.IsInitialized();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void StartNewGame()
        {
            logger.Info("Starting new game.");
            this.GetMvcFrameworkObject().StartNewGame();
            this.isGameActive = true;
        }

        #endregion Private Methods
    }
}