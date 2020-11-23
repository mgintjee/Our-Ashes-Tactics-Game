namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Hoplites.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Utilities;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Weapons;
    using System.Collections.Generic;

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
        IHopliteConstructionReport GetHopliteConstructionReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonCustomizationReport GetTalonCustomizationReport();

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
        IList<UtilityModelId> GetUtilityModelIdList();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IList<WeaponModelId> GetWeaponModelIdList();
    }
}