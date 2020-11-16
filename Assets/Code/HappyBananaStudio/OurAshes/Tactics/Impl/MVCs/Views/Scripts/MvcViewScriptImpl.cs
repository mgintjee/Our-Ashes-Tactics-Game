
namespace HappyBananaStudio.OurAshes.Tactics.Impl.MVCs.Views.Scripts
{
    using HappyBananaStudio.OurAshes.Tactics.Abs.Unity.Scripts;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Views.Scripts;
    using HappyBananaStudio.OurAshes.Tactics.Api.UIs.CanvasUIs;
    using HappyBananaStudio.OurAshes.Tactics.Common.ResourceLoaders;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Widgets;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Coordinates.Objects.Canvas;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// MvcView Script Api
    /// </summary>
    public class MvcViewScriptImpl
        : AbstractUnityScriptImpl, IMvcViewScript
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly ISet<ICanvasUI> canvasUISet = new HashSet<ICanvasUI>();

        // private ITalonTurnWidget talonTurnWidget; private ITalonActionWidget talonActionWidget;
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
            actionMenuWidget.Initialize(new CanvasGridCoordinatesImpl(0, 0), new CanvasGridCoordinatesImpl(2, 5));
            logger.Debug("Initializing ScoreBoard Widget");
            scoreBoardWidget.Initialize(new CanvasGridCoordinatesImpl(0, 7), new CanvasGridCoordinatesImpl(2, 2));
            logger.Debug("Initializing TurnScroller Widget");
            turnScrollerWidget.Initialize(new CanvasGridCoordinatesImpl(2, 7), new CanvasGridCoordinatesImpl(5, 1));
            logger.Debug("Initializing SettingsMenu Widget");
            settingsMenuWidget.Initialize(new CanvasGridCoordinatesImpl(9, 7), new CanvasGridCoordinatesImpl(2, 2));
            logger.Debug("Initializing Information Widget");
            informationWidget.Initialize(new CanvasGridCoordinatesImpl(9, 0), new CanvasGridCoordinatesImpl(2, 5));

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
    }
}
