
namespace HappyBananaStudio.OurAshes.Tactics.Api.Hoplites.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Hoplites;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public interface IHopliteInformationReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IBonusAttributes GetBonusAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ControllerType GetControllerId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<HopliteTraitEnum> GetHopliteTraitSet();
    }
}
