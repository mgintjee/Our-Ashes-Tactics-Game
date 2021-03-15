using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Actions.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Reports.Api;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Actions.Reports.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonActionReport
        : ITalonActionReport
    {
        // Todo
        private readonly TalonCallSign talonCallSign;

        // Todo
        private readonly ISet<ITalonOrderReport> talonActionOrderReportSet;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <param name="talonActionOrderReportSet"></param>
        private TalonActionReport(TalonCallSign talonCallSign, ISet<ITalonOrderReport> talonActionOrderReportSet)
        {
            this.talonCallSign = talonCallSign;
            this.talonActionOrderReportSet = talonActionOrderReportSet;
        }

        /// <inheritdoc/>
        ISet<ITalonOrderReport> ITalonActionReport.GetTalonActionOrderReportSet()
        {
            return this.talonActionOrderReportSet;
        }

        /// <inheritdoc/>
        TalonCallSign ITalonActionReport.GetTalonCallSign()
        {
            return this.talonCallSign;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private TalonCallSign talonCallSign = TalonCallSign.None;

            // Todo
            private ISet<ITalonOrderReport> talonActionOrderReportSet = new HashSet<ITalonOrderReport>();

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ITalonActionReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new TalonActionReport(this.talonCallSign, this.talonActionOrderReportSet);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonCallSign"></param>
            /// <returns></returns>
            public Builder SetTalonCallSign(TalonCallSign talonCallSign)
            {
                this.talonCallSign = talonCallSign;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonActionOrderReportSet"></param>
            /// <returns></returns>
            public Builder SetTalonActionOrderReportSet(ISet<ITalonOrderReport> talonActionOrderReportSet)
            {
                this.talonActionOrderReportSet = new HashSet<ITalonOrderReport>(talonActionOrderReportSet);
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
                // Check that talonCallSign has been set
                if (this.talonCallSign == TalonCallSign.None)
                {
                    argumentExceptionSet.Add(typeof(TalonCallSign) + " has not been set");
                }
                // Check that talonActionOrderReportSet has been set
                if (this.talonActionOrderReportSet == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(ITalonOrderReport) + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}