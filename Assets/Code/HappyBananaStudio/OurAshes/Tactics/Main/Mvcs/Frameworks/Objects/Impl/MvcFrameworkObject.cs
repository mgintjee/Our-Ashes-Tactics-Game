using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Generators.GameBoards.Coordinates.Cube;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.Objects.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Objects.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Reports.Construction.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Objects.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Reports.Api;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Objects.Impl
{
    /// <summary>
    /// MvcFramework Object Api
    /// </summary>
    public class MvcFrameworkObject
        : IMvcFrameworkObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IMvcModelObject mvcModelObject;

        // Todo
        private readonly IMvcControllerObject mvcControllerObject;

        // Todo
        private readonly IMvcViewObject mvcViewObject;

        // Todo
        private readonly IMvcConstructionReport mvcConstructionReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcConstructionReport"></param>
        private MvcFrameworkObject(IMvcConstructionReport mvcConstructionReport)
        {
            this.mvcConstructionReport = mvcConstructionReport;
            logger.Info("Constructing new ? with ?", this.GetType(), this.mvcConstructionReport);
            ISet<ICubeCoordinates> cubeCoordinateSet = CubeCoordinatesSetGenerator.GenerateCubeCoordinates(
                this.mvcConstructionReport.GetGameBoardShape(), this.mvcConstructionReport.GetGameBoardLimit());
            this.mvcModelObject = new MvcModelObject.Builder()
                .SetSimulationType(this.mvcConstructionReport.GetSimulationType())
                .SetCubeCoordinatesSet(cubeCoordinateSet)
                .SetPhalanxReports(this.mvcConstructionReport.GetPhalanxReports())
                .SetTalonConstructionReports(this.mvcConstructionReport.GetTalonConstructionReports())
                .SetMatchType(this.mvcConstructionReport.GetMatchType())
                .SetMirroredBoad(this.mvcConstructionReport.GetMirroredBoard())
                .SetTalonSpawnCubeCoordinatesDictionary(TalonSpawnCubeCoordinatesGenerator
                    .GenerateSpawnCubeCoordinates(this.mvcConstructionReport.GetPhalanxReports(), cubeCoordinateSet))
                .Build();
            this.mvcViewObject = new MvcViewObject.Builder()
                .SetSimulationType(this.mvcConstructionReport.GetSimulationType())
                .SetMatchType(this.mvcConstructionReport.GetMatchType())
                .SetViewConfigurationReport(this.mvcConstructionReport.GetViewConfigurationReport())
                .Build();
            this.mvcControllerObject = new MvcControllerObject.Builder()
                .SetPhalanxReports(this.mvcConstructionReport.GetPhalanxReports())
                .SetSimulationType(this.mvcConstructionReport.GetSimulationType())
                .Build();
        }

        /// <inheritdoc/>
        void IMvcFrameworkObject.ContinueGame()
        {
            if (!this.mvcViewObject.IsAnimating())
            {
                TalonCallSign actingTalonCallSign = this.mvcModelObject.GetActingTalonCallSign();
                logger.Debug("Acting ?", TalonRosterManager.GetTalonReport(actingTalonCallSign));
                ITalonOrderReport talonOrderReport = this.mvcControllerObject.DetermineTalonOrderReport(actingTalonCallSign);
                logger.Debug("?", talonOrderReport);
                if (talonOrderReport != null)
                {
                    this.mvcModelObject.InputTalonOrderReport(talonOrderReport);
                    this.mvcViewObject.DisplayTalonOrderReport(talonOrderReport);
                    this.mvcViewObject.Animate(talonOrderReport);
                    IMvcModelReport mvcModelReport = this.mvcModelObject.GetMvcModelReport();
                    logger.Debug("?", mvcModelReport);
                }
                else
                {
                    logger.Debug("Unable to ContinueGame. Null ?", typeof(ITalonOrderReport));
                }
            }
            {
                logger.Debug("Animating.");
            }
        }

        /// <inheritdoc/>
        bool IMvcFrameworkObject.IsAnimating()
        {
            return this.mvcViewObject.IsAnimating();
        }

        /// <inheritdoc/>
        bool IMvcFrameworkObject.IsGameComplete()
        {
            // Todo: Add a check for the controller to ensure that the connected people are connected.
            // Maybe just have an AI take over?
            return this.mvcModelObject.GetMvcModelReport().GetWinConditionReport().GetTalonCallSignSet().Count != 0;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IMvcConstructionReport mvcConstructionReport = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMvcFrameworkObject Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new MvcFrameworkObject(this.mvcConstructionReport);
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mvcConstructionReport"></param>
            /// <returns></returns>
            public Builder SetMvcConstructionReport(IMvcConstructionReport mvcConstructionReport)
            {
                this.mvcConstructionReport = mvcConstructionReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                if (this.mvcConstructionReport == null)
                {
                    argumentExceptionSet.Add(typeof(IMvcConstructionReport).Name + " can not be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}