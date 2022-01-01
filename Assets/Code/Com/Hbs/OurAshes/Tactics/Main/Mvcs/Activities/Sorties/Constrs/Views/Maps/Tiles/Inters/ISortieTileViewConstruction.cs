using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.Skins;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Views.Maps.Tiles.Inters
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