namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Attributes.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Attributes.Reports.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonAttributesReport
        : ITalonAttributesReport
    {
        // Todo
        private readonly float actionPoints;

        // Todo
        private readonly float armorPoints;

        // Todo
        private readonly float healthPoints;

        // Todo
        private readonly float movementPoints;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="actionPoints"></param>
        /// <param name="armorPoints"></param>
        /// <param name="healthPoints"></param>
        /// <param name="movementPoints"></param>
        private TalonAttributesReport(float actionPoints, float armorPoints, float healthPoints, float movementPoints)
        {
            this.actionPoints = actionPoints;
            this.armorPoints = armorPoints;
            this.healthPoints = healthPoints;
            this.movementPoints = movementPoints;
        }

        /// <inheritdoc/>
        float ITalonAttributesReport.GetActionPoints()
        {
            return this.actionPoints;
        }

        /// <inheritdoc/>
        float ITalonAttributesReport.GetArmorPoints()
        {
            return this.armorPoints;
        }

        /// <inheritdoc/>
        float ITalonAttributesReport.GetHealthPoints()
        {
            return this.healthPoints;
        }

        /// <inheritdoc/>
        float ITalonAttributesReport.GetMovementPoints()
        {
            return this.movementPoints;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: actionPoints={1}, armorPoints={2}, healthPoints={3}, movementPoints={4}",
                this.GetType().Name, this.actionPoints, this.armorPoints, this.healthPoints, this.movementPoints);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private float actionPoints = float.MinValue;

            // Todo
            private float armorPoints = float.MinValue;

            // Todo
            private float healthPoints = float.MinValue;

            // Todo
            private float movementPoints = float.MinValue;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ITalonAttributesReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new TalonAttributesReport(this.actionPoints,
                        this.armorPoints, this.healthPoints, this.movementPoints);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="actionPoints"></param>
            /// <returns></returns>
            public Builder SetActionPoints(float actionPoints)
            {
                this.actionPoints = actionPoints;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="armorPoints"></param>
            /// <returns></returns>
            public Builder SetArmorPoints(float armorPoints)
            {
                this.armorPoints = armorPoints;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="healthPoints"></param>
            /// <returns></returns>
            public Builder SetHealthPoints(float healthPoints)
            {
                this.healthPoints = healthPoints;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="movementPoints"></param>
            /// <returns></returns>
            public Builder SetMovementPoints(float movementPoints)
            {
                this.movementPoints = movementPoints;
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
                // Check that actionPoints has been set
                if (this.actionPoints == float.MinValue)
                {
                    argumentExceptionSet.Add("actionPoints has not been set");
                }
                // Check that armorPoints has been set
                if (this.armorPoints == float.MinValue)
                {
                    argumentExceptionSet.Add("armorPoints has not been set");
                }
                // Check that healthPoints has been set
                if (this.healthPoints == float.MinValue)
                {
                    argumentExceptionSet.Add("healthPoints has not been set");
                }
                // Check that movementPoints has been set
                if (this.movementPoints == float.MinValue)
                {
                    argumentExceptionSet.Add("movementPoints has not been set");
                }

                return argumentExceptionSet;
            }
        }
    }
}