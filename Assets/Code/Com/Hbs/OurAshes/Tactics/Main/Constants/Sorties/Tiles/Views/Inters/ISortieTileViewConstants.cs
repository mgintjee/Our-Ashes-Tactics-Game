using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.Skins;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Sorties.Tiles.Views.Inters
{
    /// <summary>
    /// Sortie Tile View Constants Interface
    /// </summary>
    public interface ISortieTileViewConstants
    {
        SortieTileID GetSortieTileID();

        ISet<SortieTileSkin> GetSortieTileSkins();
    }
}