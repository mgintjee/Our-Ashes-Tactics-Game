namespace HappyBananaStudio.OurAshes.Tactics.Impl.Hoplites.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Hoplites.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Hoplites;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct HopliteConstructionReportImpl
        : IHopliteConstructionReport
    {
        // Todo
        private readonly ControllerType controllerId;

        // Todo
        private readonly ISet<HopliteTraitEnum> hopliteTraitSet;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="controllerId">
        /// </param>
        /// <param name="hopliteTraitSet">
        /// </param>
        private HopliteConstructionReportImpl(ControllerType controllerId, ISet<HopliteTraitEnum> hopliteTraitSet)
        {
            this.controllerId = controllerId;
            this.hopliteTraitSet = hopliteTraitSet;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ControllerType IHopliteConstructionReport.GetControllerId() { return this.controllerId; }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<HopliteTraitEnum> IHopliteConstructionReport.GetHopliteTraitSet() { return new HashSet<HopliteTraitEnum>(this.hopliteTraitSet); }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private ControllerType controllerId = ControllerType.None;

            // Todo
            private ISet<HopliteTraitEnum> hopliteTraitSet = null;

            /// <summary>
            /// Build the HopliteConstructionReportImpl with the set parameters
            /// </summary>
            /// <returns>
            /// The IHopliteConstructionReport
            /// </returns>
            public IHopliteConstructionReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new HopliteConstructionReportImpl(this.controllerId, this.hopliteTraitSet);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
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
                return argumentExceptionSet;
            }
        }
    }
}