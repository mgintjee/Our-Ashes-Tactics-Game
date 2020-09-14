/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Enums;
using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports
{
    /// <summary>
    /// Report to display the construction information for a specific Talon
    /// </summary>
    public class TalonConstructionReport
    {
        #region Private Fields

        // Todo
        private readonly TalonIdentificationReport talonIdentificationReport = null;
        // Todo
        private readonly TalonPaintSchemeReport talonPaintSchemeReport = null;
        // Todo
        private readonly List<WeaponIdEnum> weaponIdList = null;

        #endregion Private Fields

        #region Private Constructors
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport"></param>
        /// <param name="talonPaintSchemeReport"></param>
        /// <param name="weaponIdList"></param>
        private TalonConstructionReport(TalonIdentificationReport talonIdentificationReport,
            TalonPaintSchemeReport talonPaintSchemeReport, List<WeaponIdEnum> weaponIdList)
        {
            this.talonIdentificationReport = talonIdentificationReport;
            this.talonPaintSchemeReport = talonPaintSchemeReport;
            this.weaponIdList = weaponIdList;
        }

        #endregion Private Constructors

        #region Public Methods
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonIdentificationReport GetTalonIdentificationReport()
        {
            return this.talonIdentificationReport;
        }
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonPaintSchemeReport GetTalonPaintSchemeReport()
        {
            return this.talonPaintSchemeReport;
        }
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public List<WeaponIdEnum> GetWeaponIdList()
        {
            return new List<WeaponIdEnum>(this.weaponIdList);
        }
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType() + ": " +
                "\n\t>" + this.GetTalonIdentificationReport() +
                "\n\t>" + this.GetTalonPaintSchemeReport() +
                "\n\t>weaponIdList=[" + string.Join(",", this.GetWeaponIdList()) + "]";
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
            private TalonIdentificationReport talonIdentificationReport = null;
            // Todo
            private TalonPaintSchemeReport talonPaintSchemeReport = null;
            // Todo
            private List<WeaponIdEnum> weaponIdList = null;

            #endregion Private Fields

            #region Public Methods
            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public TalonConstructionReport Build()
            {
                HashSet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonConstructionReport(this.talonIdentificationReport, this.talonPaintSchemeReport, this.weaponIdList);
                }
                else
                {
                    throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                        string.Join("\n", invalidReasons));
                }
            }
            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonIdentificationReport"></param>
            /// <returns></returns>
            public Builder SetTalonIdentificationReport(TalonIdentificationReport talonIdentificationReport)
            {
                this.talonIdentificationReport = talonIdentificationReport;
                return this;
            }
            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonPaintSchemeReport"></param>
            /// <returns></returns>
            public Builder SetTalonPaintSchemeReport(TalonPaintSchemeReport talonPaintSchemeReport)
            {
                this.talonPaintSchemeReport = talonPaintSchemeReport;
                return this;
            }
            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="weaponIdList"></param>
            /// <returns></returns>
            public Builder SetWeaponIdList(List<WeaponIdEnum> weaponIdList)
            {
                this.weaponIdList = new List<WeaponIdEnum>(weaponIdList);
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
                // Check that talonIdentificationReport has been set
                if (this.talonIdentificationReport == null)
                {
                    argumentExceptionSet.Add(typeof(TalonIdentificationReport) + " has not been set");
                }
                // Check that talonPaintSchemeReport has been set
                if (this.talonPaintSchemeReport == null)
                {
                    argumentExceptionSet.Add(typeof(TalonPaintSchemeReport) + " has not been set");
                }
                // Check that weaponIdList has been set
                if (this.weaponIdList == null)
                {
                    argumentExceptionSet.Add("weaponIdList has not been set");
                }
                return argumentExceptionSet;
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}