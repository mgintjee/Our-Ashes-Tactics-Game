using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Attrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Weapons.Traits.Attrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Weapons.Traits.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Weapons.Traits.Attrs.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class WeaponTraitAttributesManager
    {
        private static readonly IDictionary<WeaponTraitID, IGearAttributes> ID_ATTRIBUTES =
            new Dictionary<WeaponTraitID, IGearAttributes>()
            {
                { WeaponTraitID.AlphaAlpha, new WeaponTraitAlphaAlphaAttributesImpl() },
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="traitId"></param>
        /// <returns></returns>
        public static Optional<IGearAttributes> GetAttributes(WeaponTraitID traitId)
        {
            return (ID_ATTRIBUTES.ContainsKey(traitId))
                ? Optional<IGearAttributes>.Of(ID_ATTRIBUTES[traitId])
                : Optional<IGearAttributes>.Empty();
        }
    }
}