

namespace HappyBananaStudio.OurAshes.Tactics.Impl.Hoplites.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Hoplites.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Hoplites.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Hoplites.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Hoplites;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Hoplites.Reports;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public class HopliteObjectImpl
        : IHopliteObject
    {
        // Todo
        private readonly IBonusAttributes bonusAttributes;

        // Todo
        private readonly ControllerType controllerId;

        // Todo
        private readonly ISet<HopliteTraitEnum> hopliteTraitSet;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hopliteConstructionReport">
        /// </param>
        public HopliteObjectImpl(ITalonConstructionReport talonConstructionReport)
        {
            this.hopliteTraitSet = talonConstructionReport.GetHopliteConstructionReport().GetHopliteTraitSet();
            this.controllerId = talonConstructionReport.GetHopliteConstructionReport().GetControllerId();
            this.bonusAttributes = HopliteAttributesConstants.GetAttributes(this.hopliteTraitSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IHopliteInformationReport IHopliteObject.GetHopliteInformationReport()
        {
            return new HopliteInformationReportImpl.Builder()
                .SetControllerId(this.controllerId)
                .SetHopliteTraitSet(this.hopliteTraitSet)
                .SetBonusAttributes(this.bonusAttributes)
                .Build();
        }
    }
}
