

namespace HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Actions.Orders
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Paths.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonActionOrderReportImpl
        : ITalonActionOrderReport
    {
        // Todo
        private readonly ITalonIdentificationReport actingTalonIdentificationReport;

        // Todo
        private readonly IPathObject pathObject;

        // Todo
        private readonly ActionTypeEnum actionType;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="actingTalonIdentificationReport">
        /// </param>
        /// <param name="pathObject">
        /// </param>
        private TalonActionOrderReportImpl(ITalonIdentificationReport actingTalonIdentificationReport, IPathObject pathObject)
        {
            this.actionType = ActionTypeEnum.Move;
            this.pathObject = pathObject;
            this.actingTalonIdentificationReport = actingTalonIdentificationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t> ActionType: " + this.actionType +
                "\n\t>" + this.actingTalonIdentificationReport +
                "\n\t>" + this.pathObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonIdentificationReport ITalonActionOrderReport.GetActingTalonIdentificationReport()
        {
            return this.actingTalonIdentificationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ActionTypeEnum ITalonActionOrderReport.GetActionType()
        {
            return this.actionType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IPathObject ITalonActionOrderReport.GetPathObject()
        {
            return this.pathObject;
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private ITalonIdentificationReport actingTalonIdentificationReport = null;

            // Todo
            private IPathObject pathObject = null;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public ITalonActionOrderReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonActionOrderReportImpl(this.actingTalonIdentificationReport, this.pathObject);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the ITalonIdentificationReport
            /// </summary>
            /// <param name="actingTalonIdentificationReport">
            /// The ITalonIdentificationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetActingTalonIdentificationReport(ITalonIdentificationReport actingTalonIdentificationReport)
            {
                this.actingTalonIdentificationReport = actingTalonIdentificationReport;
                return this;
            }

            /// <summary>
            /// Set the value of the IPathObject
            /// </summary>
            /// <param name="pathObject">
            /// The IPathObject to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetPathObject(IPathObject pathObject)
            {
                this.pathObject = pathObject;
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
                // Check that actingTalonIdentificationReport has been set
                if (this.actingTalonIdentificationReport == null)
                {
                    argumentExceptionSet.Add("Acting " + typeof(ITalonIdentificationReport).Name + " has not been set");
                }
                // Check that pathObject has been set
                if (this.pathObject == null)
                {
                    argumentExceptionSet.Add(typeof(IPathObject).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
