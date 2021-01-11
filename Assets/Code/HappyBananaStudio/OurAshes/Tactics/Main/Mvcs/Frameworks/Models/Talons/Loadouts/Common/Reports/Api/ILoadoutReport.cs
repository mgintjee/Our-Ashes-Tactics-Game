using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Reports.Api
{
    /// <summary>
    /// Loadout Report Api
    /// </summary>
    public interface ILoadoutReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        LoadoutRarity GetLoadoutRarity();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ILoadoutAttributes GetLoadoutAttributes();
    }
}