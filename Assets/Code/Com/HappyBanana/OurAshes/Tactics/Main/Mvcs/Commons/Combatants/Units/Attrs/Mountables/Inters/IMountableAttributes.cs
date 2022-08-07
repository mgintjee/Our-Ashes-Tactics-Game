using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Sizes;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Mountables.Inters
{
    /// <summary>
    /// Loadout Attributes Interface
    /// </summary>
    public interface IMountableAttributes
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