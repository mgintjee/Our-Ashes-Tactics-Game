using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Armors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Loadouts.Gears.Armors.Attrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Loadouts.Gears.Commons.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Loadouts.Gears.Armors.Attrs.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class ArmorGearAttributesManager
    {
        // Todo
        private static readonly IDictionary<ArmorGearID, IGearAttributes> ID_ATTRIBUTES =
            new Dictionary<ArmorGearID, IGearAttributes>()
            {
                { ArmorGearID.AlphaAlpha, new ArmorGearAlphaAlphaAttributesImpl() },
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Optional<IGearAttributes> GetAttributes(ArmorGearID id)
        {
            return (ID_ATTRIBUTES.ContainsKey(id))
                ? Optional<IGearAttributes>.Of(ID_ATTRIBUTES[id])
                : Optional<IGearAttributes>.Empty();
        }
    }
}