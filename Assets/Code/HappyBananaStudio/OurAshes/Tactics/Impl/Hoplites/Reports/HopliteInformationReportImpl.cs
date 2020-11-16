

namespace HappyBananaStudio.OurAshes.Tactics.Impl.Hoplites.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Hoplites.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Hoplites;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct HopliteInformationReportImpl
        : IHopliteInformationReport
    {
        // Todo
        private readonly IBonusAttributes bonusAttributes;

        // Todo
        private readonly ControllerType controllerId;

        // Todo
        private readonly ISet<HopliteTraitEnum> hopliteTraitSet;

        private HopliteInformationReportImpl(ControllerType controllerId,
            ISet<HopliteTraitEnum> hopliteTraitSet, IBonusAttributes bonusAttributes)
        {
            this.controllerId = controllerId;
            this.hopliteTraitSet = hopliteTraitSet;
            this.bonusAttributes = bonusAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IBonusAttributes GetBonusAttributes() { return this.bonusAttributes; }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ControllerType GetControllerId()
        {
            return this.controllerId;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ISet<HopliteTraitEnum> GetHopliteTraitSet() { return new HashSet<HopliteTraitEnum>(this.hopliteTraitSet); }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private IBonusAttributes bonusAttributes = null;

            // Todo
            private ControllerType controllerId = ControllerType.None;

            // Todo
            private ISet<HopliteTraitEnum> hopliteTraitSet = null;

            /// <summary>
            /// Build the HopliteInformationReportImpl with the set parameters
            /// </summary>
            /// <returns>
            /// The IHopliteInformationReport
            /// </returns>
            public IHopliteInformationReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new HopliteInformationReportImpl(this.controllerId,
                        this.hopliteTraitSet, this.bonusAttributes);
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
            /// Set the value of the ControllerIdEnum
            /// </summary>
            /// <param name="controllerId">
            /// The ControllerIdEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetControllerId(ControllerType controllerId)
            {
                this.controllerId = controllerId;
                return this;
            }

            /// <summary>
            /// Set the value of the Set: HopliteTrait
            /// </summary>
            /// <param name="hopliteTraitSet">
            /// The Set: HopliteTrait to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetHopliteTraitSet(ISet<HopliteTraitEnum> hopliteTraitSet)
            {
                this.hopliteTraitSet = new HashSet<HopliteTraitEnum>(hopliteTraitSet);
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
                // Check that controllerId has been set
                if (this.controllerId == ControllerType.None)
                {
                    argumentExceptionSet.Add(typeof(ControllerType).Name + " has not been set");
                }
                // Check that hopliteTraitSet has been set
                if (this.hopliteTraitSet == null)
                {
                    argumentExceptionSet.Add("Set:" + typeof(HopliteTraitEnum).Name + " has not been set");
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
