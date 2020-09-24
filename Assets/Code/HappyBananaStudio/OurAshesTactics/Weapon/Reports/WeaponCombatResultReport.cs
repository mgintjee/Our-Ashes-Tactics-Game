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
    public class WeaponCombatResultReport
    {
        #region Private Fields

        // Todo
        private readonly int damageDealt = int.MinValue;

        // Todo
        private readonly int damageMitigated = int.MinValue;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="damageDealt">    </param>
        /// <param name="damageMitigated"></param>
        private WeaponCombatResultReport(int damageDealt, int damageMitigated)
        {
            this.damageDealt = damageDealt;
            this.damageMitigated = damageMitigated;
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetDamageDealt()
        {
            return this.damageDealt;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetDamageMitigated()
        {
            return this.damageMitigated;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType() + ": " +
                "damageDealt=" + this.GetDamageDealt() +
                ", damageMitigated=" + this.GetDamageMitigated();
        }

        #endregion Public Methods

        #region Public Classes

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            #region Private Fields

            // Todo
            private int damageDealt = int.MinValue;

            // Todo
            private int damageMitigated = int.MinValue;

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public WeaponCombatResultReport Build()
            {
                HashSet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new WeaponCombatResultReport(this.damageDealt, this.damageMitigated);
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
            /// <param name="damageDealt"></param>
            /// <returns></returns>
            public Builder SetDamageDealt(int damageDealt)
            {
                this.damageDealt = damageDealt;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="damageMitigated"></param>
            /// <returns></returns>
            public Builder SetDamageMitigated(int damageMitigated)
            {
                this.damageMitigated = damageMitigated;
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
                // Check that damageDealt has been set
                if (this.damageDealt < 0)
                {
                    argumentExceptionSet.Add("damagePerShot=" + this.damageDealt + " is not valid");
                }
                // Check that damageMitigated has been set
                if (this.damageMitigated < 0)
                {
                    argumentExceptionSet.Add("damageMitigated=" + this.damageMitigated + " is not valid");
                }
                return argumentExceptionSet;
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}