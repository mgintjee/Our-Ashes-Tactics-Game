namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Attributes.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Reports.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonReport
        : ITalonReport
    {
        // Todo
        private readonly TalonCallSign talonCallSign;

        // Todo
        private readonly ITalonAttributesReport currentTalonAttributesReport;

        // Todo
        private readonly ITalonAttributesReport maximumTalonAttributesReport;

        // Todo
        private readonly ITalonLoadoutReport talonLoadoutReport;

        // Todo
        private readonly ICustomizationReport customizationReport;

        // Todo
        private readonly ICubeCoordinates cubeCoordinates;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <param name="currentTalonAttributesReport"></param>
        /// <param name="maximumTalonAttributesReport"></param>
        /// <param name="cubeCoordinates"></param>
        /// <param name="talonLoadoutReport"></param>
        /// <param name="customizationReport"></param>
        private TalonReport(TalonCallSign talonCallSign, ITalonAttributesReport currentTalonAttributesReport,
            ITalonAttributesReport maximumTalonAttributesReport, ICubeCoordinates cubeCoordinates,
            ITalonLoadoutReport talonLoadoutReport, ICustomizationReport customizationReport)
        {
            this.talonCallSign = talonCallSign;
            this.currentTalonAttributesReport = currentTalonAttributesReport;
            this.maximumTalonAttributesReport = maximumTalonAttributesReport;
            this.cubeCoordinates = cubeCoordinates;
            this.talonLoadoutReport = talonLoadoutReport;
            this.customizationReport = customizationReport;
        }

        /// <inheritdoc/>
        TalonCallSign ITalonReport.GetTalonCallSign()
        {
            return this.talonCallSign;
        }

        /// <inheritdoc/>
        ITalonLoadoutReport ITalonReport.GetTalonLoadoutReport()
        {
            return this.talonLoadoutReport;
        }

        /// <inheritdoc/>
        ICustomizationReport ITalonReport.GetCustomizationReport()
        {
            return this.customizationReport;
        }

        /// <inheritdoc/>
        ICubeCoordinates ITalonReport.GetCubeCoordinates()
        {
            return this.cubeCoordinates;
        }

        /// <inheritdoc/>
        ITalonAttributesReport ITalonReport.GetCurrentTalonAttributesReport()
        {
            return this.currentTalonAttributesReport;
        }

        /// <inheritdoc/>
        ITalonAttributesReport ITalonReport.GetMaximumTalonAttributesReport()
        {
            return this.maximumTalonAttributesReport;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}={2}, {3} " +
                "\n\t>Current {4}, " +
                "\n\t>Maximum {5}, " +
                "\n\t>{6}" +
                "\n\t>{7}",
                this.GetType().Name, typeof(TalonCallSign).Name, this.talonCallSign,
                this.cubeCoordinates, this.currentTalonAttributesReport, this.maximumTalonAttributesReport,
                this.customizationReport, this.talonLoadoutReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private TalonCallSign talonCallSign = TalonCallSign.None;

            // Todo
            private ITalonAttributesReport currentTalonAttributesReport;

            // Todo
            private ITalonAttributesReport maximumTalonAttributesReport;

            // Todo
            private ITalonLoadoutReport talonLoadoutReport = null;

            // Todo
            private ICustomizationReport customizationReport = null;

            // Todo
            private ICubeCoordinates cubeCoordinates = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ITalonReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new TalonReport(this.talonCallSign, this.currentTalonAttributesReport,
                        this.maximumTalonAttributesReport, this.cubeCoordinates, this.talonLoadoutReport,
                        this.customizationReport);
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
            /// <param name="currentTalonAttributesReport"></param>
            /// <returns></returns>
            public Builder SetCurrentTalonAttributesReport(ITalonAttributesReport currentTalonAttributesReport)
            {
                this.currentTalonAttributesReport = currentTalonAttributesReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="maximumTalonAttributesReport"></param>
            /// <returns></returns>
            public Builder SetMaximumTalonAttributesReport(ITalonAttributesReport maximumTalonAttributesReport)
            {
                this.maximumTalonAttributesReport = maximumTalonAttributesReport;
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
            /// <param name="customizationReport"></param>
            /// <returns></returns>
            public Builder SetCustomizationReport(ICustomizationReport customizationReport)
            {
                this.customizationReport = customizationReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="cubeCoordinates"></param>
            /// <returns></returns>
            public Builder SetCubeCoordinates(ICubeCoordinates cubeCoordinates)
            {
                this.cubeCoordinates = cubeCoordinates;
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
                // Check that currentTalonAttributesReport has been set
                if (this.currentTalonAttributesReport == null)
                {
                    argumentExceptionSet.Add("Current " + typeof(ITalonAttributesReport).Name + " points has not been set");
                }
                // Check that maximumTalonAttributesReport has been set
                if (this.maximumTalonAttributesReport == null)
                {
                    argumentExceptionSet.Add("Maximum " + typeof(ITalonAttributesReport).Name + " points has not been set");
                }
                // Check that cubeCoordinates has been set
                if (this.cubeCoordinates == null)
                {
                    argumentExceptionSet.Add(typeof(ICubeCoordinates) + " has not been set");
                }
                // Check that talonLoadoutReport has been set
                if (this.talonLoadoutReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonLoadoutReport) + " has not been set");
                }
                // Check that customizationReport has been set
                if (this.customizationReport == null)
                {
                    argumentExceptionSet.Add(typeof(ICustomizationReport) + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}