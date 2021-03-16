using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Canvases.Constants;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Canvases.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Reports.Api;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Objects.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public class UIObject
        : IUIObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IGridConvertor canvasGridConvertor;

        // Todo
        private readonly ISet<IPanel> panelSet;

        private readonly Transform transform;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="parentTransform"></param>
        /// <param name="viewConfigurationReport"></param>
        private UIObject(Transform parentTransform, ICanvasConfigurationReport viewConfigurationReport)
        {
            GameObject gameObject = new GameObject(this.GetType().Name);
            gameObject.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            Vector2 sizeDelta = gameObject.GetComponent<RectTransform>().sizeDelta;
            this.canvasGridConvertor = new GridConvertor.Builder()
                .SetGridDimensions(CanvasGridConstants.GetCanvasGridDimensions())
                .SetWorldHeight(sizeDelta.y)
                .SetWorldWidth(sizeDelta.x)
                .Build();
            this.transform = gameObject.transform;
            this.transform.SetParent(parentTransform);
        }

        void IUIObject.DisplayTalonOrderReport(ITalonOrderReport talonOrderReport)
        {
            logger.Debug("Display ?", talonOrderReport);
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
            private ICanvasConfigurationReport viewConfigurationReport = null;

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
            public Builder SetViewConfigurationReport(ICanvasConfigurationReport viewConfigurationReport)
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