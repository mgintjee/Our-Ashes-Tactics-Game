using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.Skins;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Maps.Tiles.Interfaces
{
    /// <summary>
    /// Sortie Tile View Construction Interface
    /// </summary>
    public interface ISortieTileViewConstruction
    {
        SortieTileSkin GetSortieTileSkin();

        ICubeCoordinates GetCubeCoordinates();
    }
}