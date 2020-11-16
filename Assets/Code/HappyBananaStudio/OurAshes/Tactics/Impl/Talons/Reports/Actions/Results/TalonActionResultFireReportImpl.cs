
namespace HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Actions.Results
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Results;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Weapons.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonActionResultFireReportImpl
        : ITalonActionResultFireReport
    {
        // Todo
        private readonly ITalonAttributesReport actingTalonAttributesReport;

        // Todo
        private readonly ITalonActionOrderReport talonActionOrderReport;

        // Todo
        private readonly ITalonAttributesReport targetTalonAttributesReport;

        // Todo
        private readonly IList<IWeaponResultReport> weaponResultReportList;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrderReport">
        /// </param>
        /// <param name="actingTalonAttributesReport">
        /// </param>
        /// <param name="targetTalonAttributesReport">
        /// </param>
        /// <param name="weaponResultReportList">
        /// </param>
        private TalonActionResultFireReportImpl(ITalonActionOrderReport talonActionOrderReport,
            ITalonAttributesReport actingTalonAttributesReport, ITalonAttributesReport targetTalonAttributesReport,
            IList<IWeaponResultReport> weaponResultReportList)
        {
            this.talonActionOrderReport = talonActionOrderReport;
            this.actingTalonAttributesReport = actingTalonAttributesReport;
            this.targetTalonAttributesReport = targetTalonAttributesReport;
            this.weaponResultReportList = weaponResultReportList;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + this.talonActionOrderReport +
                "\n\t> List:" + typeof(IWeaponResultReport).Name +
                "=[\n\t>" + string.Join(" \n\t>", this.weaponResultReportList) + "\n]" +
                "\n\t>" + this.actingTalonAttributesReport +
                "\n\t>" + this.targetTalonAttributesReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonAttributesReport ITalonActionResultReport.GetActingTalonAttributesReport()
        {
            return this.actingTalonAttributesReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonActionOrderReport ITalonActionResultReport.GetTalonActionOrder()
        {
            return this.talonActionOrderReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonAttributesReport ITalonActionResultFireReport.GetTargetTalonAttributesReport()
        {
            return this.targetTalonAttributesReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IList<IWeaponResultReport> ITalonActionResultFireReport.GetWeaponResultReportList()
        {
            return new List<IWeaponResultReport>(this.weaponResultReportList);
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private ITalonAttributesReport actingTalonAttributesReport = null;

            // Todo
            private ITalonActionOrderReport talonActionOrderReport = null;

            // Todo
            private ITalonAttributesReport targetTalonAttributesReport = null;

            // Todo
            private IList<IWeaponResultReport> weaponResultReportList = null;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public ITalonActionResultFireReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonActionResultFireReportImpl(this.talonActionOrderReport,
                        this.targetTalonAttributesReport, this.targetTalonAttributesReport, this.weaponResultReportList);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the Acting ITalonAttributesReport
            /// </summary>
            /// <param name="actingTalonAttributesReport">
            /// The Acting ITalonAttributesReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetActingTalonAttributesReport(ITalonAttributesReport actingTalonAttributesReport)
            {
                this.actingTalonAttributesReport = actingTalonAttributesReport;
                return this;
            }

            /// <summary>
            /// Set the value of the ITalonActionOrderReport
            /// </summary>
            /// <param name="talonActionOrderReport">
            /// The ITalonActionOrderReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonActionOrderReport(ITalonActionOrderReport talonActionOrderReport)
            {
                this.talonActionOrderReport = talonActionOrderReport;
                return this;
            }

            /// <summary>
            /// Set the value of the Target ITalonAttributesReport
            /// </summary>
            /// <param name="targetTalonAttributesReport">
            /// The Target ITalonAttributesReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTargetTalonAttributesReport(ITalonAttributesReport targetTalonAttributesReport)
            {
                this.targetTalonAttributesReport = targetTalonAttributesReport;
                return this;
            }

            /// <summary>
            /// Set the value of the List: IWeaponResultReport
            /// </summary>
            /// <param name="weaponResultReportList">
            /// The List: IWeaponResultReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetWeaponResultReportList(IList<IWeaponResultReport> weaponResultReportList)
            {
                this.weaponResultReportList = new List<IWeaponResultReport>(weaponResultReportList);
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
                // Check that talonActionOrderReport has been set
                if (this.talonActionOrderReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonActionOrderReport).Name + " has not been set");
                }
                // Check that actingTalonAttributesReport has been set
                if (this.actingTalonAttributesReport == null)
                {
                    argumentExceptionSet.Add("Acting " + typeof(ITalonAttributesReport).Name + " has not been set");
                }
                // Check that targetTalonAttributesReport has been set
                if (this.targetTalonAttributesReport == null)
                {
                    argumentExceptionSet.Add("Target " + typeof(ITalonAttributesReport).Name + " has not been set");
                }
                // Check that weaponResultReportList has been set
                if (this.weaponResultReportList == null)
                {
                    argumentExceptionSet.Add("List: " + typeof(IWeaponResultReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
