using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Internals.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Attrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Cabins.Attrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Cabins.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Cabins.Attrs.Managers
{
    public static class CabinAttributesManager
    {
        private static readonly IList<IGearAttributes<CabinGearID>> KNOWN_IMPLS = new List<IGearAttributes<CabinGearID>>()
        {
            new CsaAttributesImpl(),
            new CmaAttributesImpl(),
            new ClaAttributesImpl()
        };

        /// <summary>
        /// s Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IOptional<IGearAttributes<CabinGearID>> GetAttributes(CabinGearID id)
        {
            foreach (IGearAttributes<CabinGearID> gearAttributes in KNOWN_IMPLS)
            {
                if (gearAttributes.GetID() == id)
                {
                    return Optional<IGearAttributes<CabinGearID>>.Of(gearAttributes);
                }
            }
            return Optional<IGearAttributes<CabinGearID>>.Empty();
        }
    }
}