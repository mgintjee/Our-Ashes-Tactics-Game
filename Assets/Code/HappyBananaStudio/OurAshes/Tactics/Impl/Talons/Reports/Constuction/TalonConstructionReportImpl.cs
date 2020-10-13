/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Hoplites.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Utilities.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Weapons.Enums;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonConstructionReportImpl
        : ITalonConstructionReport
    {
        // Todo
        private readonly IHopliteConstructionReport hopliteConstructionReport;

        // Todo
        private readonly ITalonCustomizationReport talonCustomizationReport;

        // Todo
        private readonly ITalonIdentificationReport talonIdentificationReport;

        // Todo
        private readonly IList<UtilityModelIdEnum> utilityIdList;

        // Todo
        private readonly IList<WeaponModelIdEnum> weaponIdList;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="paintSchemeReport">
        /// </param>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <param name="weaponIdList">
        /// </param>
        private TalonConstructionReportImpl(IHopliteConstructionReport hopliteConstructionReport,
            ITalonCustomizationReport talonCustomizationReport, ITalonIdentificationReport talonIdentificationReport,
            IList<UtilityModelIdEnum> utilityIdList, IList<WeaponModelIdEnum> weaponIdList)
        {
            this.hopliteConstructionReport = hopliteConstructionReport;
            this.talonCustomizationReport = talonCustomizationReport;
            this.talonIdentificationReport = talonIdentificationReport;
            this.utilityIdList = utilityIdList;
            this.weaponIdList = weaponIdList;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + this.talonIdentificationReport +
                "\n\t>" + this.hopliteConstructionReport +
                "\n\t>" + this.talonCustomizationReport +
                "\n\t>List: " + typeof(WeaponModelIdEnum).Name + "=[" + string.Join("\n\t\t>", this.weaponIdList) +
                "\n]" +
                "\n\t>List: " + typeof(UtilityModelIdEnum).Name + "=[" + string.Join("\n\t\t>", this.utilityIdList) +
                "\n]";
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IHopliteConstructionReport ITalonConstructionReport.GetHopliteConstructionReport()
        {
            return this.hopliteConstructionReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonCustomizationReport ITalonConstructionReport.GetTalonCustomizationReport()
        {
            return this.talonCustomizationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonIdentificationReport ITalonConstructionReport.GetTalonIdentificationReport()
        {
            return this.talonIdentificationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IList<UtilityModelIdEnum> ITalonConstructionReport.GetUtilityModelIdList()
        {
            return new List<UtilityModelIdEnum>(this.utilityIdList);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IList<WeaponModelIdEnum> ITalonConstructionReport.GetWeaponModelIdList()
        {
            return new List<WeaponModelIdEnum>(this.weaponIdList);
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private IHopliteConstructionReport hopliteConstructionReport = null;

            // Todo
            private ITalonCustomizationReport talonCustomizationReport = null;

            // Todo
            private ITalonIdentificationReport talonIdentificationReport = null;

            // Todo
            private IList<UtilityModelIdEnum> utilityIdList = null;

            // Todo
            private IList<WeaponModelIdEnum> weaponIdList = null;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public ITalonConstructionReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonConstructionReportImpl(this.hopliteConstructionReport, this.talonCustomizationReport,
                        this.talonIdentificationReport, this.utilityIdList, this.weaponIdList);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the IHopliteConstructionReport
            /// </summary>
            /// <param name="hopliteConstructionReport">
            /// The IHopliteConstructionReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetHopliteConstructionReport(IHopliteConstructionReport hopliteConstructionReport)
            {
                this.hopliteConstructionReport = hopliteConstructionReport;
                return this;
            }

            /// <summary>
            /// Set the value of the ITalonCustomizationReport
            /// </summary>
            /// <param name="talonCustomizationReport">
            /// The ITalonCustomizationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonCustomizationReport(ITalonCustomizationReport talonCustomizationReport)
            {
                this.talonCustomizationReport = talonCustomizationReport;
                return this;
            }

            /// <summary>
            /// Set the value of the ITalonIdentificationReport
            /// </summary>
            /// <param name="talonIdentificationReport">
            /// The ITalonIdentificationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonIdentificationReport(ITalonIdentificationReport talonIdentificationReport)
            {
                this.talonIdentificationReport = talonIdentificationReport;
                return this;
            }

            /// <summary>
            /// Set the value of the List: UtilityIdEnum
            /// </summary>
            /// <param name="utilityIdList">
            /// The List: UtilityIdEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetUtilityList(IList<UtilityModelIdEnum> utilityIdList)
            {
                this.utilityIdList = utilityIdList;
                return this;
            }

            /// <summary>
            /// Set the value of the List: WeaponIdEnum
            /// </summary>
            /// <param name="weaponIdList">
            /// The List: WeaponIdEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetWeaponIdList(IList<WeaponModelIdEnum> weaponIdList)
            {
                this.weaponIdList = weaponIdList;
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
                // Check that hopliteConstructionReport has been set
                if (this.hopliteConstructionReport == null)
                {
                    argumentExceptionSet.Add(typeof(IHopliteConstructionReport).Name + " has not been set");
                }
                // Check that talonCustomizationReport has been set
                if (this.talonCustomizationReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonCustomizationReport).Name + " has not been set");
                }
                // Check that talonIdentificationReport has been set
                if (this.talonIdentificationReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonIdentificationReport).Name + " has not been set");
                }
                // Check that utilityIdList has been set
                if (this.utilityIdList == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(UtilityModelIdEnum).Name + " has not been set");
                }
                // Check that weaponIdList has been set
                if (this.weaponIdList == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(WeaponModelIdEnum).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
