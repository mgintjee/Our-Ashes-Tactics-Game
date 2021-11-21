using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.Attributes.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Sorties.Tiles.Models.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Sorties.Tiles.Models.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Sorties.Tiles.Models.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class SortieTileModelConstantsManager
    {
        private static readonly IDictionary<SortieTileID, ISortieTileModelConstants> IDModelConstants =
            new Dictionary<SortieTileID, ISortieTileModelConstants>()
            {
                {
                    SortieTileID.Forest,
                    SortieTileModelConstants.Builder.Get()
                    .SetSortieTileID(SortieTileID.Forest)
                    .SetSortieTileAttributes(SortieTileAttributes.Builder.Get()
                        .SetFireCost(15)
                        .SetMoveCost(2)
                        .Build())
                    .Build()
                },
                {
                    SortieTileID.Mountain,
                    SortieTileModelConstants.Builder.Get()
                    .SetSortieTileID(SortieTileID.Mountain)
                    .SetSortieTileAttributes(SortieTileAttributes.Builder.Get()
                        .SetFireCost(15)
                        .SetMoveCost(5)
                        .Build())
                    .Build()
                },
                {
                    SortieTileID.Road,
                    SortieTileModelConstants.Builder.Get()
                    .SetSortieTileID(SortieTileID.Road)
                    .SetSortieTileAttributes(SortieTileAttributes.Builder.Get()
                        .SetFireCost(5)
                        .SetMoveCost(1)
                        .Build())
                    .Build()
                },
                {
                    SortieTileID.Steppe,
                    SortieTileModelConstants.Builder.Get()
                    .SetSortieTileID(SortieTileID.Steppe)
                    .SetSortieTileAttributes(SortieTileAttributes.Builder.Get()
                        .SetFireCost(5)
                        .SetMoveCost(2)
                        .Build())
                    .Build()
                },
                {
                    SortieTileID.Water,
                    SortieTileModelConstants.Builder.Get()
                    .SetSortieTileID(SortieTileID.Water)
                    .SetSortieTileAttributes(SortieTileAttributes.Builder.Get()
                        .SetFireCost(5)
                        .SetMoveCost(3)
                        .Build())
                    .Build()
                },
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sortieTileID"></param>
        /// <returns></returns>
        public static Optional<ISortieTileModelConstants> GetConstants(SortieTileID sortieTileID)
        {
            return (IDModelConstants.ContainsKey(sortieTileID))
                ? Optional<ISortieTileModelConstants>.Of(IDModelConstants[sortieTileID])
                : Optional<ISortieTileModelConstants>.Empty();
        }
    }
}