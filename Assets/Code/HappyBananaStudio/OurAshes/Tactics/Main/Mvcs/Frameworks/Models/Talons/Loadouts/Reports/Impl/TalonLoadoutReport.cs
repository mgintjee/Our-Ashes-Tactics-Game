namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Attributes.Constants;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Common.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Reports.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonLoadoutReport
        : ITalonLoadoutReport
    {
        // Todo
        private readonly TalonId talonId;

        // Todo
        private readonly IArmorReport armorReport;

        // Todo
        private readonly IEngineReport engineReport;

        // Todo
        private readonly IList<IMountReport> mountReportList;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armorReport"></param>
        /// <param name="engineReport"></param>
        /// <param name="mountReportList"></param>
        private TalonLoadoutReport(TalonId talonId, IArmorReport armorReport, IEngineReport engineReport, IList<IMountReport> mountReportList)
        {
            this.talonId = talonId;
            this.armorReport = armorReport;
            this.engineReport = engineReport;
            this.mountReportList = new List<IMountReport>(mountReportList);
        }

        /// <inheritdoc/>
        IArmorReport ITalonLoadoutReport.GetArmorReport()
        {
            return this.armorReport;
        }

        /// <inheritdoc/>
        IEngineReport ITalonLoadoutReport.GetEngineReport()
        {
            return this.engineReport;
        }

        /// <inheritdoc/>
        IList<IMountReport> ITalonLoadoutReport.GetMountReportList()
        {
            return new List<IMountReport>(this.mountReportList);
        }

        /// <inheritdoc/>
        TalonId ITalonLoadoutReport.GetTalonId()
        {
            return this.talonId;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}={2}, " +
                "\n\t>{3}," +
                "\n\t>{4}," +
                "[\n\t>{5}]",
                this.GetType().Name, typeof(TalonId).Name, this.talonId,
                this.armorReport, this.engineReport, string.Join("\n\t>", this.mountReportList));
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private TalonId talonId = TalonId.None;

            // Todo
            private IArmorReport armorReport = null;

            // Todo
            private IEngineReport engineReport = null;

            // Todo
            private IList<IMountReport> mountReportList = null;

            /// <summary>
            /// Build the report implementation with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public ITalonLoadoutReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonLoadoutReport(this.talonId, this.armorReport, this.engineReport, this.mountReportList);
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="talonId"></param>
            /// <returns></returns>
            public Builder SetTalonId(TalonId talonId)
            {
                this.talonId = talonId;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="armorReport"></param>
            /// <returns></returns>
            public Builder SetArmorReport(IArmorReport armorReport)
            {
                this.armorReport = armorReport;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="engineReport"></param>
            /// <returns></returns>
            public Builder SetEngineReport(IEngineReport engineReport)
            {
                this.engineReport = engineReport;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="mountReportList"></param>
            /// <returns></returns>
            public Builder SetMountReportList(IList<IMountReport> mountReportList)
            {
                this.mountReportList = new List<IMountReport>(mountReportList);
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
                // Check that talonId has been set
                if (this.talonId == TalonId.None)
                {
                    argumentExceptionSet.Add(typeof(TalonId) + " has not been set");
                }
                // Otherwise check that the mountReportList is valid
                else
                {
                    // Check that mountReportList is valid
                    if (this.mountReportList.Count !=
                        TalonLoadoutAttributesConstants.GetTalonLoadoutAttributes(this.talonId).GetMountSizeList().Count)
                    {
                        argumentExceptionSet.Add("List:" + typeof(IMountReport) + " is not valid.");
                    }
                }
                // Check that armorReport has been set
                if (this.armorReport == null)
                {
                    argumentExceptionSet.Add(typeof(IArmorReport) + " has not been set");
                }
                // Check that engineReport has been set
                if (this.engineReport == null)
                {
                    argumentExceptionSet.Add(typeof(IEngineReport) + " has not been set");
                }
                // Check that mountReportList has been set
                if (this.mountReportList == null)
                {
                    argumentExceptionSet.Add("List:" + typeof(IMountReport) + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}