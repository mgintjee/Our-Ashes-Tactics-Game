using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Attrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Gears.Attrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Gears.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Gears.Attrs.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class WeaponGearAttributesManager
    {
        private static readonly IDictionary<WeaponGearID, IGearAttributes> ID_ATTRIBUTES =
            new Dictionary<WeaponGearID, IGearAttributes>()
            {
                { WeaponGearID.AA, new WeaponGearAlphaAlphaAttributesImpl() },
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Optional<IGearAttributes> GetAttributes(WeaponGearID id)
        {
            return (ID_ATTRIBUTES.ContainsKey(id))
                ? Optional<IGearAttributes>.Of(ID_ATTRIBUTES[id])
                : Optional<IGearAttributes>.Empty();
        }
    }
}