using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Reports.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Reports.Api
{
    /// <summary>
    /// Armor Report Api
    /// </summary>
    public interface IArmorReport
        : ILoadoutReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ArmorId GetArmorId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IArmorTraitReport GetArmorTraitReport();
    }
}