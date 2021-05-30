using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Sizes.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Loadouts.Reports.Traits.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Loadouts.Reports.Gears.Interfaces
{
    /// <summary>
    /// Gear Report Interface
    /// </summary>
    public interface IGearReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICombatantAttributes GetCombatantAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        GearSize GetGearSize();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        GearType GetGearType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        GearID GetGearID();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ITraitReport GetTraitReport();
    }
}