/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Enums;
using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Reports
{
    /// <summary>
    /// Todo
    /// </summary>
    public class WeaponConstructionReport
    {
        #region Private Fields

        // Todo
        private readonly TalonPaintSchemeReport paintSchemeReport;

        // Todo
        private readonly WeaponIdEnum weaponId;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponId">         </param>
        /// <param name="paintSchemeReport"></param>
        private WeaponConstructionReport(WeaponIdEnum weaponId, TalonPaintSchemeReport paintSchemeReport)
        {
            this.weaponId = weaponId;
            this.paintSchemeReport = paintSchemeReport;
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonPaintSchemeReport GetPaintSchemeReport()
        {
            return this.paintSchemeReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public WeaponIdEnum GetWeaponId()
        {
            return this.weaponId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType() + ":" +
                "\n " + typeof(WeaponIdEnum) + "=" + this.GetWeaponId() +
                "\n" + this.GetPaintSchemeReport();
        }

        #endregion Public Methods

        #region Public Classes

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            #region Private Fields

            private TalonPaintSchemeReport paintSchemeReport = null;
            private WeaponIdEnum weaponId = WeaponIdEnum.NULL;

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public WeaponConstructionReport Build()
            {
                HashSet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new WeaponConstructionReport(this.weaponId, this.paintSchemeReport);
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
            /// <param name="paintSchemeReport"></param>
            /// <returns></returns>
            public Builder SetPaintSchemeReport(TalonPaintSchemeReport paintSchemeReport)
            {
                this.paintSchemeReport = paintSchemeReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="weaponId"></param>
            /// <returns></returns>
            public Builder SetWeaponId(WeaponIdEnum weaponId)
            {
                this.weaponId = weaponId;
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
                // Check that paintSchemeReport has been set
                if (this.paintSchemeReport == null)
                {
                    argumentExceptionSet.Add(typeof(TalonPaintSchemeReport) + " has not been set");
                }
                // Check that weaponId has been set
                if (this.weaponId.Equals(WeaponIdEnum.NULL))
                {
                    argumentExceptionSet.Add(typeof(WeaponIdEnum) + "= " + this.weaponId + " is not valid");
                }
                return argumentExceptionSet;
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}