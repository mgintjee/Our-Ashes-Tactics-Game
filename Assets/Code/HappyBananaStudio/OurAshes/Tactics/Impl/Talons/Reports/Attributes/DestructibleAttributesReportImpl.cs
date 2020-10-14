
namespace HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Attributes
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct DestructibleAttributesReportImpl
        : IDestructibleAttributesReport
    {
        // Todo
        private readonly int currentArmorPoints;

        // Todo
        private readonly int currentHealthPoints;

        // Todo
        private readonly int maximumArmorPoints;

        // Todo
        private readonly int maximumHealthPoints;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="currentArmorPoints">
        /// </param>
        /// <param name="currentHealthPoints">
        /// </param>
        /// <param name="maximumArmorPoints">
        /// </param>
        /// <param name="maximumHealthPoints">
        /// </param>
        private DestructibleAttributesReportImpl(int currentArmorPoints, int currentHealthPoints,
            int maximumArmorPoints, int maximumHealthPoints)
        {
            // Set the current attributes for this report
            this.currentArmorPoints = currentArmorPoints;
            this.currentHealthPoints = currentHealthPoints;
            // Set the maximum attributes for this report
            this.maximumArmorPoints = maximumArmorPoints;
            this.maximumHealthPoints = maximumHealthPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>Current ArmorPoints=" + this.currentArmorPoints +
                "\n\t>Current HealthPoints=" + this.currentHealthPoints +
                "\n\t>Maximum ArmorPoints=" + this.maximumArmorPoints +
                "\n\t>Maximum HealthPoints=" + this.maximumHealthPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int IDestructibleAttributesReport.GetCurrentArmorPoints()
        {
            return this.currentArmorPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int IDestructibleAttributesReport.GetCurrentHealthPoints()
        {
            return this.currentHealthPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int IDestructibleAttributesReport.GetMaximumArmorPoints()
        {
            return this.maximumArmorPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int IDestructibleAttributesReport.GetMaximumHealthPoints()
        {
            return this.maximumHealthPoints;
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // The current ArmorPoints for the Destructible
            private int currentArmorPoints = int.MinValue;

            // The current HealthPoints for the Destructible
            private int currentHealthPoints = int.MinValue;

            // The maximum ArmourPoints for the Destructible
            private int maximumArmorPoints = int.MinValue;

            // The maximum HealthPoints for the Destructible
            private int maximumHealthPoints = int.MinValue;

            // Tracks whether current ArmorPoints has been set
            private bool setCurrentArmorPoints = false;

            // Tracks whether current HealthPoints has been set
            private bool setCurrentHealthPoints = false;

            // Tracks whether maximum ArmorPoints has been set
            private bool setMaximumArmorPoints = false;

            // Tracks whether maximum HealthPoints has been set
            private bool setMaximumHealthPoints = false;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public IDestructibleAttributesReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new DestructibleAttributesReportImpl(
                        this.currentArmorPoints, this.currentHealthPoints,
                        this.maximumArmorPoints, this.maximumHealthPoints);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the Current armourPoints
            /// </summary>
            /// <param name="currentArmourPoints">
            /// The Current armourPoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetCurrentArmourPoints(int currentArmourPoints)
            {
                this.currentArmorPoints = currentArmourPoints;
                this.setCurrentArmorPoints = true;
                return this;
            }

            /// <summary>
            /// Set the value of the Current healthPoints
            /// </summary>
            /// <param name="currentHealthPoints">
            /// The Current healthPoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetCurrentHealthPoints(int currentHealthPoints)
            {
                this.currentHealthPoints = currentHealthPoints;
                this.setCurrentHealthPoints = true;
                return this;
            }

            /// <summary>
            /// Set the value of the Maximum armourPoints
            /// </summary>
            /// <param name="maximumArmourPoints">
            /// The Maximum armourPoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetMaximumArmourPoints(int maximumArmourPoints)
            {
                this.maximumArmorPoints = maximumArmourPoints;
                this.setMaximumArmorPoints = true;
                return this;
            }

            /// <summary>
            /// Set the value of the Maximum healthPoints
            /// </summary>
            /// <param name="maximumHealthPoints">
            /// The Maximum healthPoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetMaximumHealthPoints(int maximumHealthPoints)
            {
                this.maximumHealthPoints = maximumHealthPoints;
                this.setMaximumHealthPoints = true;
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
                // Check that currentArmourPoints has been set
                if (!this.setCurrentArmorPoints)
                {
                    argumentExceptionSet.Add("currentArmourPoints has not been set");
                }
                // Check that currentHealthPoints has been set
                if (!this.setCurrentHealthPoints)
                {
                    argumentExceptionSet.Add("currentHealthPoints has not been set");
                }
                // Check thatmaximumArmourPoints has been set
                if (!this.setMaximumArmorPoints)
                {
                    argumentExceptionSet.Add("maximumArmourPoints has not been set");
                }
                // Check that maximumHealthPoints has been set
                if (!this.setMaximumHealthPoints)
                {
                    argumentExceptionSet.Add("maximumHealthPoints has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
