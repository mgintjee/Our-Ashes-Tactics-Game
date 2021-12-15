using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Gears.Sizes;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Loadouts.Inters
{
    /// <summary>
    /// Loadout Attributes Interface
    /// </summary>
    public interface ILoadoutAttributes
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        GearSize GetArmorGearSize();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        GearSize GetCabinGearSize();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        GearSize GetEngineGearSize();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IList<GearSize> GetWeaponGearSizes();
    }
}