/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Attributes;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons.Attributes
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct FireableReportImpl
        : IFireableReport
    {
        // Todo
        private readonly int currentWeaponPoints;

        // Todo
        private readonly int maximumWeaponPoints;

        // Todo
        private readonly List<IWeaponInformationReport> weaponInformationReportList;

        /// <summary>
        /// Private constructor to force using the Builder
        /// </summary>
        /// <param name="weaponAttributeList">
        /// </param>
        private FireableReportImpl(List<IWeaponInformationReport> weaponAttributeList)
        {
            this.weaponInformationReportList = weaponAttributeList;
            this.maximumWeaponPoints = this.weaponInformationReportList.Count;
            int weaponCounter = 0;
            this.weaponInformationReportList.ForEach(
                weaponId =>
                {
                    if (weaponId.GetWeaponId().Equals(WeaponModelIdEnum.None))
                    {
                        weaponCounter++;
                    }
                }
                );
            this.currentWeaponPoints = weaponCounter;
        }

        /// <summary>
        /// Get the currentWeaponPoints
        /// </summary>
        /// <returns>
        /// The int currentWeaponPoints
        /// </returns>
        public int GetCurrentWeaponPoints()
        {
            return this.currentWeaponPoints;
        }

        /// <summary>
        /// Get the maximumWeaponPoints
        /// </summary>
        /// <returns>
        /// The int maximumWeaponPoints
        /// </returns>
        public int GetMaximumWeaponPoints()
        {
            return this.maximumWeaponPoints;
        }

        /// <summary>
        /// Get the List: WeaponInformationReport
        /// </summary>
        /// <returns>
        /// The List: WeaponInformationReport
        /// </returns>
        public List<IWeaponInformationReport> GetWeaponInformationReportList()
        {
            return new List<IWeaponInformationReport>(this.weaponInformationReportList);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ": Current WeaponPoints=" + this.GetCurrentWeaponPoints() +
                ", Maximum WeaponPoints=" + this.GetMaximumWeaponPoints() +
                "\n\t>List: " + typeof(IWeaponInformationReport).Name + "=[\n\t>" +
                string.Join("\n\t>", this.weaponInformationReportList) +
                "\n]";
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private List<IWeaponInformationReport> weaponInformationReportList;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public IFireableReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new FireableReportImpl(this.weaponInformationReportList);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the List: WeaponInformationReport
            /// </summary>
            /// <param name="weaponInformationReportList">
            /// The List: WeaponInformationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetWeaponIdList(List<IWeaponInformationReport> weaponInformationReportList)
            {
                this.weaponInformationReportList = weaponInformationReportList;
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
                // Check that weaponInformationReportList has been set
                if (this.weaponInformationReportList == null)
                {
                    argumentExceptionSet.Add("List: " + typeof(IWeaponInformationReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}