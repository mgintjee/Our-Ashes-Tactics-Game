﻿using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Maps.Tiles.Interfaces
{
    /// <summary>
    /// Sortie Tile Model Construction Interface
    /// </summary>
    public interface ISortieTileModelConstruction
    {
        ICubeCoordinates GetCubeCoordinates();

        SortieTileID GetSortieTileID();

        CombatantCallSign GetCombatantCallSign();
    }
}