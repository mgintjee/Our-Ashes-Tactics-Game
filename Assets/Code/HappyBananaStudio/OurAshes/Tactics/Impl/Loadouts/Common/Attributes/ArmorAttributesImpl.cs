namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Impl.Loadouts.Common.Attributes
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Common.Attributes;

    /// <summary>
    /// Todo
    /// </summary>
    public struct ArmorAttributesImpl
        : IArmorAttributes
    {
        // Todo
        private readonly float armorPoints;

        // Todo
        private readonly float healthPoints;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armorPoints"></param>
        /// <param name="healthPoints"></param>
        private ArmorAttributesImpl(float armorPoints, float healthPoints)
        {
            this.armorPoints = armorPoints;
            this.healthPoints = healthPoints;
        }

        /// <inheritdoc/>
        float IArmorAttributes.GetArmorPoints()
        {
            return this.armorPoints;
        }

        /// <inheritdoc/>
        float IArmorAttributes.GetHealthPoints()
        {
            return this.healthPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private float armorPoints = 0;

            // Todo
            private float healthPoints = 0;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IArmorAttributes Build()
            {
                // Instantiate a new Report
                return new ArmorAttributesImpl(this.armorPoints, this.healthPoints);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="armorPoints"></param>
            public Builder SetArmorPoints(float armorPoints)
            {
                this.armorPoints = armorPoints;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="healthPoints"></param>
            public Builder SetHealthPoints(float healthPoints)
            {
                this.healthPoints = healthPoints;
                return this;
            }
        }
    }
}