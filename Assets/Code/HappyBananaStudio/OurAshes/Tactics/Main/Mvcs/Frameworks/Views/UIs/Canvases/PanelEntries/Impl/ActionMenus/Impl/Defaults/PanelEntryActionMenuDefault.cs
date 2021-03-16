using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Grids.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Impl.ActionMenus.Abs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Impl.ActionMenus.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Impl.ActionMenus.Constants;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Impl.Informationals.Constants;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Impl.ActionMenus.Impl.Defaults
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PanelEntryActionMenuDefault
        : AbstractPanelEntryActionMenu
    {
        /// <inheritdoc/>
        protected override void LoadPanelEntryGridDimensions()
        {
            this.panelEntryGridDimensions = PanelEntryInformationalConstants.GetDefaultGridDimensions();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private Transform parentTransform = null;

            // Todo
            private IGridConvertor panelGridConvertor = null;

            // Todo
            private IGridConfigurationReport panelEntryConfigurationReport = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IPanelEntryActionMenu Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    PanelEntryActionMenuDefault panelEntryActionMenuDefault =
                        new GameObject(typeof(PanelEntryActionMenuDefault).Name)
                        .AddComponent<PanelEntryActionMenuDefault>();
                    ((IPanelEntry)panelEntryActionMenuDefault).Initialize(
                        this.panelGridConvertor, this.panelEntryConfigurationReport, this.parentTransform);
                    panelEntryActionMenuDefault.BuildHeader(
                        PanelEntryActionMenuConstants.GetDefaultHeaderString(),
                        PanelEntryActionMenuConstants.GetDefaultGridConfigurationReport());
                    return panelEntryActionMenuDefault;
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
            /// <param name="panelGridConvertor"></param>
            /// <returns></returns>
            public Builder SetPanelGridConvertor(IGridConvertor panelGridConvertor)
            {
                this.panelGridConvertor = panelGridConvertor;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="panelEntryConfigurationReport"></param>
            /// <returns></returns>
            public Builder SetPanelEntryConfigurationReport(IGridConfigurationReport panelEntryConfigurationReport)
            {
                this.panelEntryConfigurationReport = panelEntryConfigurationReport;
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
                if (this.parentTransform == null)
                {
                    argumentExceptionSet.Add("Parent " + typeof(Transform).Name + " cannot be null.");
                }
                if (this.panelGridConvertor == null)
                {
                    argumentExceptionSet.Add("Panel " + typeof(IGridConvertor).Name + " cannot be null.");
                }
                if (this.panelEntryConfigurationReport == null)
                {
                    argumentExceptionSet.Add("Panel Entry " + typeof(IGridConfigurationReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}