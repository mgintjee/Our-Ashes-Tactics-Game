using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Dimensions.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Grids.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Grids.Reports.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Impl.ActionMenus.Impl.Defaults;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Abs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.ActionMenus.Api;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.ActionMenus.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PanelActionMenu
        : AbstractPanel, IPanelActionMenu
    {
        protected override void LoadDefaultPanelEntry()
        {
            IGridConfigurationReport defaultGridConfigurationReport = new GridConfigurationReport.Builder()
                .SetGridDimensions(this.panelGridDimensions)
                .Build();
            IPanelEntry panelEntry = new PanelEntryActionMenuDefault.Builder()
                .SetParentTransform(this.GetTransform())
                .SetPanelGridConvertor(this.panelGridConvertor)
                .SetPanelEntryConfigurationReport(defaultGridConfigurationReport)
                .Build();
            this.panelEntryList.Add(panelEntry);
        }

        void IPanelActionMenu.EnableButtons(bool enable)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IGridConfigurationReport panelConfigurationReport = null;

            // Todo
            private Transform parentTransform = null;

            // Todo
            private IGridConvertor canvasGridConvertor = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IPanelActionMenu Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    PanelActionMenu panelActionMenu =
                        new GameObject(typeof(PanelActionMenu).Name)
                        .AddComponent<PanelActionMenu>();
                    // TODO: Store the GridDimensions in a const file
                    ((IPanel)panelActionMenu).Initialize(this.canvasGridConvertor,
                        this.panelConfigurationReport,
                        new GridDimensions(1, 4),
                        this.parentTransform);
                    return panelActionMenu;
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="canvasConfigurationReport"></param>
            /// <returns></returns>
            public Builder SetCanvasConfigurationReport(IGridConfigurationReport canvasConfigurationReport)
            {
                this.panelConfigurationReport = canvasConfigurationReport;
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
            public Builder SetCanvasGridConvertor(IGridConvertor canvasGridConvertor)
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
                if (this.panelConfigurationReport == null)
                {
                    argumentExceptionSet.Add("Panel " + typeof(IGridConfigurationReport).Name + " cannot be null.");
                }
                if (this.parentTransform == null)
                {
                    argumentExceptionSet.Add("Parent " + typeof(Transform).Name + " cannot be null.");
                }
                if (this.canvasGridConvertor == null)
                {
                    argumentExceptionSet.Add("Canvas " + typeof(IGridConvertor).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}