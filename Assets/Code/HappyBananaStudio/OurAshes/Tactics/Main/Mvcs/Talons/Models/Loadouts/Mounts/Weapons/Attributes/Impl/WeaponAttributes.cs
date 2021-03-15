using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Weapons.Attributes.Api;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Weapons.Attributes.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct WeaponAttributes
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
        private WeaponAttributes(float accuracyPoints, float armorDamagePoints,
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

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: accuracyPoints={1}, armorDamagePoints={2}, " +
                "armorPenetrationPoints={3}, healthDamagePoints={4}, " +
                "maxRangePoints={5}, volleySize={6}",
                this.GetType().Name, this.accuracyPoints, this.armorDamagePoints,
                this.armorPenetrationPoints, this.healthDamagePoints, this.maxRangePoints, this.volleySize);
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
                return new WeaponAttributes(this.accuracyPoints, this.armorDamagePoints,
                    this.armorPenetrationPoints, this.healthDamagePoints,
                    this.maxRangePoints, this.volleySize);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IWeaponAttributes Build(ISet<IWeaponAttributes> weaponAttributesSet)
            {
                // Reset the value to 0
                this.accuracyPoints = 0;
                // Reset the value to 0
                this.armorDamagePoints = 0;
                // Reset the value to 0
                this.armorPenetrationPoints = 0;
                // Reset the value to 0
                this.healthDamagePoints = 0;
                // Reset the value to 0
                this.maxRangePoints = 0;
                // Reset the value to 0
                this.volleySize = 0;

                // Iterate over the other attributes
                foreach (IWeaponAttributes weaponAttributes in weaponAttributesSet)
                {
                    this.accuracyPoints += weaponAttributes.GetAccuracyPoints();
                    this.armorDamagePoints += weaponAttributes.GetArmorDamagePoints();
                    this.armorPenetrationPoints += weaponAttributes.GetArmorPenetrationPoints();
                    this.healthDamagePoints += weaponAttributes.GetHealthDamagePoints();
                    this.maxRangePoints += weaponAttributes.GetMaxRangePoints();
                    this.volleySize += weaponAttributes.GetVolleySize();
                }
                // Instantiate a new Report
                return new WeaponAttributes(this.accuracyPoints, this.armorDamagePoints,
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