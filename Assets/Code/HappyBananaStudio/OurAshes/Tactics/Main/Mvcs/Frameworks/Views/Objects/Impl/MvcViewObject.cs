namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Managers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Managers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Convertors.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Views.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Views.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Objects.Impl;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// MvcView Object Impl
    /// </summary>
    public class MvcViewObject
        : IMvcViewObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly SimulationType simulationType;

        // Todo
        private readonly MatchType matchType;

        // Todo
        private readonly IUIObject uiObject;

        // Todo
        private readonly IGameBoardView gameBoardView;

        // Todo
        private readonly ISet<IPanel> canvasSet;

        // Todo
        private readonly ICanvasGridConvertor canvasGridConvertor;

        // Todo
        private readonly Transform transform;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="simulationType"></param>
        /// <param name="matchType"></param>
        private MvcViewObject(SimulationType simulationType, MatchType matchType,
            IViewConfigurationReport viewConfigurationReport)
        {
            this.simulationType = simulationType;
            this.matchType = matchType;
            if (this.simulationType == SimulationType.WhiteBox ||
                this.simulationType == SimulationType.Interactive)
            {
                logger.Debug("Building Canvas Objects");
                this.transform = new GameObject(this.GetType().Name).transform;
                this.uiObject = new UIObject.Builder()
                    .SetParentTransform(this.transform)
                    .SetViewConfigurationReport(viewConfigurationReport)
                    // Todo: Probably add the matchType here too
                    .Build();
                this.gameBoardView = new GameBoardView.Builder()
                    .SetParentTransform(this.transform)
                    .SetGameBoardReport(GameBoardManager.GetGameBoardReport())
                    .SetTalonRosterReport(TalonRosterManager.GetTalonRosterReport())
                    .Build();
            }
        }

        /// <inheritdoc/>
        void IMvcViewObject.Animate(ITalonOrderReport talonOrderReport)
        {
            this.ShowPathObject(talonOrderReport.GetPathObject());
            if (this.simulationType != SimulationType.BlackBox)
            {
                this.gameBoardView.BeginAnimating(talonOrderReport);
            }
        }

        /// <inheritdoc/>
        void IMvcViewObject.DestroyCanvas()
        {
            GameObject.Destroy(this.transform);
        }

        /// <inheritdoc/>
        void IMvcViewObject.DisplayTalonOrderReport(ITalonOrderReport talonOrderReport)
        {
            if (this.uiObject != null)
            {
                this.uiObject.DisplayTalonOrderReport(talonOrderReport);
            }
        }

        /// <inheritdoc/>
        bool IMvcViewObject.IsAnimating()
        {
            return this.gameBoardView != null &&
                this.gameBoardView.IsAnimating();
        }

        /// <inheritdoc/>
        void IMvcViewObject.ShowPathObject(IPathObject pathObject)
        {
            this.ShowPathObject(pathObject);
        }

        /// <inheritdoc/>
        private void ShowPathObject(IPathObject pathObject)
        {
            if (this.simulationType != SimulationType.BlackBox)
            {
                this.gameBoardView.ShowPathObject(pathObject);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private SimulationType simulationType = SimulationType.None;

            // Todo
            private MatchType matchType = MatchType.None;

            // Todo
            private IViewConfigurationReport viewConfigurationReport = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMvcViewObject Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new MvcViewObject(this.simulationType, this.matchType, this.viewConfigurationReport);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="simulationType"></param>
            /// <returns></returns>
            public Builder SetSimulationType(SimulationType simulationType)
            {
                this.simulationType = simulationType;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="matchType"></param>
            /// <returns></returns>
            public Builder SetMatchType(MatchType matchType)
            {
                this.matchType = matchType;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="viewConfigurationReport"></param>
            /// <returns></returns>
            public Builder SetViewConfigurationReport(IViewConfigurationReport viewConfigurationReport)
            {
                this.viewConfigurationReport = viewConfigurationReport;
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
                if (this.simulationType == SimulationType.None)
                {
                    argumentExceptionSet.Add(typeof(SimulationType).Name + " can not be none.");
                }
                if (this.matchType == MatchType.None)
                {
                    argumentExceptionSet.Add(typeof(MatchType).Name + " can not be none.");
                }
                if (this.viewConfigurationReport == null && this.simulationType != SimulationType.BlackBox)
                {
                    argumentExceptionSet.Add(typeof(IViewConfigurationReport).Name + " can not be null with "
                        + typeof(SimulationType).Name + "=" + this.simulationType);
                }
                return argumentExceptionSet;
            }
        }

        /*

        // Todo
        private readonly GameObject mvcCanvasGameObject;

        // Todo
        private readonly IMvcFrameworkObject mvcFrameworkObject;

        // Todo
        private readonly IMvcInitializationReport mvcInitializationReport;

        // Todo
        private readonly IMvcViewScript mvcViewScript;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameworkObject">
        /// </param>
        /// <param name="mvcInitializationReport">
        /// </param>
        public MvcViewObjectImpl(IMvcFrameworkObject mvcFrameworkObject, IMvcInitializationReport mvcInitializationReport)
        {
            if (mvcFrameworkObject != null &&
                mvcInitializationReport != null)
            {
                logger.Info("Constructing: ?", this.GetType());
                this.mvcFrameworkObject = mvcFrameworkObject;
                this.mvcInitializationReport = mvcInitializationReport;
                // Update this to be a AddComponent call
                this.mvcViewScript = GameObjectResourceLoader.Canvas.LoadMvcCanvasGameObject().GetComponent<IMvcViewScript>();
                this.mvcViewScript.LoadWidgets();
                this.mvcViewScript.UpdateWidgets();
                GameObject.FindObjectOfType<AnimatorMoveUtilScript>().SetMvcViewObject(this);
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. " +
                    "\n\t> ? is null: ?" +
                    "\n\t> ? is null: ?", this.GetType(),
                    typeof(IMvcFrameworkObject), (mvcFrameworkObject == null),
                    typeof(IMvcInitializationReport), (mvcInitializationReport == null));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrderReport">
        /// </param>
        void IMvcViewObject.AnimateActionOrderReport(ITalonActionOrderReport talonActionOrderReport)
        {
            // Use the LineRenderer to draw the path
            LineRendererUtil.DrawPath(talonActionOrderReport.GetPathObject());
            if (talonActionOrderReport.GetPathObject() is PathObjectMoveImpl)
            {
                GameObject.FindObjectOfType<AnimatorMoveUtilScript>().AnimateTalonActionOrderReport(talonActionOrderReport);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameActionReport">
        /// </param>
        void IMvcViewObject.DisplayCombatReportPopUp(IGameActionReport gameActionReport)
        {
            ITalonActionResultFireReport actualTalonActionOrderFireReport = (ITalonActionResultFireReport)gameActionReport.GetTalonActionResultReport();
            ITalonActionResultFireReport expectedTalonActionOrderFireReport = TalonCombatManager.GetExpectedTalonActionResultFireReport(
                (ITalonActionOrderFireReport)actualTalonActionOrderFireReport.GetTalonActionOrder());
            logger.Debug("Actual=?" +
                "\nExpected=?", actualTalonActionOrderFireReport, expectedTalonActionOrderFireReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IMvcViewObject.IsAnimating()
        {
            return GameObject.FindObjectOfType<AnimatorMoveUtilScript>()
                   .GetComponent<AnimatorMoveUtilScript>().IsAnimating();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IMvcViewObject.IsInitialized()
        {
            return this.mvcFrameworkObject != null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        void IMvcViewObject.UpdateCanvas()
        {
            this.mvcViewScript.UpdateWidgets();
        }
        */
    }
}