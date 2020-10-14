/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Frameworks.Objects;
using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Frameworks.Scripts;
using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Initializers.Reports;
using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
using HappyBananaStudio.OurAshesTactics.Common.Scripts.Unity;
using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using HappyBananaStudio.OurAshesTactics.Common.Utils.RandomNumberGenerators;
using HappyBananaStudio.OurAshesTactics.Impl.Objects.Mvc.Frameworks;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Impl.Scripts.Mvc.Frameworks
{
    /// <summary>
    /// MvcFramework Script Api
    /// </summary>
    public class MvcFrameworkScriptImpl
    : UnityScriptImpl, IMvcFrameworkScript
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private bool isGameActive = false;

        // Todo
        private IMvcFrameworkObject mvcFrameworkObject;

        // Todo
        private IMvcInitializationReport mvcInitializationReport;

        /// <summary>
        /// Todo
        /// </summary>
        public void FixedUpdate()
        {
            // Check if the game is active
            if (this.isGameActive)
            {
                // Check if the Model is currently animating an action
                // Todo: Clean this up. Have an animator util?
                if (!this.mvcFrameworkObject.IsAnimating())
                {
                    // Determine if the game should continue
                    this.isGameActive = this.mvcFrameworkObject.ContinueGame();
                    // Todo: Game is over. Do something
                    if (!this.isGameActive)
                    {
                        logger.Info("Game Is Over!!!");
                        Time.timeScale = 0;
                    }
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
        IMvcFrameworkObject IMvcFrameworkScript.GetMvcFrameworkObject()
        {
            return this.mvcFrameworkObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcInitializationReport">
        /// </param>
        void IMvcFrameworkScript.Initialize(IMvcInitializationReport mvcInitializationReport)
        {
            // Check that if this was initialized yet
            if (this.mvcFrameworkObject == null)
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
        bool IMvcFrameworkScript.IsGameActive()
        {
            return this.isGameActive;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IMvcFrameworkScript.IsInitialized()
        {
            return this.mvcFrameworkObject != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        void IMvcFrameworkScript.ResetMvcFramework()
        {
            this.mvcFrameworkObject = null;
            this.mvcInitializationReport = null;
            this.Destroy();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        private bool IsReadyToStart()
        {
            return this.mvcFrameworkObject != null &&
                this.mvcInitializationReport != null &&
                this.mvcFrameworkObject.IsInitialized();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void StartNewGame()
        {
            if (!this.isGameActive)
            {
                logger.Info("Starting new game.");
                this.mvcFrameworkObject.StartNewGame();
                this.isGameActive = true;
            }
            else
            {
                logger.Warn("Unable to StartGame. Game is active.");
            }
        }
    }
}
