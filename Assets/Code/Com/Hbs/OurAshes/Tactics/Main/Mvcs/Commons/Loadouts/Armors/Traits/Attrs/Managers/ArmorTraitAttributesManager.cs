using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Traits.Attrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Traits.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Attrs.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Traits.Attrs.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class ArmorTraitAttributesManager
    {
        private static readonly IDictionary<ArmorTraitID, IGearAttributes> ID_ATTRIBUTES =
            new Dictionary<ArmorTraitID, IGearAttributes>()
            {
                { ArmorTraitID.AlphaAlpha, new ArmorTraitAlphaAlphaAttributesImpl() },
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="traitId"></param>
        /// <returns></returns>
        public static Optional<IGearAttributes> GetAttributes(ArmorTraitID traitId)
        {
            return (ID_ATTRIBUTES.ContainsKey(traitId))
                ? Optional<IGearAttributes>.Of(ID_ATTRIBUTES[traitId])
                : Optional<IGearAttributes>.Empty();
        }
    }
}