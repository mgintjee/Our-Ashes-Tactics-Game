/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Reports;
using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TalonCombatResultReport
    {
        #region Private Fields

        // Todo
        private readonly bool isTargetDestroyed = false;

        // Todo
        private readonly TalonCombatOrderReport talonCombatOrderReport = null;

        // Todo
        private readonly List<WeaponCombatResultReport> weaponCombatResultReportList = new List<WeaponCombatResultReport>();

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="isTargetDestroyed">           </param>
        /// <param name="talonCombatOrderReport">      </param>
        /// <param name="weaponCombatResultReportList"></param>
        private TalonCombatResultReport(bool isTargetDestroyed, TalonCombatOrderReport talonCombatOrderReport, List<WeaponCombatResultReport> weaponCombatResultReportList)
        {
            this.isTargetDestroyed = isTargetDestroyed;
            this.talonCombatOrderReport = talonCombatOrderReport;
            this.weaponCombatResultReportList = new List<WeaponCombatResultReport>(weaponCombatResultReportList);
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public bool GetIsTargetDestroyed()
        {
            return this.isTargetDestroyed;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonCombatOrderReport GetTalonCombatOrderReport()
        {
            return this.talonCombatOrderReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public List<WeaponCombatResultReport> GetWeaponCombatResultReportList()
        {
            return new List<WeaponCombatResultReport>(this.weaponCombatResultReportList);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType() + ": " +
                "\n\t>" + this.GetTalonCombatOrderReport() +
                "\n\t>weaponCombatResultReportList=[\n\t>" + string.Join("\n\t>", this.GetWeaponCombatResultReportList()) + "\n]" +
                "\n\t>isTargetDestroyed= " + this.GetIsTargetDestroyed();
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
            private bool isTargetDestroyed = false;

            // Todo
            private bool setIsTargetDestroyed = false;

            // Todo
            private TalonCombatOrderReport talonCombatOrderReport = null;

            // Todo
            private List<WeaponCombatResultReport> weaponCombatResultReportList = new List<WeaponCombatResultReport>();

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public TalonCombatResultReport Build()
            {
                HashSet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonCombatResultReport(this.isTargetDestroyed, this.talonCombatOrderReport, this.weaponCombatResultReportList);
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
            /// <param name="isTargetDestroyed"></param>
            /// <returns></returns>
            public Builder SetIsTargetDestroyed(bool isTargetDestroyed)
            {
                this.setIsTargetDestroyed = true;
                this.isTargetDestroyed = isTargetDestroyed;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonCombatOrderReport"></param>
            /// <returns></returns>
            public Builder SetTalonCombatOrderReport(TalonCombatOrderReport talonCombatOrderReport)
            {
                this.talonCombatOrderReport = talonCombatOrderReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="weaponCombatResultReportList"></param>
            /// <returns></returns>
            public Builder SetWeaponCombatResultReportList(List<WeaponCombatResultReport> weaponCombatResultReportList)
            {
                this.weaponCombatResultReportList = weaponCombatResultReportList;
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
                // Check that isTargetDestroyed has been set
                if (!this.setIsTargetDestroyed)
                {
                    argumentExceptionSet.Add("isTargetDestroyed has not been set");
                }
                // Check that talonCombatOrderReport has been set
                if (this.talonCombatOrderReport == null)
                {
                    argumentExceptionSet.Add(typeof(TalonCombatOrderReport) + " has not been set");
                }
                // Check that weaponCombatResultReportList has been set
                if (this.weaponCombatResultReportList == null)
                {
                    argumentExceptionSet.Add("weaponCombatResultReportList has not been set");
                }
                // Check that weaponCombatResultReportList is valid
                if (this.weaponCombatResultReportList != null &&
                    this.weaponCombatResultReportList.Count == 0)
                {
                    argumentExceptionSet.Add("weaponCombatResultReportList is not valid");
                }
                return argumentExceptionSet;
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}