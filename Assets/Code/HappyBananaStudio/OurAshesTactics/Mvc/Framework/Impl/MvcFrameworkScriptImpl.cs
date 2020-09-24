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
            // Check if the game is active
            if (this.isGameActive)
            {
                // Determine if the game should continue
                this.isGameActive = this.GetMvcFrameworkObject().ContinueGame();
                // Todo: Game is over. Do something
                if (!this.isGameActive)
                {
                    logger.Info("Game Is Over!!!");
                }
            }
            else
            {
                // Check if the game is ready to start
                if (this.IsReadyToStart())
                {
                    logger.Debug("Starting New Game");
                    this.StartNewGame();
                }
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
            // Check that if this was initialized yet
            if (!this.IsInitialized())
            {
                logger.Info("Initializing: ?", this.GetType());
                // Check that the parameters are non-null
                if (mvcInitializationReport != null)
                {
                    // Build the RandomNumberGenerator for this game
                    RandomNumberGeneratorUtil.BuildRandom(mvcInitializationReport.GetGameSeed());
                    // Set the MvcInitializationReport
                    this.mvcInitializationReport = mvcInitializationReport;
                    // Build the MvcFrameworkObject
                    this.mvcFrameworkObject = new MvcFrameworkObjectImpl(this, this.mvcInitializationReport);
                    // Build the MvcControllerScript
                    this.mvcControllerScript = this.BuildMvcController();
                    // Build the MvcModelScript
                    this.mvcModelScript = this.BuildMvcModel();
                    // Build the MvcViewScript
                    this.mvcViewScript = this.BuildMvcView();
                    // Initialize the MvcFrameworkObject
                    this.mvcFrameworkObject.Initialize();
                }
                else
                {
                    throw new ArgumentException("Unable to initialize " + this.GetType() + ". Invalid Parameters." +
                        "\n\t>" + typeof(MvcInitializationReport) + " is null: " + (mvcInitializationReport == null));
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
            this.mvcFrameworkObject = null;
            this.mvcInitializationReport = null;
            this.mvcControllerScript.Destroy();
            this.mvcModelScript.Destroy();
            this.mvcViewScript.Destroy();
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
            mvcControllerScript.Initialize(this);
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
            mvcModelScript.Initialize(this,
                this.mvcInitializationReport.GetMapConstructionReport(),
                this.mvcInitializationReport.GetRosterConstructionReport());
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
            mvcViewScript.Initialize(this);
            return mvcViewScript;
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
            if (!this.isGameActive)
            {
                logger.Info("Starting new game.");
                this.GetMvcFrameworkObject().StartNewGame();
                this.isGameActive = true;
            }
            else
            {
                logger.Warn("Unable to StartGame. Game is active.");
            }
        }

        #endregion Private Methods
    }
}