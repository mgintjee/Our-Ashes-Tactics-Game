using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Biomes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public class AlphaFieldDetailsImpl
        : FieldDetailsImpl
    {
        private static readonly FieldID FIELD_ID = FieldID.Alpha;
        private static readonly FieldBiome FIELD_BIOME = FieldBiome.Sunny;
        private static readonly FieldShape FIELD_SHAPE = FieldShape.Hexagon;
        private static readonly FieldSize FIELD_SIZE = FieldSize.Medium;
        private static readonly ISet<ITileDetails> TILE_DETAILS = BuildTileDetails();

        public AlphaFieldDetailsImpl()
            : base(FIELD_ID, FIELD_BIOME, FIELD_SHAPE, FIELD_SIZE, TILE_DETAILS)
        {
        }

        private static ISet<ITileDetails> BuildTileDetails()
        {
            ISet<ITileDetails> tileDetails = new HashSet<ITileDetails>();
            return tileDetails;
        }
    }
}