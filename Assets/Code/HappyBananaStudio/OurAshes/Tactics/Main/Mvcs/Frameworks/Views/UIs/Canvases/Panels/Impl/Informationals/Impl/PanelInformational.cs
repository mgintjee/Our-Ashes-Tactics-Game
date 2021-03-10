namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.Informationals.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.Informationals.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Reports.Api;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class PanelInformational
        : AbstractPanel, IPanelInformational
    {
        // Todo
        private readonly IList<IComplexWidgetInformational> complexWidgetInformationalList = new List<IComplexWidgetInformational>();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonOrderReport"></param>
        void IPanelInformational.BuildInformationalWidget(ITalonOrderReport talonOrderReport)
        {
            this.ClearInformational();
            this.complexWidgetInformationalList.Add(new ComplexWidgetInformationalOrder.Builder()
                .SetParentTransform(this.GetTransform())
                .SetTalonOrderReport(talonOrderReport)
                .Build());
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void LoadCanvasEntryWidgets()
        {
            this.UpdateCanvasEntryWidgets();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void ClearInformational()
        {
            foreach (IComplexWidgetInformational complexWidgetInformational in this.complexWidgetInformationalList)
            {
                complexWidgetInformational.Destroy();
            }
            this.complexWidgetInformationalList.Clear();
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
            public IPanelInformational Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    PanelInformational canvasInformational = new GameObject(typeof(PanelInformational).Name)
                        .AddComponent<PanelInformational>();
                    canvasInformational.GetTransform().SetParent(this.parentTransform);
                    canvasInformational.GetTransform().localPosition = Vector3.zero;
                    canvasInformational.GetTransform().localScale = Vector3.one;
                    canvasInformational.SetCanvasConfigurationReport(this.canvasConfigurationReport);
                    canvasInformational.BuildConvertor(new CanvasGridCoordinates.Builder()
                        .SetColIndex(4).SetRowIndex(6).Build());
                    canvasInformational.LoadCanvasEntryWidgets();
                    return canvasInformational;
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
                    argumentExceptionSet.Add(typeof(ICanvasConfigurationReport).Name + " cannot be null.");
                }
                if (this.parentTransform == null)
                {
                    argumentExceptionSet.Add("Parent " + typeof(Transform).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}