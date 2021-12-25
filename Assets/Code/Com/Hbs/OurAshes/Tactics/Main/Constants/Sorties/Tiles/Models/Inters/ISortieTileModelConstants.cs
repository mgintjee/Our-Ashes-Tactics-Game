using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.Attributes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.IDs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Sorties.Tiles.Models.Inters
{
    /// <summary>
    /// Sortie Tile Model Constants Interface
    /// </summary>
    public interface ISortieTileModelConstants
    {
        SortieTileID GetSortieTileID();

        ISortieTileAttributes GetSortieTileAttributes();
    }
}