using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Armors.Gears.Attrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Armors.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Attrs.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Armors.Gears.Attrs.Managers
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
                { ArmorGearID.AA, new ArmorGearAlphaAlphaAttributesImpl() },
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