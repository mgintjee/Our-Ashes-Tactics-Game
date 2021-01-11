namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Reports.Api;
    using HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonReportImpl
        : ITalonReport
    {
        // Todo
        private readonly TalonCallSign talonCallSign;

        // Todo
        private readonly float currentActionPoints;

        // Todo
        private readonly float currentArmorPoints;

        // Todo
        private readonly float currentHealthPoints;

        // Todo
        private readonly float currentMovementPoints;

        // Todo
        private readonly ITalonLoadoutReport talonLoadoutReport;

        // Todo
        private readonly ICustomizationReport customizationReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <param name="currentActionPoints"></param>
        /// <param name="currentArmorPoints"></param>
        /// <param name="currentHealthPoints"></param>
        /// <param name="currentMovementPoints"></param>
        /// <param name="talonLoadoutReport"></param>
        private TalonReportImpl(TalonCallSign talonCallSign, float currentActionPoints,
            float currentArmorPoints, float currentHealthPoints, float currentMovementPoints,
            ITalonLoadoutReport talonLoadoutReport, ICustomizationReport customizationReport)
        {
            this.talonCallSign = talonCallSign;
            this.currentActionPoints = currentActionPoints;
            this.currentArmorPoints = currentArmorPoints;
            this.currentHealthPoints = currentHealthPoints;
            this.currentMovementPoints = currentMovementPoints;
            this.talonLoadoutReport = talonLoadoutReport;
            this.customizationReport = customizationReport;
        }

        /// <inheritdoc/>
        TalonCallSign ITalonReport.GetTalonCallSign()
        {
            return this.talonCallSign;
        }

        /// <inheritdoc/>
        float ITalonReport.GetCurrentActionPoints()
        {
            return this.currentActionPoints;
        }

        /// <inheritdoc/>
        float ITalonReport.GetCurrentArmorPoints()
        {
            return this.currentArmorPoints;
        }

        /// <inheritdoc/>
        float ITalonReport.GetCurrentHealthPoints()
        {
            return this.currentHealthPoints;
        }

        /// <inheritdoc/>
        float ITalonReport.GetCurrentMovementPoints()
        {
            return this.currentMovementPoints;
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

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private TalonCallSign talonCallSign = TalonCallSign.None;

            // Todo
            private float currentActionPoints = float.MinValue;

            // Todo
            private float currentArmorPoints = float.MinValue;

            // Todo
            private float currentHealthPoints = float.MinValue;

            // Todo
            private float currentMovementPoints = float.MinValue;

            // Todo
            private ITalonLoadoutReport talonLoadoutReport = null;

            // Todo
            private ICustomizationReport customizationReport = null;

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
                    return new TalonReportImpl(this.talonCallSign, this.currentActionPoints,
                        this.currentArmorPoints, this.currentHealthPoints, this.currentMovementPoints,
                        this.talonLoadoutReport, this.customizationReport);
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. ?",
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
            /// <param name="currentActionPoints"></param>
            /// <returns></returns>
            public Builder SetCurrentActionPoints(float currentActionPoints)
            {
                this.currentActionPoints = currentActionPoints;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="currentArmorPoints"></param>
            /// <returns></returns>
            public Builder SetCurrentArmorPoints(float currentArmorPoints)
            {
                this.currentArmorPoints = currentArmorPoints;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="currentHealthPoints"></param>
            /// <returns></returns>
            public Builder SetCurrentHealthPoints(float currentHealthPoints)
            {
                this.currentHealthPoints = currentHealthPoints;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="currentMovementPoints"></param>
            /// <returns></returns>
            public Builder SetCurrentMovementPoints(float currentMovementPoints)
            {
                this.currentMovementPoints = currentMovementPoints;
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
                // Check that currentActionPoints has been set
                if (this.currentActionPoints == float.MinValue)
                {
                    argumentExceptionSet.Add("Current action points has not been set");
                }
                // Check that currentArmorPoints has been set
                if (this.currentArmorPoints == float.MinValue)
                {
                    argumentExceptionSet.Add("Current armor points has not been set");
                }
                // Check that currentHealthPoints has been set
                if (this.currentHealthPoints == float.MinValue)
                {
                    argumentExceptionSet.Add("Current health points has not been set");
                }
                // Check that currentMovementPoints has been set
                if (this.currentMovementPoints == float.MinValue)
                {
                    argumentExceptionSet.Add("Current movement points has not been set");
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