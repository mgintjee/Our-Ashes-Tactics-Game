using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Armors.Attributes.Api;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Armors.Attributes.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct ArmorAttributes
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
        private ArmorAttributes(float armorPoints, float healthPoints)
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

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: armorPoints={1}, healthPoints={2}",
                this.GetType().Name, this.armorPoints, this.healthPoints);
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
                return new ArmorAttributes(this.armorPoints, this.healthPoints);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="armorAttributesSet"></param>
            /// <returns></returns>
            public IArmorAttributes Build(ISet<IArmorAttributes> armorAttributesSet)
            {
                // Reset the value to 0
                this.armorPoints = 0;
                // Reset the value to 0
                this.healthPoints = 0;
                // Iterate over the other attributes
                foreach (IArmorAttributes armorAttributes in armorAttributesSet)
                {
                    this.armorPoints += armorAttributes.GetArmorPoints();
                    this.healthPoints += armorAttributes.GetHealthPoints();
                }

                // Instantiate a new Report
                return new ArmorAttributes(this.armorPoints, this.healthPoints);
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