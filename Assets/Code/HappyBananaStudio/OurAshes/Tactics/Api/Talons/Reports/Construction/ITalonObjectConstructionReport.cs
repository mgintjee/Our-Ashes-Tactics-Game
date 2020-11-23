namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Hoplites.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Utilities;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Weapons;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonObjectConstructionReport
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
        TalonModelId GetTalonModelId();

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