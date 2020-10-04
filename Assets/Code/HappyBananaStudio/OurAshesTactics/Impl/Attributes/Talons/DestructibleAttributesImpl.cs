/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Attributes.Talons
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct DestructibleAttributesImpl
        : IDestructibleAttributes
    {
        // Todo
        private readonly int armorPoints;

        // Todo
        private readonly int healthPoints;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armorPoints">
        /// </param>
        /// <param name="healthPoints">
        /// </param>
        private DestructibleAttributesImpl(int armorPoints, int healthPoints)
        {
            this.armorPoints = armorPoints;
            this.healthPoints = healthPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="destructibleAttributeCollection">
        /// </param>
        private DestructibleAttributesImpl(ICollection<IDestructibleAttributes> destructibleAttributeCollection)
        {
            int armorPoints = 0;
            int healthPoints = 0;
            foreach (IDestructibleAttributes destructibleAttributes in destructibleAttributeCollection)
            {
                if (destructibleAttributes != null)
                {
                    armorPoints += destructibleAttributes.GetArmorPoints();
                    healthPoints += destructibleAttributes.GetHealthPoints();
                }
            }
            this.armorPoints = armorPoints;
            this.healthPoints = healthPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetArmorPoints()
        {
            return this.armorPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetHealthPoints()
        {
            return this.healthPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ": armorPoints = " + this.GetArmorPoints() +
                ", healthPoints = " + this.GetHealthPoints();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private int armorPoints;

            // Todo
            private ICollection<IDestructibleAttributes> destructibleAttributesCollection = null;

            // Todo
            private int healthPoints;

            // Todo
            private bool setArmorPoints = false;

            // Todo
            private bool setHealthPoints = false;

            /// <summary>
            /// Build the DestructableAttributes with the set parameters
            /// </summary>
            /// <returns>
            /// The IDestructibleAttributes
            /// </returns>
            public IDestructibleAttributes Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    if (this.destructibleAttributesCollection != null)
                    {
                        // Instantiate a new Report
                        return new DestructibleAttributesImpl(this.destructibleAttributesCollection);
                    }
                    else
                    {
                        // Instantiate a new Report
                        return new DestructibleAttributesImpl(this.armorPoints, this.healthPoints);
                    }
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the armorPoints
            /// </summary>
            /// <param name="armorPoints">
            /// The armorPoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetArmourPoints(int armorPoints)
            {
                this.armorPoints = armorPoints;
                this.setArmorPoints = true;
                return this;
            }

            /// <summary>
            /// Set the value of the Collection: DestructibleAttributes
            /// </summary>
            /// <param name="destructibleAttributesCollection">
            /// The Collection: DestructibleAttributes to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetDestrucibleAttributesCollection(ICollection<IDestructibleAttributes> destructibleAttributesCollection)
            {
                this.destructibleAttributesCollection = destructibleAttributesCollection;
                return this;
            }

            /// <summary>
            /// Set the value of the healthPoints
            /// </summary>
            /// <param name="healthPoints">
            /// The healthPoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetHealthPoints(int healthPoints)
            {
                this.healthPoints = healthPoints;
                this.setHealthPoints = true;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private HashSet<string> IsInvalid()
            {
                // Default an empty Set: String
                HashSet<string> argumentExceptionSet = new HashSet<string>();
                // Check if the destructibleAttributesCollection has been set
                if (this.destructibleAttributesCollection == null)
                {
                    // Check that armorPoints has been set
                    if (!this.setArmorPoints)
                    {
                        argumentExceptionSet.Add("armorPoints has not been set");
                    }
                    // Check that healthPoints has been set
                    if (!this.setHealthPoints)
                    {
                        argumentExceptionSet.Add("healthPoints  mhas not been set");
                    }
                }
                else
                {
                    // Check if the destructibleAttributesCollection is valid
                    if (this.destructibleAttributesCollection.Count == 0)
                    {
                        argumentExceptionSet.Add("Collection: " + typeof(IDestructibleAttributes) + " is empty.");
                    }
                }
                return argumentExceptionSet;
            }
        }
    }
}