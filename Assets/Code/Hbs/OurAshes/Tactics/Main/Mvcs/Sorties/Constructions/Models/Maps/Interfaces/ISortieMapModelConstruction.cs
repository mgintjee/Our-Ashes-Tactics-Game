﻿using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Maps.Tiles.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Maps.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ISortieMapModelConstruction
    {
        ISet<ISortieTileModelConstruction> GetSortieTileModelConstructions();
    }
}