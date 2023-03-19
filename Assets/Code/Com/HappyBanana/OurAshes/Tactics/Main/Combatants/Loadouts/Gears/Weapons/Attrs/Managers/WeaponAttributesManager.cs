using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Internals.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Attrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Weapons.Attrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Weapons.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Weapons.Attrs.Managers
{
    public static class WeaponAttributesManager
    {
        private static readonly IList<IGearAttributes<WeaponGearID>> KNOWN_IMPLS = new List<IGearAttributes<WeaponGearID>>()
        {
            new WsaAttributesImpl(),
            new WmaAttributesImpl(),
            new WlaAttributesImpl()
        };

        /// <summary>
        /// s Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IOptional<IGearAttributes<WeaponGearID>> GetAttributes(WeaponGearID id)
        {
            foreach (IGearAttributes<WeaponGearID> gearAttributes in KNOWN_IMPLS)
            {
                if (gearAttributes.GetID() == id)
                {
                    return Optional<IGearAttributes<WeaponGearID>>.Of(gearAttributes);
                }
            }
            return Optional<IGearAttributes<WeaponGearID>>.Empty();
        }
    }
}