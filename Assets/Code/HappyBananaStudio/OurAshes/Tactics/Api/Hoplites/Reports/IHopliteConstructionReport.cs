/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshes.Tactics.Api.Hoplites.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Hoplites.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Talons.Enums;
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
        ControllerIdEnum GetControllerId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<HopliteTraitEnum> GetHopliteTraitSet();
    }
}
