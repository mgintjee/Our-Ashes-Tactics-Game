/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.Hoplites.Objects;
using HappyBananaStudio.OurAshes.Tactics.Api.Hoplites.Reports;
using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Attributes;
using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Hoplites.Attributes;
using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Hoplites.Enums;
using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Talons.Enums;
using HappyBananaStudio.OurAshes.Tactics.Impl.Hoplites.Reports;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshes.Tactics.Impl.Hoplites.Objects
{
    /// <summary>
    /// Todo
    /// </summary>
    public class HopliteObjectImpl
        : IHopliteObject
    {
        // Todo
        private readonly IBonusAttributes bonusAttributes;

        // Todo
        private readonly ControllerIdEnum controllerId;

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
