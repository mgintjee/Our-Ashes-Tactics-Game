using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Constructions.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Views.Customizations.Reports.Api;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Constructions.Reports.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonConstructionReport
        : ITalonConstructionReport
    {
        // Todo
        private readonly TalonCallSign talonCallSign;

        // Todo
        private readonly ITalonCustomizationReport talonCustomizationReport;

        // Todo
        private readonly ITalonLoadoutReport talonLoadoutReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <param name="talonCustomizationReport"></param>
        /// <param name="talonLoadoutReport"></param>
        private TalonConstructionReport(TalonCallSign talonCallSign,
            ITalonCustomizationReport talonCustomizationReport, ITalonLoadoutReport talonLoadoutReport)
        {
            this.talonCallSign = talonCallSign;
            this.talonCustomizationReport = talonCustomizationReport;
            this.talonLoadoutReport = talonLoadoutReport;
        }

        /// <inheritdoc/>
        ITalonCustomizationReport ITalonConstructionReport.GetTalonCustomizationReport()
        {
            return this.talonCustomizationReport;
        }

        /// <inheritdoc/>

        TalonCallSign ITalonConstructionReport.GetTalonCallSign()
        {
            return this.talonCallSign;
        }

        /// <inheritdoc/>
        ITalonLoadoutReport ITalonConstructionReport.GetTalonLoadoutReport()
        {
            return this.talonLoadoutReport;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}={2}" +
                "\n\t>{3}" +
                "\n\t>{4}",
                this.GetType().Name, typeof(TalonCallSign).Name, this.talonCallSign,
                this.talonCustomizationReport, this.talonLoadoutReport); ;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private TalonCallSign talonCallSign = TalonCallSign.None;

            // Todo
            private ITalonCustomizationReport talonCustomizationReport = null;

            // Todo
            private ITalonLoadoutReport talonLoadoutReport = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ITalonConstructionReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new TalonConstructionReport(this.talonCallSign,
                        this.talonCustomizationReport, this.talonLoadoutReport);
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
            /// <param name="talonCustomizationReport"></param>
            /// <returns></returns>
            public Builder SetTalonCustomizationReport(ITalonCustomizationReport talonCustomizationReport)
            {
                this.talonCustomizationReport = talonCustomizationReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonLoadoutReport"></param>
            /// <returns></returns>
            public Builder SetTalonLoadoutReport(ITalonLoadoutReport talonLoadoutReport)
            {
                this.talonLoadoutReport = talonLoadoutReport;
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
                    argumentExceptionSet.Add(typeof(TalonCallSign).Name + " cannot be none.");
                }
                // Check that customizationReport has been set
                if (this.talonCustomizationReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonCustomizationReport).Name + " cannot be null.");
                }
                // Check that talonLoadoutReport has been set
                if (this.talonLoadoutReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonLoadoutReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}