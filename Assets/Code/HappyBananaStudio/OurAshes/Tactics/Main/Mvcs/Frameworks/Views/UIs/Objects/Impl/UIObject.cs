namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Impl.ActionMenus.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Impl.ActionMenus.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Impl.GameLoggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Impl.GameLoggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Impl.Informationals.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Impl.Informationals.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Impl.ScoreBoards.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Impl.ScoreBoards.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Impl.SettingMenus.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Impl.SettingMenus.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Impl.TurnScrollers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Impl.TurnScrollers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Utils;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Objects.Api;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class UIObject
        : IUIObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly ICanvasActionMenu canvasActionMenu;

        // Todo
        private readonly ICanvasGameLogger canvasGameLogger;

        // Todo
        private readonly ICanvasInformational canvasInformational;

        // Todo
        private readonly ICanvasScoreBoard canvasScoreBoard;

        // Todo
        private readonly ICanvasSettingMenu canvasSettingMenu;

        // Todo
        private readonly ICanvasTurnScroller canvasTurnScroller;

        // Todo
        private readonly ISet<ICanvas> canvasSet;

        private readonly Transform transform;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="parentTransform"></param>
        /// <param name="viewConfigurationReport"></param>
        private UIObject(Transform parentTransform, IViewConfigurationReport viewConfigurationReport)
        {
            GameObject gameObject = new GameObject(this.GetType().Name);
            gameObject.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            CanvasGridUtil.SetCanvasHeight(gameObject.GetComponent<RectTransform>().sizeDelta.y);
            CanvasGridUtil.SetCanvasWidth(gameObject.GetComponent<RectTransform>().sizeDelta.x);
            this.transform = gameObject.transform;
            this.transform.SetParent(parentTransform);
            // Should verify that the configurationReport is valid, else use the default value
            this.canvasActionMenu = new CanvasActionMenu.Builder()
                .SetParentTransform(this.transform)
                .SetCanvasConfigurationReport(viewConfigurationReport.GetCanvasActionMenuConfigurationReport())
                .Build();
            this.canvasGameLogger = new CanvasGameLogger.Builder()
                .SetCanvasConfigurationReport(viewConfigurationReport.GetCanvasGameLoggerConfigurationReport())
                .SetParentTransform(this.transform)
                .Build();
            this.canvasInformational = new CanvasInformational.Builder()
                .SetCanvasConfigurationReport(viewConfigurationReport.GetCanvasInformationalConfigurationReport())
                .SetParentTransform(this.transform)
                .Build();
            this.canvasScoreBoard = new CanvasScoreBoard.Builder()
                .SetCanvasConfigurationReport(viewConfigurationReport.GetCanvasScoreBoardConfigurationReport())
                .SetParentTransform(this.transform)
                .Build();
            this.canvasSettingMenu = new CanvasSettingMenu.Builder()
                .SetCanvasConfigurationReport(viewConfigurationReport.GetCanvasSettingMenuConfigurationReport())
                .SetParentTransform(this.transform)
                .Build();
            this.canvasTurnScroller = new CanvasTurnScroller.Builder()
                .SetCanvasConfigurationReport(viewConfigurationReport.GetCanvasTurnScrollerConfigurationReport())
                .SetParentTransform(this.transform)
                .Build();
            this.canvasSet = new HashSet<ICanvas>()
            {
                this.canvasActionMenu, this.canvasGameLogger, this.canvasInformational,
                this.canvasScoreBoard, this.canvasSettingMenu, this.canvasTurnScroller
            };

            this.canvasGameLogger.WriteToGameLogger("FUCK THEM FOES");
        }

        /// <summary>
        /// Todo
        /// </summary>
        void IUIObject.UpdateCanvas()
        {
            foreach (ICanvas canvas in this.canvasSet)
            {
                canvas.UpdateWidgets();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IViewConfigurationReport viewConfigurationReport = null;

            // Todo
            private Transform parentTransform = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IUIObject Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new UIObject(this.parentTransform, this.viewConfigurationReport);
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
            /// <param name="parentTransform"></param>
            /// <returns></returns>
            public Builder SetParentTransform(Transform parentTransform)
            {
                this.parentTransform = parentTransform;
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
                if (this.viewConfigurationReport == null)
                {
                    argumentExceptionSet.Add(typeof(IViewConfigurationReport).Name + " can not be null.");
                }
                if (this.parentTransform == null)
                {
                    argumentExceptionSet.Add("Parent " + typeof(Transform).Name + " can not be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}