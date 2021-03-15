using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Armors.Traits.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Armors.Traits.Reports.Api
{
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