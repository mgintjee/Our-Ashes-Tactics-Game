using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.Attributes.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.IDs;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Sorties.Tiles.Models.Interfaces
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