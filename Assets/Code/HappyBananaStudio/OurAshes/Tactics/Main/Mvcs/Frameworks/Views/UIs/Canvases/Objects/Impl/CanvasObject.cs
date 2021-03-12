namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Constants.Reports;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Convertors.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Convertors.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.Informationals.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.Informationals.Impl;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

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
        private readonly IPanelInformational canvasInformational;

        // Todo
        private readonly ISet<IPanel> panelSet;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="parentTransform"></param>
        /// <param name="viewConfigurationReport"></param>
        private CanvasObject(Transform parentTransform, IViewConfigurationReport viewConfigurationReport)
        {
            GameObject gameObject = new GameObject(this.GetType().Name);
            gameObject.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            Vector2 sizeDelta = gameObject.GetComponent<RectTransform>().sizeDelta;
            this.canvasGridConvertor = new GridCoordinatesConvertor.Builder()
                .SetGridDimensions(CanvasGridConstants.GetCanvasGridDimensions())
                .SetWorldHeight(sizeDelta.y)
                .SetWorldWidth(sizeDelta.x)
                .Build();
            logger.Debug("?", parentTransform.name);
            gameObject.transform.SetParent(parentTransform);
            // Should verify that the configurationReport is valid, else use the default value
            this.canvasInformational = new PanelInformational.Builder()
                .SetCanvasConfigurationReport(viewConfigurationReport.GetCanvasInformationalConfigurationReport())
                .SetParentTransform(gameObject.transform)
                .SetCanvasGridConvertor(this.canvasGridConvertor)
                .Build();
        }

        /// <inheritdoc/>
        void ICanvasObject.DisplayTalonOrderReport(ITalonOrderReport talonOrderReport)
        {
            logger.Debug("Display ?", talonOrderReport);
            this.canvasInformational.BuildInformationalWidget(talonOrderReport);
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
            private IViewConfigurationReport viewConfigurationReport = null;

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
                    return new CanvasObject(this.parentTransform, this.viewConfigurationReport);
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