using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Traits.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Traits.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Rarities;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Loadouts.Models.Traits.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Loadouts.Models.Traits.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Loadouts.Models.Traits.Managers
{
    /// <summary>
    /// Trait Model Constants Manager to host the Trait Model Constants Impls
    /// </summary>
    public static class TraitModelConstantsManager
    {
        private static readonly IDictionary<TraitID, ITraitModelConstants> IDModelConstants =
            new Dictionary<TraitID, ITraitModelConstants>()
        {
            {
                TraitID.ArmorAlphaAlpha,
                TraitModelConstants.Builder.Get()
                    .SetTraitID(TraitID.ArmorAlphaAlpha)
                    .SetName(TraitID.ArmorAlphaAlpha.ToString())
                    .SetRarity(Rarity.Common)
                    .SetTraitType(TraitType.ArmorAlpha)
                    .Build()
            },
            {
                TraitID.CabinAlphaAlpha,
                TraitModelConstants.Builder.Get()
                    .SetTraitID(TraitID.CabinAlphaAlpha)
                    .SetName(TraitID.CabinAlphaAlpha.ToString())
                    .SetRarity(Rarity.Common)
                    .SetTraitType(TraitType.CabinAlpha)
                    .Build()
            },
            {
                TraitID.EngineAlphaAlpha,
                TraitModelConstants.Builder.Get()
                    .SetTraitID(TraitID.EngineAlphaAlpha)
                    .SetName(TraitID.EngineAlphaAlpha.ToString())
                    .SetRarity(Rarity.Common)
                    .SetTraitType(TraitType.EngineAlpha)
                    .Build()
            },
            {
                TraitID.WeaponAlphaAlpha,
                TraitModelConstants.Builder.Get()
                    .SetTraitID(TraitID.WeaponAlphaAlpha)
                    .SetName(TraitID.WeaponAlphaAlpha.ToString())
                    .SetRarity(Rarity.Common)
                    .SetTraitType(TraitType.WeaponAlpha)
                    .Build()
            },
        };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="traitId"></param>
        /// <returns></returns>
        public static Optional<ITraitModelConstants> GetConstants(TraitID traitId)
        {
            return (IDModelConstants.ContainsKey(traitId))
                ? Optional<ITraitModelConstants>.Of(IDModelConstants[traitId])
                : Optional<ITraitModelConstants>.Empty();
        }
    }
}