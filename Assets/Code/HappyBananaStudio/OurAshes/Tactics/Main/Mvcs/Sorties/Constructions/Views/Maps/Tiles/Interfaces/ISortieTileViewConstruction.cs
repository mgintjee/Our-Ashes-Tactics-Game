﻿namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Maps.Tiles.Interfaces
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