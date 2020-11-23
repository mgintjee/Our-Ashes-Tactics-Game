namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Common.Attributes
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