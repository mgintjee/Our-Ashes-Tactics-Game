namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Constants.Reports;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Convertors.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Convertors.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.ActionMenus.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.Informationals.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.Informationals.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.ScoreBoards.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.SettingMenus.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.TurnScrollers.Api;
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
        private readonly ICanvasGridConvertor canvasGridConvertor;

        // Todo
        private readonly IPanelActionMenu canvasActionMenu;

        // Todo
        private readonly IPanelInformational canvasInformational;

        // Todo
        private readonly ICanvasScoreBoard canvasScoreBoard;

        // Todo
        private readonly ICanvasSettingMenu canvasSettingMenu;

        // Todo
        private readonly ICanvasTurnScroller canvasTurnScroller;

        // Todo
        private readonly ISet<IPanel> panelSet;

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
            Vector2 sizeDelta = gameObject.GetComponent<RectTransform>().sizeDelta;
            this.canvasGridConvertor = new CanvasGridConvertor.Builder()
                .SetCanvasGridDimensions(CanvasGridConstants.GetCanvasGridDimensions())
                .SetCanvasHeight(sizeDelta.y)
                .SetCanvasWidth(sizeDelta.x)
                .Build();
            this.transform = gameObject.transform;
            this.transform.SetParent(parentTransform);
            // Should verify that the configurationReport is valid, else use the default value
            this.canvasInformational = new PanelInformational.Builder()
                .SetCanvasConfigurationReport(viewConfigurationReport.GetCanvasInformationalConfigurationReport())
                .SetParentTransform(this.transform)
                .SetCanvasGridConvertor(this.canvasGridConvertor)
                .Build();
            /*
            this.canvasActionMenu = new CanvasActionMenu.Builder()
                .SetParentTransform(this.transform)
                .SetCanvasConfigurationReport(viewConfigurationReport.GetCanvasActionMenuConfigurationReport())
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
                this.canvasActionMenu, this.canvasInformational, this.canvasScoreBoard,
                this.canvasSettingMenu, this.canvasTurnScroller
            };
            */
        }

        void IUIObject.DisplayTalonOrderReport(ITalonOrderReport talonOrderReport)
        {
            logger.Debug("Display ?", talonOrderReport);
            this.canvasInformational.BuildInformationalWidget(talonOrderReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        void IUIObject.UpdateCanvas()
        {
            foreach (IPanel canvas in this.panelSet)
            {
                canvas.UpdatePanelEntries();
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
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                    this.GetType(), string.Join("\n", invalidReasons));
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