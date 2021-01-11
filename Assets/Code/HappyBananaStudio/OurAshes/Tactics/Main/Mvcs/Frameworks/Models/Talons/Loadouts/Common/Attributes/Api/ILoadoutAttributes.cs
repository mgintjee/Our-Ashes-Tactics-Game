namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Attributes.Api;

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