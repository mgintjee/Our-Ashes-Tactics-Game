using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Gears.Attrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Attrs.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Gears.Attrs.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class CabinGearAttributesManager
    {
        private static readonly IDictionary<CabinGearID, IGearAttributes> ID_ATTRIBUTES =
            new Dictionary<CabinGearID, IGearAttributes>()
            {
                { CabinGearID.AlphaAlpha, new CabinGearAlphaAlphaAttributesImpl() },
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Optional<IGearAttributes> GetAttributes(CabinGearID id)
        {
            return (ID_ATTRIBUTES.ContainsKey(id))
                ? Optional<IGearAttributes>.Of(ID_ATTRIBUTES[id])
                : Optional<IGearAttributes>.Empty();
        }
    }
}