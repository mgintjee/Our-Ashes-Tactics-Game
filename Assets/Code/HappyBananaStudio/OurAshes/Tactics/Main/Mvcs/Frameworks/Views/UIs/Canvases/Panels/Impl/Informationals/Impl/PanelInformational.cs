namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.Informationals.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Convertors.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Abs;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.Informationals.Api;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class PanelInformational
        : AbstractPanel, IPanelInformational
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonOrderReport"></param>
        void IPanelInformational.BuildInformationalWidget(ITalonOrderReport talonOrderReport)
        {
            this.RemovePanelEntries();
            IPanelEntry panelEntry = null;
            this.AddPanelEntry(panelEntry, new CanvasConfigurationReport.Builder()
                .Build());
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

            // Todo
            private ICanvasGridConvertor canvasGridConvertor = null;

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
                    // Todo: Store in a const file
                    canvasInformational.panelGridDimensions = new CanvasGridCoordinates.Builder()
                        .SetCol(4)
                        .SetRow(6)
                        .Build();
                    canvasInformational.SetParentTransform(this.parentTransform);
                    canvasInformational.SetCanvasConfigurationReport(
                        this.canvasGridConvertor, this.canvasConfigurationReport);
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
            /// <param name="canvasGridConvertor"></param>
            /// <returns></returns>
            public Builder SetCanvasGridConvertor(ICanvasGridConvertor canvasGridConvertor)
            {
                this.canvasGridConvertor = canvasGridConvertor;
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
                if (this.canvasGridConvertor == null)
                {
                    argumentExceptionSet.Add(typeof(ICanvasGridConvertor).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}