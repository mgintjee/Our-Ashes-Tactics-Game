using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sorties.Maps.Tiles.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sorties.Maps.Tiles.IDs;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Sorties.Tiles.Models.Interfaces
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