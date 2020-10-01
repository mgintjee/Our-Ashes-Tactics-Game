/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Mvc.Frameworks;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Mvc.Initializers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Controllers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Frameworks;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Models;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Mvc.Views;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Mvc.Controllers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Mvc.Models;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Mvc.Views;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.RandomNumberGenerators;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Unity;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Mvc.Frameworks;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Scripts.Mvc.Controllers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Scripts.Mvc.Model;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Scripts.Mvc.View;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Scripts.Mvc.Frameworks
{
    /// <summary>
    /// MvcFramework Script Api
    /// </summary>
    public class MvcFrameworkScriptImpl
    : UnityScript, IMvcFrameworkScript
    {
        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private bool isGameActive = false;

        // Todo
        private IMvcControllerScript mvcControllerScript;

        // Todo
        private IMvcFrameworkObject mvcFrameworkObject;

        // Todo
        private IMvcInitializationReport mvcInitializationReport;

        // Todo
        private IMvcModelScript mvcModelScript;

        // Todo
        private IMvcViewScript mvcViewScript;

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
                    Time.timeScale = 0;
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
                else
                {
                    logger.Debug("Unable to Start New Game. Not ready to start.");
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IMvcControllerScript GetMvcControllerScript()
        {
            return this.mvcControllerScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IMvcFrameworkObject GetMvcFrameworkObject()
        {
            return this.mvcFrameworkObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IMvcModelScript GetMvcModelScript()
        {
            return this.mvcModelScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IMvcViewScript GetMvcViewScript()
        {
            return this.mvcViewScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcInitializationReport">
        /// </param>
        public void Initialize(IMvcInitializationReport mvcInitializationReport)
        {
            // Check that if this was initialized yet
            if (!this.IsInitialized())
            {
                logger.Info("Initializing: ?", this.GetType());
                // Check that the parameters are non-null
                if (mvcInitializationReport != null)
                {
                    // Build the RandomNumberGenerator for this game
                    RandomNumberGeneratorUtil.BuildRandom(mvcInitializationReport.GetGameRNGSeed());
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
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters." +
                        "\n\t> ? is null", this.GetType(), typeof(IMvcInitializationReport));
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
        public bool IsGameActive()
        {
            return this.isGameActive;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public bool IsInitialized()
        {
            return this.mvcFrameworkObject != null &&
                this.mvcControllerScript != null &&
                this.mvcModelScript != null &&
                this.mvcViewScript != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void ResetMvcFramework()
        {
            this.mvcFrameworkObject = null;
            this.mvcInitializationReport = null;
            this.mvcControllerScript.Destroy();
            this.mvcModelScript.Destroy();
            this.mvcViewScript.Destroy();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        private IMvcControllerScript BuildMvcController()
        {
            logger.Info("Building: ?", typeof(IMvcControllerScript));
            GameObject mvcControllerGameObject = new GameObject(MvcControllerConstants.Script.GetMvcControllerGameObjectName());
            IMvcControllerScript mvcControllerScript = mvcControllerGameObject.AddComponent<MvcControllerScriptImpl>();
            mvcControllerGameObject.transform.SetParent(this.transform);
            mvcControllerScript.Initialize(this);
            return mvcControllerScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        private IMvcModelScript BuildMvcModel()
        {
            logger.Info("Building: ?", typeof(IMvcModelScript));
            GameObject mvcModelGameObject = new GameObject(MvcModelConstants.Script.GetMvcModelGameObjectName());
            IMvcModelScript mvcModelScript = mvcModelGameObject.AddComponent<MvcModelScriptImpl>();
            mvcModelGameObject.transform.SetParent(this.transform);
            mvcModelScript.Initialize(this,
                this.mvcInitializationReport.GetGameMapConstructionReport(),
                this.mvcInitializationReport.GetRosterConstructionReport());
            return mvcModelScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        private IMvcViewScript BuildMvcView()
        {
            logger.Info("Building: ?", typeof(IMvcViewScript));
            GameObject mvcViewGameObject = new GameObject(MvcViewConstants.Script.GetMvcViewGameObjectName());
            IMvcViewScript mvcViewScript = mvcViewGameObject.AddComponent<MvcViewScriptImpl>();
            mvcViewGameObject.transform.SetParent(this.transform);
            mvcViewScript.Initialize(this);
            return mvcViewScript;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
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
    }
}