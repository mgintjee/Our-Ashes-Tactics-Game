namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Scripts.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Scripts.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Scripts.Unity.Abs;
    using System.Diagnostics;

    /// <summary>
    /// MvcView Script Api
    /// </summary>
    public class MvcViewScript
        : AbstractUnityScript, IMvcViewScript
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private ITalonOrderReport talonOrderReport;

        /// <summary>
        /// Todo
        /// </summary>
        public void FixedUpdate()
        {
            if (this.talonOrderReport != null)
            {
                this.Animate();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void Animate()
        {
        }

        /// <inheritdoc/>
        void IMvcViewScript.Animate(ITalonOrderReport talonOrderReport)
        {
            if (this.talonOrderReport == null)
            {
                this.talonOrderReport = talonOrderReport;
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. ? cannot be set due to ? is currently animating.",
                    new StackFrame().GetMethod().Name, typeof(ITalonOrderReport), this.GetType());
            }
        }

        /// <inheritdoc/>
        bool IMvcViewScript.IsAnimating()
        {
            return this.talonOrderReport != null;
        }

        /*
        // Todo
        private readonly ISet<ICanvasUI> canvasUISet = new HashSet<ICanvasUI>();

        // private ITalonTurnWidget talonTurnWidget;
        // private ITalonActionWidget talonActionWidget;
        // private ITalonInfoWidget talonInfoWidget;

        // Todo
        private bool animatingCanvas = false;

        // Todo: Have a canvas animator and talon animator here or something

        /// <summary>
        /// Todo
        /// </summary>
        void IMvcViewScript.LoadWidgets()
        {
            logger.Debug("Loading ActionMenu Widget");
            ICanvasUI actionMenuWidget = UIResourceLoader.CanvasUIs.LoadActionMenuWidget(this.GetTransform());
            logger.Debug("Loading ScoreBoard Widget");
            ICanvasUI scoreBoardWidget = UIResourceLoader.CanvasUIs.LoadScoreBoardWidget(this.GetTransform());
            logger.Debug("Loading TurnScroller Widget");
            ICanvasUI turnScrollerWidget = UIResourceLoader.CanvasUIs.LoadTurnScrollerWidget(this.GetTransform());
            logger.Debug("Loading SettingsMenu Widget");
            ICanvasUI settingsMenuWidget = UIResourceLoader.CanvasUIs.LoadSettingsMenuWidget(this.GetTransform());
            logger.Debug("Loading Information Widget");
            ICanvasUI informationWidget = UIResourceLoader.CanvasUIs.LoadInformationWidget(this.GetTransform());

            // Todo: Store these coordinates somewhere else?
            logger.Debug("Initializing ActionMenu Widget");
            actionMenuWidget.Initialize(
                new CanvasGridCoordinatesImpl.Builder()
                    .SetX(0)
                    .SetY(0)
                    .Build(),
                new CanvasGridCoordinatesImpl.Builder()
                    .SetX(2)
                    .SetY(5)
                    .Build());
            logger.Debug("Initializing ScoreBoard Widget");
            scoreBoardWidget.Initialize(
                new CanvasGridCoordinatesImpl.Builder()
                    .SetX(0)
                    .SetY(7)
                    .Build(),
                new CanvasGridCoordinatesImpl.Builder()
                    .SetX(2)
                    .SetY(2)
                    .Build());
            logger.Debug("Initializing TurnScroller Widget");
            turnScrollerWidget.Initialize(
                new CanvasGridCoordinatesImpl.Builder()
                    .SetX(2)
                    .SetY(7)
                    .Build(),
                new CanvasGridCoordinatesImpl.Builder()
                    .SetX(5)
                    .SetY(1)
                    .Build());
            logger.Debug("Initializing SettingsMenu Widget");
            settingsMenuWidget.Initialize(
                new CanvasGridCoordinatesImpl.Builder()
                    .SetX(9)
                    .SetY(7)
                    .Build(),
                new CanvasGridCoordinatesImpl.Builder()
                    .SetX(2)
                    .SetY(2)
                    .Build());
            logger.Debug("Initializing Information Widget");
            informationWidget.Initialize(
                new CanvasGridCoordinatesImpl.Builder()
                    .SetX(9)
                    .SetY(0)
                    .Build(),
                new CanvasGridCoordinatesImpl.Builder()
                    .SetX(2)
                    .SetY(5)
                    .Build());

            // Todo: Add other loads/initializations here too?
            // Todo: probably call this initialize instead

            this.canvasUISet.Add(actionMenuWidget);
            this.canvasUISet.Add(scoreBoardWidget);
            this.canvasUISet.Add(settingsMenuWidget);
            this.canvasUISet.Add(turnScrollerWidget);
            this.canvasUISet.Add(informationWidget);
        }

        /// <summary>
        /// Todo
        /// </summary>
        void IMvcViewScript.UpdateWidgets()
        {
            foreach (ICanvasUI canvasUI in this.canvasUISet)
            {
                logger.Debug("Updating Entries: ?", canvasUI);
                canvasUI.UpdateEntries();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void Awake()
        {
            WidgetGridUtil.SetCanvasHeight(this.GetComponent<RectTransform>().rect.height);
            WidgetGridUtil.SetCanvasWidth(this.GetComponent<RectTransform>().rect.width);
        }
*/
    }
}