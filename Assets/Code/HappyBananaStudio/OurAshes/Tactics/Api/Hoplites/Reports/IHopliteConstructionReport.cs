
namespace HappyBananaStudio.OurAshes.Tactics.Api.Hoplites.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Hoplites;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public interface IHopliteConstructionReport
    {
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
