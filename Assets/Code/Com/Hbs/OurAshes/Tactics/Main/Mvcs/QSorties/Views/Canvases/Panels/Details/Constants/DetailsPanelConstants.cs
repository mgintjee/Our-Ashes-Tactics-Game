using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Constants
{
    /// <summary>
    /// Details Panel Constants
    /// </summary>
    public class DetailsPanelConstants
    {
        public class Field
        {
            public class Floats
            {
                // Field Panel
                public static readonly float SIZE_X = 2;
                public static readonly float SIZE_Y = 4;

            }
            public class Vectors
            {
                public static readonly Vector2 SIZE =
                    new Vector2(Floats.SIZE_X, Floats.SIZE_Y);

            }
        }
        public class Floats
        {
            // Faction Panel
            public static readonly float FACTION_PANEL_SIZE_X = 5;
            public static readonly float FACTION_PANEL_SIZE_Y = 4;
            // Phalanx Panel
            public static readonly float PHALANX_PANEL_SIZE_X = 2;
            public static readonly float PHALANX_PANEL_SIZE_Y = 6;
        }

        public class Vectors
        {
            public static readonly Vector2 FACTION_PANEL_DIMENSIONS =
                new Vector2(Floats.FACTION_PANEL_SIZE_X, Floats.FACTION_PANEL_SIZE_Y);
            public static readonly Vector2 PHALANX_PANEL_DIMENSIONS =
                new Vector2(Floats.PHALANX_PANEL_SIZE_X, Floats.PHALANX_PANEL_SIZE_Y);
        }
    }
}