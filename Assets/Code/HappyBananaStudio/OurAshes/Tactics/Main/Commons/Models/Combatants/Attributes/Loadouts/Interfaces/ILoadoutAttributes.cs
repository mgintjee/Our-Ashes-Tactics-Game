using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Loadouts.Interfaces
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