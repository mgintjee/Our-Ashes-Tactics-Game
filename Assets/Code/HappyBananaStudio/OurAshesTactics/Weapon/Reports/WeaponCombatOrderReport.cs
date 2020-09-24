/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Reports
{
    /// <summary>
    /// Todo
    /// </summary>
    public class WeaponCombatOrderReport
    {
        #region Private Fields

        // Todo
        private readonly int damagePerShot = int.MinValue;

        // Todo
        private readonly int numberOfShots = int.MinValue;

        // Todo
        private readonly int penetration = int.MinValue;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Constructor method, to initialize this WeaponCombatReport
        /// </summary>
        /// <param name="numberOfShots">     The amount of shots from a weapon that hit</param>
        /// <param name="damagePerShot">     The amount of damage per shot</param>
        /// <param name="penetrationPerShot">The amount of armour ignored per shot</param>
        private WeaponCombatOrderReport(int damagePerShot, int numberOfShots, int penetrationPerShot)
        {
            this.damagePerShot = damagePerShot;
            this.numberOfShots = numberOfShots;
            this.penetration = penetrationPerShot;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Getter method, return the DamagePerShot
        /// </summary>
        /// <returns>Integer DamagePerShot</returns>
        public int GetDamagePerShot()
        {
            return this.damagePerShot;
        }

        /// <summary>
        /// Getter method, return the NumberOfShots
        /// </summary>
        /// <returns>Integer NumberOfShots</returns>
        public int GetNumberOfShots()
        {
            return this.numberOfShots;
        }

        /// <summary>
        /// Getter method, return the PenetrationPerShot
        /// </summary>
        /// <returns>Integer Penetration</returns>
        public int GetPenetration()
        {
            return this.penetration;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType().ToString() + ": " +
                "damagePerShot=" + this.GetDamagePerShot() +
                ", numberOfShots=" + this.GetNumberOfShots() +
                ", penetration=" + this.GetPenetration();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private int damagePerShot = int.MinValue;

            // Todo
            private int numberOfShots = int.MinValue;

            // Todo
            private int penetration = int.MinValue;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public WeaponCombatOrderReport Build()
            {
                HashSet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new WeaponCombatOrderReport(this.damagePerShot, this.numberOfShots, this.penetration);
                }
                else
                {
                    throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                        string.Join("\n\t>", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="damagePerShot"></param>
            /// <returns></returns>
            public Builder SetDamagePerShot(int damagePerShot)
            {
                this.damagePerShot = damagePerShot;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="numberOfShots"></param>
            /// <returns></returns>
            public Builder SetNumberOfShots(int numberOfShots)
            {
                this.numberOfShots = numberOfShots;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="penetration"></param>
            /// <returns></returns>
            public Builder SetPenetration(int penetration)
            {
                this.penetration = penetration;
                return this;
            }

            #endregion Public Methods

            #region Private Methods

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            private HashSet<string> IsValid()
            {
                // Default an empty Set: String
                HashSet<string> argumentExceptionSet = new HashSet<string>();
                // Check that damagePerShot has been set
                if (this.damagePerShot < 1)
                {
                    argumentExceptionSet.Add("damagePerShot=" + this.damagePerShot + " is not valid");
                }
                // Check that numberOfShots has been set
                if (this.numberOfShots < 0)
                {
                    argumentExceptionSet.Add("numberOfShots=" + this.numberOfShots + " is not valid");
                }
                // Check that penetration has been set
                if (this.penetration < 0)
                {
                    argumentExceptionSet.Add("penetration=" + this.penetration + " is not valid");
                }
                return argumentExceptionSet;
            }
        }

        #endregion Private Methods
    }
}