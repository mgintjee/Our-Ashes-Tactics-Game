/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Hoplites;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Customization;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonConstructionReportImpl
        : ITalonConstructionReport
    {
        // Todo
        private readonly IHopliteAttributes hopliteAttributes;

        // Todo
        private readonly ITalonCustomizationReport talonCustomizationReport;

        // Todo
        private readonly ITalonIdentificationReport talonIdentificationReport;

        // Todo
        private readonly List<UtilityModelIdEnum> utilityIdList;

        // Todo
        private readonly List<WeaponModelIdEnum> weaponIdList;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="paintSchemeReport">
        /// </param>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <param name="weaponIdList">
        /// </param>
        private TalonConstructionReportImpl(IHopliteAttributes hopliteAttributes,
            ITalonCustomizationReport talonCustomizationReport, ITalonIdentificationReport talonIdentificationReport,
            List<UtilityModelIdEnum> utilityIdList, List<WeaponModelIdEnum> weaponIdList)
        {
            this.hopliteAttributes = hopliteAttributes;
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
        public IHopliteAttributes GetHopliteAttributes()
        {
            return this.hopliteAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonCustomizationReport GetTalonCustomizationReport()
        {
            return this.talonCustomizationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonIdentificationReport GetTalonIdentificationReport()
        {
            return this.talonIdentificationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public List<UtilityModelIdEnum> GetUtilityIdList()
        {
            return new List<UtilityModelIdEnum>(this.utilityIdList);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public List<WeaponModelIdEnum> GetWeaponIdList()
        {
            return new List<WeaponModelIdEnum>(this.weaponIdList);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + this.GetTalonIdentificationReport() +
                "\n\t>" + this.GetHopliteAttributes() +
                "\n\t>" + this.GetTalonCustomizationReport() +
                "\n\t>List: " + typeof(WeaponModelIdEnum).Name + "=[" + string.Join("\n\t\t>", this.weaponIdList) +
                "\n]" +
                "\n\t>List: " + typeof(UtilityModelIdEnum).Name + "=[" + string.Join("\n\t\t>", this.utilityIdList) +
                "\n]";
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private IHopliteAttributes hopliteAttributes = null;

            // Todo
            private ITalonCustomizationReport talonCustomizationReport = null;

            // Todo
            private ITalonIdentificationReport talonIdentificationReport = null;

            // Todo
            private List<UtilityModelIdEnum> utilityIdList = null;

            // Todo
            private List<WeaponModelIdEnum> weaponIdList = null;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public ITalonConstructionReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonConstructionReportImpl(this.hopliteAttributes, this.talonCustomizationReport,
                        this.talonIdentificationReport, this.utilityIdList, this.weaponIdList);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the IHopliteAttributes
            /// </summary>
            /// <param name="hopliteAttributes">
            /// The IHopliteAttributes to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetHopliteAttributes(IHopliteAttributes hopliteAttributes)
            {
                this.hopliteAttributes = hopliteAttributes;
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
            public Builder SetUtilityList(List<UtilityModelIdEnum> utilityIdList)
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
            public Builder SetWeaponIdList(List<WeaponModelIdEnum> weaponIdList)
            {
                this.weaponIdList = weaponIdList;
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
                // Check that hopliteAttributes has been set
                if (this.hopliteAttributes == null)
                {
                    argumentExceptionSet.Add(typeof(IHopliteAttributes).Name + " has not been set");
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