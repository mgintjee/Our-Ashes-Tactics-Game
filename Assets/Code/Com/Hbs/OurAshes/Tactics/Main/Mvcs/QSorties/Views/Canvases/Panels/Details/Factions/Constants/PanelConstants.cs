﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Constants;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Factions.Constants
{
    /// <summary>
    /// Field Details Panel Constants
    /// </summary>
    public class PanelConstants
    {
        public static readonly float COORDS_X = 0;
        public static readonly float SIZE_X = DetailsPanelConstants.Faction.Vectors.SIZE.X;
        public static readonly float SIZE_Y = 1;
        public static readonly Vector2 SIZE = new Vector2(SIZE_X, SIZE_Y);

        public class FactionID
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Faction.Vectors.SIZE.Y - 1;
            public static readonly Vector2 COORDS = new Vector2(COORDS_X, COORDS_Y);
        }
    }
}