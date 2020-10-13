/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Attributes;
using HappyBananaStudio.OurAshes.Tactics.Api.Utilities.Reports;
using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Utilities.Enums;
using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshes.Tactics.Impl.Utilities.Reports
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct UtilityInformationReportImpl
        : IUtilityInformationReport
    {
        // Todo
        private readonly IBonusAttributes bonusAttributes;

        // Todo
        private readonly UtilityModelIdEnum utilityModelId;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="utilityModelId">
        /// </param>
        /// <param name="bonusAttributes">
        /// </param>
        private UtilityInformationReportImpl(UtilityModelIdEnum utilityModelId, IBonusAttributes bonusAttributes)
        {
            this.utilityModelId = utilityModelId;
            this.bonusAttributes = bonusAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + typeof(UtilityModelIdEnum).Name + "=" + this.utilityModelId +
                "\n\t>" + this.bonusAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IBonusAttributes IUtilityInformationReport.GetUtilityAttributes()
        {
            return this.bonusAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        UtilityModelIdEnum IUtilityInformationReport.GetUtilityModelId()
        {
            return this.utilityModelId;
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private UtilityModelIdEnum utilityModelId = UtilityModelIdEnum.None;

            // Todo
            private IBonusAttributes bonusAttributes = null;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public IUtilityInformationReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new UtilityInformationReportImpl(this.utilityModelId, this.bonusAttributes);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the IBonusAttributes
            /// </summary>
            /// <param name="bonusAttributes">
            /// The IBonusAttributes to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetBonusAttributes(IBonusAttributes bonusAttributes)
            {
                this.bonusAttributes = bonusAttributes;
                return this;
            }

            /// <summary>
            /// Set the value of the UtilityModelIdEnum
            /// </summary>
            /// <param name="utilityModelId">
            /// The UtilityModelIdEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetUtilityModelId(UtilityModelIdEnum utilityModelId)
            {
                this.utilityModelId = utilityModelId;
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
                // Check that utilityModelId has been set
                if (this.utilityModelId == UtilityModelIdEnum.None)
                {
                    argumentExceptionSet.Add(typeof(UtilityModelIdEnum).Name + " has not been set");
                }
                // Check that bonusAttributes has been set
                if (this.bonusAttributes == null)
                {
                    argumentExceptionSet.Add(typeof(IBonusAttributes).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
