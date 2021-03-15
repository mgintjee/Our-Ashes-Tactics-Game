using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Dimensions.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Impl.Informationals.Abs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Impl.Informationals.Api;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Impl.Informationals.Defaults.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PanelEntryInformationalDefault
        : AbstractPanelEntryInformational
    {
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
            public IPanelEntryInformational Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    PanelEntryInformationalDefault panelEntryInformationalDefault =
                        new GameObject(typeof(PanelEntryInformationalDefault).Name)
                        .AddComponent<PanelEntryInformationalDefault>();
                    // TODO: Store in a const file or something
                    panelEntryInformationalDefault.panelEntryGridDimensions = new GridDimensions(4, 5);
                    panelEntryInformationalDefault.SetParentTransform(this.parentTransform);
                    ((IPanelEntry)panelEntryInformationalDefault).SetPanelEntryConfigurationReport(
                        this.panelGridConvertor, this.panelEntryConfigurationReport);
                    panelEntryInformationalDefault.LoadBackgroundImage();
                    panelEntryInformationalDefault.BuildHeader(typeof(PanelEntryInformationalDefault).Name);
                    return panelEntryInformationalDefault;
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