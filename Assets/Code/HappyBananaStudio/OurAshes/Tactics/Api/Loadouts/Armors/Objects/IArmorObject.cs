namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Armors.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Armors.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Common.Objects;

    /// <summary>
    /// Armor Object Api
    /// </summary>
    public interface IArmorObject
        : ILoadoutObject
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
        ArmorTraitStructure GetArmorTraitStructure();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ArmorTraitMaterial GetArmorTraitMaterial();
    }
}