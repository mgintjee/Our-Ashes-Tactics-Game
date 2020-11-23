namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Common.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Common.Attributes;

    /// <summary>
    /// Loadout Object Api
    /// </summary>
    public interface ILoadoutObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ILoadoutAttributes GetLoadoutAttributes();
    }
}