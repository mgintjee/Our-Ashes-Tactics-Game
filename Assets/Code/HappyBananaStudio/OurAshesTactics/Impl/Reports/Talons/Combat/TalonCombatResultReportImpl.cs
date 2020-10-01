/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Combat;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons.Combat
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonCombatResultReportImpl
        : ITalonCombatResultReport
    {
        // Todo
        private readonly bool isTargetDestroyed;

        // Todo
        private readonly ITalonCombatOrderReport talonCombatOrderReport;

        // Todo
        private readonly List<IWeaponResultReport> weaponResultReportList;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="isTargetDestroyed">
        /// </param>
        /// <param name="talonCombatOrderReport">
        /// </param>
        /// <param name="weaponResultReportList">
        /// </param>
        public TalonCombatResultReportImpl(bool isTargetDestroyed, ITalonCombatOrderReport talonCombatOrderReport,
            List<IWeaponResultReport> weaponResultReportList)
        {
            this.isTargetDestroyed = isTargetDestroyed;
            this.talonCombatOrderReport = talonCombatOrderReport;
            this.weaponResultReportList = weaponResultReportList;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public bool GetIsTargetDestroyed()
        {
            return this.isTargetDestroyed;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonCombatOrderReport GetTalonCombatOrderReport()
        {
            return this.talonCombatOrderReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public List<IWeaponResultReport> GetWeaponResultReportList()
        {
            return new List<IWeaponResultReport>(this.weaponResultReportList);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>IsTargetDestroyed: " + this.GetIsTargetDestroyed() +
                "\n\t>" + this.GetTalonCombatOrderReport() +
                "\n\t>List: " + typeof(IWeaponResultReport).Name + "=[" +
                string.Join(",\n\t\t>", this.weaponResultReportList) + "\n]";
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private bool isTargetDestroyed;

            // Todo
            private bool setIsTargetDestroyed = false;

            // Todo
            private ITalonCombatOrderReport talonCombatOrderReport = null;

            // Todo
            private List<IWeaponResultReport> weaponResultReportList = null;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public ITalonCombatResultReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonCombatResultReportImpl(this.isTargetDestroyed, this.talonCombatOrderReport,
                        this.weaponResultReportList);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the isTargetDestroyed
            /// </summary>
            /// <param name="isTargetDestroyed">
            /// The isTargetDestroyed to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetIsTargetDestroyed(bool isTargetDestroyed)
            {
                this.isTargetDestroyed = isTargetDestroyed;
                this.setIsTargetDestroyed = true;
                return this;
            }

            /// <summary>
            /// Set the value of the ITalonCombatOrderReport
            /// </summary>
            /// <param name="talonCombatOrderReport">
            /// The ITalonCombatOrderReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonCombatOrderReport(ITalonCombatOrderReport talonCombatOrderReport)
            {
                this.talonCombatOrderReport = talonCombatOrderReport;
                return this;
            }

            /// <summary>
            /// Set the value of the List: IWeaponResultReport
            /// </summary>
            /// <param name="weaponResultReportList">
            /// The List: IWeaponResultReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetWeaponResultReportList(List<IWeaponResultReport> weaponResultReportList)
            {
                this.weaponResultReportList = new List<IWeaponResultReport>(weaponResultReportList);
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
                // Check that isTargetDestroyed has been set
                if (!this.setIsTargetDestroyed)
                {
                    argumentExceptionSet.Add("setIsTargetDestroyed has not been set");
                }
                // Check that isTargetDestroyed has been set
                if (this.talonCombatOrderReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonCombatOrderReport).Name + " has not been set");
                }
                // Check that weaponResultReportList has been set
                if (this.weaponResultReportList == null)
                {
                    argumentExceptionSet.Add("List: " + typeof(IWeaponResultReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}