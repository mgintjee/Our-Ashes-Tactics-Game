

namespace HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Attributes
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Utilities.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Weapons.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Utilities;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Weapons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct MountableAttributesReportImpl
        : IMountableAttributesReport
    {
        // Todo
        private readonly int currentUtilityMountPoints;

        // Todo
        private readonly int currentWeaponMountPoints;

        // Todo
        private readonly int maximumUtilityMountPoints;

        // Todo
        private readonly int maximumWeaponMountPoints;

        // Todo
        private readonly IList<IUtilityInformationReport> utilityInformationReportList;

        // Todo
        private readonly IList<IWeaponInformationReport> weaponInformationReportList;

        /// <summary>
        /// Private constructor to force using the Builder
        /// </summary>
        /// <param name="weaponInformationReportList">
        /// </param>
        private MountableAttributesReportImpl(IList<IUtilityInformationReport> utilityInformationReportList,
            IList<IWeaponInformationReport> weaponInformationReportList)
        {
            this.weaponInformationReportList = weaponInformationReportList;
            this.maximumWeaponMountPoints = this.weaponInformationReportList.Count;
            int weaponCounter = 0;
            for (int i = 0; i < this.weaponInformationReportList.Count; ++i)
            {
                if (!this.weaponInformationReportList[i].GetWeaponModelId()
                    .Equals(WeaponModelId.None))
                {
                    weaponCounter++;
                }
            }
            this.currentWeaponMountPoints = weaponCounter;

            this.utilityInformationReportList = utilityInformationReportList;
            this.maximumUtilityMountPoints = this.utilityInformationReportList.Count;
            int utilityCounter = 0;
            for (int i = 0; i < this.utilityInformationReportList.Count; ++i)
            {
                if (!this.utilityInformationReportList[i].GetUtilityModelId()
                    .Equals(UtilityModelId.None))
                {
                    utilityCounter++;
                }
            }
            this.currentUtilityMountPoints = utilityCounter;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>Current WeaponPoints=" + this.currentWeaponMountPoints +
                ", Maximum WeaponPoints=" + this.maximumWeaponMountPoints +
                "\n\t>List: " + typeof(IWeaponInformationReport).Name + "=[\n\t>" +
                string.Join("\n\t>", this.weaponInformationReportList) +
                "\n]" +
                "\n\t>Current UtilityPoints = " + this.currentUtilityMountPoints +
                ", Maximum UtilityPoints=" + this.maximumUtilityMountPoints +
                "\n\t>List: " + typeof(IUtilityInformationReport).Name + "=[\n\t>" +
                string.Join("\n\t>", this.utilityInformationReportList) +
                "\n]";
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int IMountableAttributesReport.GetCurrentUtilityMountPoints()
        {
            return this.currentUtilityMountPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int IMountableAttributesReport.GetCurrentWeaponMountPoints()
        {
            return this.currentWeaponMountPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int IMountableAttributesReport.GetMaximumUtilityMountPoints()
        {
            return this.maximumUtilityMountPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int IMountableAttributesReport.GetMaximumWeaponMountPoints()
        {
            return this.maximumWeaponMountPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IList<IUtilityInformationReport> IMountableAttributesReport.GetUtilityInformationReportList()
        {
            return new List<IUtilityInformationReport>(this.utilityInformationReportList);
        }

        /// <summary>
        /// Get the List: WeaponInformationReport
        /// </summary>
        /// <returns>
        /// The List: WeaponInformationReport
        /// </returns>
        IList<IWeaponInformationReport> IMountableAttributesReport.GetWeaponInformationReportList()
        {
            return new List<IWeaponInformationReport>(this.weaponInformationReportList);
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private IList<IUtilityInformationReport> utilityInformationReportList;

            // Todo
            private IList<IWeaponInformationReport> weaponInformationReportList;

            /// <summary>
            /// Build the attributes with the set parameters
            /// </summary>
            /// <returns>
            /// The attributes interface
            /// </returns>
            public IMountableAttributesReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new MountableAttributesReportImpl(this.utilityInformationReportList,
                        this.weaponInformationReportList);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the List: IUtilityInformationReport
            /// </summary>
            /// <param name="utilityInformationReportList">
            /// The List: IUtilityInformationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetUtilityInformationReportList(IList<IUtilityInformationReport> utilityInformationReportList)
            {
                this.utilityInformationReportList = new List<IUtilityInformationReport>(utilityInformationReportList);
                return this;
            }

            /// <summary>
            /// Set the value of the List: IWeaponInformationReport
            /// </summary>
            /// <param name="weaponInformationReportList">
            /// The List: IWeaponInformationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetWeaponInformationReportList(IList<IWeaponInformationReport> weaponInformationReportList)
            {
                this.weaponInformationReportList = new List<IWeaponInformationReport>(weaponInformationReportList);
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
                // Check that weaponInformationReportList has been set
                if (this.weaponInformationReportList == null)
                {
                    argumentExceptionSet.Add("List: " + typeof(IWeaponInformationReport).Name + " has not been set");
                }
                // Check that utilityInformationReportList has been set
                if (this.utilityInformationReportList == null)
                {
                    argumentExceptionSet.Add("List: " + typeof(IUtilityInformationReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
