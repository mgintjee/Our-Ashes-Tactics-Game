using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Canvases.Constants;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Canvases.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.ActionMenus.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.ActionMenus.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.Informationals.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.Informationals.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.ScoreBoards.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.ScoreBoards.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.SettingMenus.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.SettingMenus.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.TurnScrollers.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.TurnScrollers.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Reports.Api;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Objects.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CanvasObject
        : ICanvasObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IGridConvertor canvasGridConvertor;

        // Todo
        private readonly IPanelInformational panelInformational;

        // Todo
        private readonly IPanelActionMenu panelActionMenu;

        // Todo
        private readonly IPanelScoreBoard panelScoreBoard;

        // Todo
        private readonly IPanelSettingMenu panelSettingMenu;

        // Todo
        private readonly IPanelTurnScroller panelTurnScroller;

        // Todo
        private readonly ISet<IPanel> panelSet;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="parentTransform"></param>
        /// <param name="canvasConfigurationReport"></param>
        private CanvasObject(Transform parentTransform, ICanvasConfigurationReport canvasConfigurationReport)
        {
            GameObject gameObject = new GameObject(this.GetType().Name);
            gameObject.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            Vector2 sizeDelta = gameObject.GetComponent<RectTransform>().sizeDelta;
            this.canvasGridConvertor = new GridConvertor.Builder()
                .SetGridDimensions(CanvasGridConstants.GetCanvasGridDimensions())
                .SetWorldHeight(sizeDelta.y)
                .SetWorldWidth(sizeDelta.x)
                .Build();
            logger.Debug("Building ? with ?", this.GetType().Name, canvasConfigurationReport);
            gameObject.transform.SetParent(parentTransform);
            // Should verify that the configurationReport is valid, else use the default value
            this.panelInformational = new PanelInformational.Builder()
                .SetCanvasConfigurationReport(canvasConfigurationReport.GetInformationalGridConfigurationReport())
                .SetParentTransform(gameObject.transform)
                .SetCanvasGridConvertor(this.canvasGridConvertor)
                .Build();
            this.panelActionMenu = new PanelActionMenu.Builder()
                .SetCanvasConfigurationReport(canvasConfigurationReport.GetActionMenuGridConfigurationReport())
                .SetParentTransform(gameObject.transform)
                .SetCanvasGridConvertor(this.canvasGridConvertor)
                .Build();
            this.panelScoreBoard = new PanelScoreBoard.Builder()
                .SetCanvasConfigurationReport(canvasConfigurationReport.GetScoreBoardGridConfigurationReport())
                .SetParentTransform(gameObject.transform)
                .SetCanvasGridConvertor(this.canvasGridConvertor)
                .Build();
            this.panelSettingMenu = new PanelSettingMenu.Builder()
                .SetCanvasConfigurationReport(canvasConfigurationReport.GetSettingMenuGridConfigurationReport())
                .SetParentTransform(gameObject.transform)
                .SetCanvasGridConvertor(this.canvasGridConvertor)
                .Build();
            this.panelTurnScroller = new PanelTurnScroller.Builder()
                .SetCanvasConfigurationReport(canvasConfigurationReport.GetTurnScrollerGridConfigurationReport())
                .SetParentTransform(gameObject.transform)
                .SetCanvasGridConvertor(this.canvasGridConvertor)
                .Build();
            this.panelSet = new HashSet<IPanel>()
            {
                this.panelInformational, this.panelActionMenu, this.panelScoreBoard,
                this.panelSettingMenu, this.panelTurnScroller
            };
        }

        /// <inheritdoc/>
        void ICanvasObject.DisplayTalonOrderReport(ITalonOrderReport talonOrderReport)
        {
            logger.Debug("Display ?", talonOrderReport);
            this.panelInformational.BuildInformationalWidget(talonOrderReport);
        }

        /// <inheritdoc/>
        void ICanvasObject.UpdateCanvas()
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
            private ICanvasConfigurationReport canvasConfigurationReport = null;

            // Todo
            private Transform parentTransform = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ICanvasObject Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new CanvasObject(this.parentTransform, this.canvasConfigurationReport);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="canvasConfigurationReport"></param>
            /// <returns></returns>
            public Builder SetCanvasConfigurationReport(ICanvasConfigurationReport canvasConfigurationReport)
            {
                this.canvasConfigurationReport = canvasConfigurationReport;
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
                if (this.canvasConfigurationReport == null)
                {
                    argumentExceptionSet.Add(typeof(ICanvasConfigurationReport).Name + " can not be null.");
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