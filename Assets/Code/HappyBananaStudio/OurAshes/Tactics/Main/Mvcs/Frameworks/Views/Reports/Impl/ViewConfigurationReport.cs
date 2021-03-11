namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Constants.Grids;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.ActionMenus.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.Informationals.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.ScoreBoards.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.SettingMenus.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Impl.TurnScrollers.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct ViewConfigurationReport
        : IViewConfigurationReport
    {
        // Todo
        private readonly ICanvasConfigurationReport canvasActionMenuConfigurationReport;

        // Todo
        private readonly ICanvasConfigurationReport canvasInformationalConfigurationReport;

        // Todo
        private readonly ICanvasConfigurationReport canvasScoreBoardConfigurationReport;

        // Todo
        private readonly ICanvasConfigurationReport canvasSettingMenuConfigurationReport;

        // Todo
        private readonly ICanvasConfigurationReport canvasTurnScrollerConfigurationReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasActionMenuConfigurationReport"></param>
        /// <param name="canvasInformationalConfigurationReport"></param>
        /// <param name="canvasScoreBoardConfigurationReport"></param>
        /// <param name="canvasSettingMenuConfigurationReport"></param>
        /// <param name="canvasTurnScrollerConfigurationReport"></param>
        private ViewConfigurationReport(ICanvasConfigurationReport canvasActionMenuConfigurationReport,
            ICanvasConfigurationReport canvasInformationalConfigurationReport, ICanvasConfigurationReport canvasScoreBoardConfigurationReport,
            ICanvasConfigurationReport canvasSettingMenuConfigurationReport, ICanvasConfigurationReport canvasTurnScrollerConfigurationReport)
        {
            this.canvasActionMenuConfigurationReport = canvasActionMenuConfigurationReport;
            this.canvasInformationalConfigurationReport = canvasInformationalConfigurationReport;
            this.canvasScoreBoardConfigurationReport = canvasScoreBoardConfigurationReport;
            this.canvasSettingMenuConfigurationReport = canvasSettingMenuConfigurationReport;
            this.canvasTurnScrollerConfigurationReport = canvasTurnScrollerConfigurationReport;
        }

        /// <inheritdoc/>
        ICanvasConfigurationReport IViewConfigurationReport.GetCanvasActionMenuConfigurationReport()
        {
            return this.canvasActionMenuConfigurationReport;
        }

        /// <inheritdoc/>
        ICanvasConfigurationReport IViewConfigurationReport.GetCanvasInformationalConfigurationReport()
        {
            return this.canvasInformationalConfigurationReport;
        }

        /// <inheritdoc/>
        ICanvasConfigurationReport IViewConfigurationReport.GetCanvasScoreBoardConfigurationReport()
        {
            return this.canvasScoreBoardConfigurationReport;
        }

        /// <inheritdoc/>
        ICanvasConfigurationReport IViewConfigurationReport.GetCanvasSettingMenuConfigurationReport()
        {
            return this.canvasSettingMenuConfigurationReport;
        }

        /// <inheritdoc/>
        ICanvasConfigurationReport IViewConfigurationReport.GetCanvasTurnScrollerConfigurationReport()
        {
            return this.canvasTurnScrollerConfigurationReport;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: " +
                "\n\t> {1} {2}" +
                "\n\t> {3} {4}" +
                "\n\t> {5} {6}" +
                "\n\t> {7} {8}" +
                "\n\t> {9} {10}" +
                "\n\t> {11} {12}",
                this.GetType().Name,
                typeof(IPanelActionMenu).Name, this.canvasActionMenuConfigurationReport,
                typeof(IPanelInformational).Name, this.canvasInformationalConfigurationReport,
                typeof(ICanvasScoreBoard).Name, this.canvasScoreBoardConfigurationReport,
                typeof(ICanvasSettingMenu).Name, this.canvasSettingMenuConfigurationReport,
                typeof(ICanvasTurnScroller).Name, this.canvasTurnScrollerConfigurationReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ICanvasConfigurationReport canvasActionMenuConfigurationReport = null;

            // Todo
            private ICanvasConfigurationReport canvasInformationalConfigurationReport = null;

            // Todo
            private ICanvasConfigurationReport canvasScoreBoardConfigurationReport = null;

            // Todo
            private ICanvasConfigurationReport canvasSettingMenuConfigurationReport = null;

            // Todo
            private ICanvasConfigurationReport canvasTurnScrollerConfigurationReport = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IViewConfigurationReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    return new ViewConfigurationReport(this.canvasActionMenuConfigurationReport,
                        this.canvasInformationalConfigurationReport, this.canvasScoreBoardConfigurationReport,
                        this.canvasSettingMenuConfigurationReport, this.canvasTurnScrollerConfigurationReport);
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
            /// <param name="canvasActionMenuConfigurationReport"></param>
            /// <returns></returns>
            public Builder SetCanvasActionMenuConfigurationReport(ICanvasConfigurationReport canvasActionMenuConfigurationReport)
            {
                this.canvasActionMenuConfigurationReport = canvasActionMenuConfigurationReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="canvasInformationalConfigurationReport"></param>
            /// <returns></returns>
            public Builder SetCanvasInformationalConfigurationReport(ICanvasConfigurationReport canvasInformationalConfigurationReport)
            {
                this.canvasInformationalConfigurationReport = canvasInformationalConfigurationReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="canvasScoreBoardConfigurationReport"></param>
            /// <returns></returns>
            public Builder SetCanvasScoreBoardConfigurationReport(ICanvasConfigurationReport canvasScoreBoardConfigurationReport)
            {
                this.canvasScoreBoardConfigurationReport = canvasScoreBoardConfigurationReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="canvasSettingMenuConfigurationReport"></param>
            /// <returns></returns>
            public Builder SetCanvasSettingMenuConfigurationReport(ICanvasConfigurationReport canvasSettingMenuConfigurationReport)
            {
                this.canvasSettingMenuConfigurationReport = canvasSettingMenuConfigurationReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="canvasTurnScrollerConfigurationReport"></param>
            /// <returns></returns>
            public Builder SetCanvasTurnScrollerConfigurationReport(ICanvasConfigurationReport canvasTurnScrollerConfigurationReport)
            {
                this.canvasTurnScrollerConfigurationReport = canvasTurnScrollerConfigurationReport;
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
                if (this.canvasActionMenuConfigurationReport == null)
                {
                    argumentExceptionSet.Add(typeof(IPanelActionMenu).Name + " " + typeof(ICanvasConfigurationReport).Name + " cannot be null.");
                }
                if (this.canvasInformationalConfigurationReport == null)
                {
                    argumentExceptionSet.Add(typeof(IPanelInformational).Name + " " + typeof(ICanvasConfigurationReport).Name + " cannot be null.");
                }
                if (this.canvasScoreBoardConfigurationReport == null)
                {
                    argumentExceptionSet.Add(typeof(ICanvasScoreBoard).Name + " " + typeof(ICanvasConfigurationReport).Name + " cannot be null.");
                }
                if (this.canvasSettingMenuConfigurationReport == null)
                {
                    argumentExceptionSet.Add(typeof(ICanvasSettingMenu).Name + " " + typeof(ICanvasConfigurationReport).Name + " cannot be null.");
                }
                if (this.canvasTurnScrollerConfigurationReport == null)
                {
                    argumentExceptionSet.Add(typeof(ICanvasTurnScroller).Name + " " + typeof(ICanvasConfigurationReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static IViewConfigurationReport DefaultViewConfigurationReport()
        {
            return new ViewConfigurationReport(
                CanvasConfigurationReportConstants.ActionMenuConfigurationReport(),
                CanvasConfigurationReportConstants.InformationalConfigurationReport(),
                CanvasConfigurationReportConstants.ScoreBoardConfigurationReport(),
                CanvasConfigurationReportConstants.SettingMenuConfigurationReport(),
                CanvasConfigurationReportConstants.TurnScrollerConfigurationReport());
        }
    }
}