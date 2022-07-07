using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Traits.Attrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Traits.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Attrs.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Traits.Attrs.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class CabinTraitAttributesManager
    {
        private static readonly IDictionary<CabinTraitID, IGearAttributes> ID_ATTRIBUTES =
            new Dictionary<CabinTraitID, IGearAttributes>()
            {
                { CabinTraitID.AlphaAlpha, new CabinTraitAlphaAlphaAttributesImpl() },
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="traitId"></param>
        /// <returns></returns>
        public static Optional<IGearAttributes> GetAttributes(CabinTraitID traitId)
        {
            return (ID_ATTRIBUTES.ContainsKey(traitId))
                ? Optional<IGearAttributes>.Of(ID_ATTRIBUTES[traitId])
                : Optional<IGearAttributes>.Empty();
        }
    }
}