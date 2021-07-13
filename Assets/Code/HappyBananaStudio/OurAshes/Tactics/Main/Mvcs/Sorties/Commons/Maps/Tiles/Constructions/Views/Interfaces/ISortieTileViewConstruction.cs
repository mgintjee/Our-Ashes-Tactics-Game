using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sorties.Maps.Tiles.Skins;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Constructions.Views.Interfaces
{
    /// <summary>
    /// Sortie Tile View Construction Interface
    /// </summary>
    public interface ISortieTileViewConstruction : IReport
    {
        SortieTileSkin GetSortieTileSkin();

        ICubeCoordinates GetCubeCoordinates();
    }
}