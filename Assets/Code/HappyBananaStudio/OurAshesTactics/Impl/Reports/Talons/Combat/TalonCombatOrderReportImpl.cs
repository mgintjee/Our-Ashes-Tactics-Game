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
    public struct TalonCombatOrderReportImpl
        : ITalonCombatOrderReport
    {
        private readonly List<IWeaponOrderReport> weaponOrderReportList;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponOrderReportList">
        /// </param>
        private TalonCombatOrderReportImpl(List<IWeaponOrderReport> weaponOrderReportList)
        {
            this.weaponOrderReportList = weaponOrderReportList;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public List<IWeaponOrderReport> GetWeaponOrderReportList()
        {
            return new List<IWeaponOrderReport>(this.weaponOrderReportList);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>List: " + typeof(IWeaponOrderReport).Name + "=[" +
                string.Join(",\n\t\t>", this.weaponOrderReportList) + "\n]";
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private List<IWeaponOrderReport> weaponOrderReportList = null;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public ITalonCombatOrderReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonCombatOrderReportImpl(this.weaponOrderReportList);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the List: IWeaponOrderReport
            /// </summary>
            /// <param name="weaponOrderReportList">
            /// The List: IWeaponOrderReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetWeaponOrderReportList(List<IWeaponOrderReport> weaponOrderReportList)
            {
                this.weaponOrderReportList = new List<IWeaponOrderReport>(weaponOrderReportList);
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
                // Check that weaponOrderReportList has been set
                if (this.weaponOrderReportList == null)
                {
                    argumentExceptionSet.Add("List: " + typeof(IWeaponOrderReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}