namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Reports.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Enums;

    /// <summary>
    /// Armor Trait Report Api
    /// </summary>
    public interface IArmorTraitReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ArmorTraitMaterial GetArmorTraitMaterial();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ArmorTraitStructure GetArmorTraitStructure();
    }
}