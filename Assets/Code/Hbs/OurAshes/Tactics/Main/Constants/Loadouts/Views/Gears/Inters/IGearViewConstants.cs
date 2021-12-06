using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Gears.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Gears.Skins;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Loadouts.Views.Gears.Inters
{
    /// <summary>
    /// Gear View Constants Interface
    /// </summary>
    public interface IGearViewConstants
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        GearID GetGearID();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<GearSkin> GetGearSkins();
    }
}