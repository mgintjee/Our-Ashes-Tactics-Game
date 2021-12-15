using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.Skins;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Sorties.Tiles.Views.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Sorties.Tiles.Views.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Sorties.Tiles.Views.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class SortieTileViewConstantsManager
    {
        private static readonly IDictionary<SortieTileID, ISortieTileViewConstants> IDViewConstants =
            new Dictionary<SortieTileID, ISortieTileViewConstants>()
            {
                {
                    SortieTileID.Forest,
                    SortieTileViewConstants.Builder.Get()
                    .SetSortieTileID(SortieTileID.Forest)
                    .SetSortieTileSkins(new HashSet<SortieTileSkin>(){SortieTileSkin.ForestAlpha })
                    .Build()
                },
                {
                    SortieTileID.Mountain,
                    SortieTileViewConstants.Builder.Get()
                    .SetSortieTileID(SortieTileID.Mountain)
                    .SetSortieTileSkins(new HashSet<SortieTileSkin>(){SortieTileSkin.MountainAlpha })
                    .Build()
                },
                {
                    SortieTileID.Road,
                    SortieTileViewConstants.Builder.Get()
                    .SetSortieTileID(SortieTileID.Road)
                    .SetSortieTileSkins(new HashSet<SortieTileSkin>(){SortieTileSkin.RoadAlpha })
                    .Build()
                },
                {
                    SortieTileID.Steppe,
                    SortieTileViewConstants.Builder.Get()
                    .SetSortieTileID(SortieTileID.Steppe)
                    .SetSortieTileSkins(new HashSet<SortieTileSkin>(){SortieTileSkin.SteppeAlpha })
                    .Build()
                },
                {
                    SortieTileID.Water,
                    SortieTileViewConstants.Builder.Get()
                    .SetSortieTileID(SortieTileID.Water)
                    .SetSortieTileSkins(new HashSet<SortieTileSkin>(){SortieTileSkin.WaterAlpha })
                    .Build()
                },
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="sortieTileID"></param>
        /// <returns></returns>
        public static Optional<ISortieTileViewConstants> GetConstants(SortieTileID sortieTileID)
        {
            return (IDViewConstants.ContainsKey(sortieTileID))
                ? Optional<ISortieTileViewConstants>.Of(IDViewConstants[sortieTileID])
                : Optional<ISortieTileViewConstants>.Empty();
        }
    }
}