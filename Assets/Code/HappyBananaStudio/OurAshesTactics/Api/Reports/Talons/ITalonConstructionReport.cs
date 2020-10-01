/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Hoplites;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Paints;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonConstructionReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IHopliteAttributes GetHopliteAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IPaintSchemeReport GetPaintSchemeReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonIdentificationReport GetTalonIdentificationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        List<UtilityModelIdEnum> GetUtilityIdList();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        List<WeaponModelIdEnum> GetWeaponIdList();
    }
}