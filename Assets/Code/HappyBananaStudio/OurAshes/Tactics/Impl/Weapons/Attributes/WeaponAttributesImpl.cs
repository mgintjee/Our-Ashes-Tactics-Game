/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.Weapons.Attributes;
using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Impl.Attributes.Weapons
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct WeaponAttributesImpl
        : IWeaponAttributes
    {
        // Todo
        private readonly int accuracyPoints;

        // Todo
        private readonly int damagePoints;

        // Todo
        private readonly int numberOfShots;

        // Todo
        private readonly int penetrationPoints;

        // Todo
        private readonly int rangePoints;

        /// <summary> Todo </summary> <param name="accuracyPoints"> </param> <param
        /// name="damagePoints"> </param> <param name="numberOfShots"> </param> <param
        /// name="penetrationPoints"> </param> <param name="rangePoints">
        private WeaponAttributesImpl(int accuracyPoints, int damagePoints,
            int numberOfShots, int penetrationPoints,
            int rangePoints)
        {
            this.accuracyPoints = accuracyPoints;
            this.damagePoints = damagePoints;
            this.numberOfShots = numberOfShots;
            this.penetrationPoints = penetrationPoints;
            this.rangePoints = rangePoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponAttributesCollection">
        /// </param>
        private WeaponAttributesImpl(ICollection<IWeaponAttributes> weaponAttributesCollection)
        {
            int accuracyPoints = 0;
            int damagePoints = 0;
            int numberOfShots = 0;
            int penetrationPoints = 0;
            int rangePoints = 0;

            foreach (IWeaponAttributes weaponAttributes in weaponAttributesCollection)
            {
                accuracyPoints += weaponAttributes.GetAccuracyPoints();
                damagePoints += weaponAttributes.GetDamagePoints();
                numberOfShots += weaponAttributes.GetNumberOfShots();
                penetrationPoints += weaponAttributes.GetPenetrationPoints();
                rangePoints += weaponAttributes.GetMaxRangePoints();
            }

            this.accuracyPoints = accuracyPoints;
            this.damagePoints = damagePoints;
            this.numberOfShots = numberOfShots;
            this.penetrationPoints = penetrationPoints;
            this.rangePoints = rangePoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetAccuracyPoints()
        {
            return this.accuracyPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetDamagePoints()
        {
            return this.damagePoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetMaxRangePoints()
        {
            return this.rangePoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetNumberOfShots()
        {
            return this.numberOfShots;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetPenetrationPoints()
        {
            return this.penetrationPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                " accuracyPoints = " + this.GetAccuracyPoints() +
                ", damagePoints = " + this.GetDamagePoints() +
                ", numberOfShots = " + this.GetNumberOfShots() +
                ", penetrationPoints = " + this.GetPenetrationPoints() +
                ", rangePoints = " + this.GetMaxRangePoints();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private int accuracyPoints;

            // Todo
            private int damagePoints;

            // Todo
            private int numberOfShots;

            // Todo
            private int penetrationPoints;

            // Todo
            private int rangePoints;

            // Todo
            private int rangeProximityPoints;

            // Todo
            private bool setAccuracyPoints = false;

            // Todo
            private bool setDamagePoints = false;

            // Todo
            private bool setNumberOfShots = false;

            // Todo
            private bool setPenetrationPoints = false;

            // Todo
            private bool setRangePoints = false;

            // Todo
            private ICollection<IWeaponAttributes> weaponAttributesCollection = null;

            /// <summary>
            /// Build the WeaponAttributes with the set parameters
            /// </summary>
            /// <returns>
            /// The IWeaponAttributes
            /// </returns>
            public IWeaponAttributes Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    if (this.weaponAttributesCollection != null)
                    {
                        // Instantiate a new Report
                        return new WeaponAttributesImpl(this.weaponAttributesCollection);
                    }
                    else
                    {
                        // Instantiate a new Report
                        return new WeaponAttributesImpl(this.accuracyPoints, this.damagePoints,
                            this.numberOfShots, this.penetrationPoints,
                            this.rangePoints);
                    }
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the accuracyPoints
            /// </summary>
            /// <param name="accuracyPoints">
            /// The accuracyPoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetAccuracyPoints(int accuracyPoints)
            {
                this.accuracyPoints = accuracyPoints;
                this.setAccuracyPoints = true;
                return this;
            }

            /// <summary>
            /// Set the value of the damagePoints
            /// </summary>
            /// <param name="damagePoints">
            /// The damagePoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetDamagePoints(int damagePoints)
            {
                this.damagePoints = damagePoints;
                this.setDamagePoints = true;
                return this;
            }

            /// <summary>
            /// Set the value of the numberOfShots
            /// </summary>
            /// <param name="numberOfShots">
            /// The numberOfShots to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetNumberOfShots(int numberOfShots)
            {
                this.numberOfShots = numberOfShots;
                this.setNumberOfShots = true;
                return this;
            }

            /// <summary>
            /// Set the value of the penetrationPoints
            /// </summary>
            /// <param name="penetrationPoints">
            /// The penetrationPoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetPenetrationPoints(int penetrationPoints)
            {
                this.penetrationPoints = penetrationPoints;
                this.setPenetrationPoints = true;
                return this;
            }

            /// <summary>
            /// Set the value of the rangePoints
            /// </summary>
            /// <param name="rangePoints">
            /// The rangePoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetRangePoints(int rangePoints)
            {
                this.rangePoints = rangePoints;
                this.setRangePoints = true;
                return this;
            }

            /// <summary>
            /// Set the value of the Collection: IWeaponAttributes
            /// </summary>
            /// <param name="weaponAttributesCollection">
            /// The Collection: IWeaponAttributes to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetWeaponAttributesCollection(ICollection<IWeaponAttributes> weaponAttributesCollection)
            {
                this.weaponAttributesCollection = weaponAttributesCollection;
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
                // Check if the weaponAttributesCollection has been set
                if (this.weaponAttributesCollection == null)
                {
                    // Check that accuracyPoints has been set
                    if (!this.setAccuracyPoints)
                    {
                        argumentExceptionSet.Add("accuracyPoints has not been set");
                    }
                    // Check that damagePoints has been set
                    if (!this.setDamagePoints)
                    {
                        argumentExceptionSet.Add("damagePoints has not been set");
                    }
                    // Check that numberOfShots has been set
                    if (!this.setNumberOfShots)
                    {
                        argumentExceptionSet.Add("numberOfShots has not been set");
                    }
                    // Check that penetrationPoints has been set
                    if (!this.setPenetrationPoints)
                    {
                        argumentExceptionSet.Add("penetrationPoints has not been set");
                    }
                    // Check that rangePoints has been set
                    if (!this.setRangePoints)
                    {
                        argumentExceptionSet.Add("rangePoints has not been set");
                    }
                }
                else
                {
                    // Check if the weaponAttributesCollection is valid
                    if (this.weaponAttributesCollection.Count == 0)
                    {
                        argumentExceptionSet.Add("Collection: " + typeof(IWeaponAttributes) + " is empty.");
                    }
                }
                return argumentExceptionSet;
            }
        }
    }
}
