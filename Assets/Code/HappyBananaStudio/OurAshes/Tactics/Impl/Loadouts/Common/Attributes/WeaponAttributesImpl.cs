namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Impl.Loadouts.Common.Attributes
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Common.Attributes;

    /// <summary>
    /// Todo
    /// </summary>
    public struct WeaponAttributesImpl
        : IWeaponAttributes
    {
        // Todo
        private readonly float accuracyPoints;

        // Todo
        private readonly float armorDamagePoints;

        // Todo
        private readonly float armorPenetrationPoints;

        // Todo
        private readonly float healthDamagePoints;

        // Todo
        private readonly int maxRangePoints;

        // Todo
        private readonly int volleySize;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="accuracyPoints"></param>
        /// <param name="armorDamagePoints"></param>
        /// <param name="armorPenetrationPoints"></param>
        /// <param name="healthDamagePoints"></param>
        /// <param name="maxRangePoints"></param>
        /// <param name="volleySize"></param>
        private WeaponAttributesImpl(float accuracyPoints, float armorDamagePoints,
            float armorPenetrationPoints, float healthDamagePoints,
            int maxRangePoints, int volleySize)
        {
            this.accuracyPoints = accuracyPoints;
            this.armorDamagePoints = armorDamagePoints;
            this.armorPenetrationPoints = armorPenetrationPoints;
            this.healthDamagePoints = healthDamagePoints;
            this.maxRangePoints = maxRangePoints;
            this.volleySize = volleySize;
        }

        /// <inheritdoc/>
        float IWeaponAttributes.GetAccuracyPoints()
        {
            return this.accuracyPoints;
        }

        /// <inheritdoc/>
        float IWeaponAttributes.GetArmorDamagePoints()
        {
            return this.armorDamagePoints;
        }

        /// <inheritdoc/>
        float IWeaponAttributes.GetArmorPenetrationPoints()
        {
            return this.armorPenetrationPoints;
        }

        /// <inheritdoc/>
        float IWeaponAttributes.GetHealthDamagePoints()
        {
            return this.healthDamagePoints;
        }

        /// <inheritdoc/>
        int IWeaponAttributes.GetMaxRangePoints()
        {
            return this.maxRangePoints;
        }

        /// <inheritdoc/>
        int IWeaponAttributes.GetVolleySize()
        {
            return this.volleySize;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private float accuracyPoints = 0;

            // Todo
            private float armorDamagePoints = 0;

            // Todo
            private float armorPenetrationPoints = 0;

            // Todo
            private float healthDamagePoints = 0;

            // Todo
            private int maxRangePoints = 0;

            // Todo
            private int volleySize = 0;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IWeaponAttributes Build()
            {
                // Instantiate a new Report
                return new WeaponAttributesImpl(this.accuracyPoints, this.armorDamagePoints,
                    this.armorPenetrationPoints, this.healthDamagePoints,
                    this.maxRangePoints, this.volleySize);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="accuracyPoints"></param>
            public Builder SetAccuracyPoints(float accuracyPoints)
            {
                this.accuracyPoints = accuracyPoints;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="armorDamagePoints"></param>
            public Builder SetArmorDamagePoints(float armorDamagePoints)
            {
                this.armorDamagePoints = armorDamagePoints;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="armorPenetrationPoints"></param>
            public Builder SetArmorPenetrationPoints(float armorPenetrationPoints)
            {
                this.armorPenetrationPoints = armorPenetrationPoints;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="healthDamagePoints"></param>
            public Builder SetHealthDamagePoints(float healthDamagePoints)
            {
                this.healthDamagePoints = healthDamagePoints;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="maxRangePoints"></param>
            public Builder SetMaxRangePoints(int maxRangePoints)
            {
                this.maxRangePoints = maxRangePoints;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="volleySize"></param>
            public Builder SetVolleySize(int volleySize)
            {
                this.volleySize = volleySize;
                return this;
            }
        }
    }
}