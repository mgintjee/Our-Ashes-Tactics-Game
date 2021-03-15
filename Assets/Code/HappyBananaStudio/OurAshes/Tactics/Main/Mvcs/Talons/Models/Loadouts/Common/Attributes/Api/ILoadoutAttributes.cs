using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Armors.Attributes.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Attributes.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Weapons.Attributes.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Common.Attributes.Api
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ILoadoutAttributes
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IArmorAttributes GetArmorAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IEngineAttributes GetEngineAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IWeaponAttributes GetWeaponAttributes();
    }
}