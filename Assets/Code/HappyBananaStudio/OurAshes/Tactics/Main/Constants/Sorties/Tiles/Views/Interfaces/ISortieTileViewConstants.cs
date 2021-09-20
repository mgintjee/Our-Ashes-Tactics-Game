using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Sorties.Maps.Tiles.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Sorties.Maps.Tiles.Skins;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Sorties.Tiles.Views.Interfaces
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