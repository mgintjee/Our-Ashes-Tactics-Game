using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Constants;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Factions.Constants
{
    /// <summary>
    /// Field Details Panel Constants
    /// </summary>
    public class PanelConstants
    {
        public class Carousel
        {
            public class Floats
            {
                public static readonly float TEXTS_SIZE_X = 3 / DetailsPanelConstants.Floats.FACTION_PANEL_SIZE_X;
                public static readonly float TEXTS_COORDS_X = 0;
                public static readonly float BUTTONS_SIZE_X = 2 / DetailsPanelConstants.Floats.FACTION_PANEL_SIZE_X;
                public static readonly float BUTTONS_COORDS_X = 3;
                public static readonly float SIZE_Y = 1 / DetailsPanelConstants.Floats.FACTION_PANEL_SIZE_Y;
                public static readonly float COORDS_Y = DetailsPanelConstants.Floats.FACTION_PANEL_SIZE_Y - 1;
            }

            public class Vectors
            {
                public static readonly Vector2 TEXT_SIZE = DetailsPanelConstants.Vectors.FACTION_PANEL_DIMENSIONS *
                    new Vector2(Floats.TEXTS_SIZE_X, Floats.SIZE_Y);

                public static readonly Vector2 TEXT_COORDS =
                    new Vector2(Floats.TEXTS_COORDS_X, Floats.COORDS_Y);

                public static readonly Vector2 BUTTONS_SIZE = DetailsPanelConstants.Vectors.FACTION_PANEL_DIMENSIONS *
                    new Vector2(Floats.BUTTONS_SIZE_X, Floats.SIZE_Y);

                public static readonly Vector2 BUTTONS_COORDS =
                    new Vector2(Floats.BUTTONS_COORDS_X, Floats.COORDS_Y);
            }
        }

        public class SelectedFaction
        {
            public class Floats
            {
                public static readonly float SIZE_X = 2.5f / DetailsPanelConstants.Floats.FACTION_PANEL_SIZE_X;
                public static readonly float SIZE_Y = 1 / DetailsPanelConstants.Floats.FACTION_PANEL_SIZE_Y;
                public static readonly float COORDS_Y = DetailsPanelConstants.Floats.FACTION_PANEL_SIZE_Y - 2;
                public static readonly float TEXTS_COORDS_X = 0;
                public static readonly float BUTTONS_COORDS_X = 2.5f;
            }

            public class Vectors
            {
                public static readonly Vector2 TEXTS_SIZE = DetailsPanelConstants.Vectors.FACTION_PANEL_DIMENSIONS *
                    new Vector2(Floats.SIZE_X, Floats.SIZE_Y);

                public static readonly Vector2 TEXTS_COORDS =
                    new Vector2(Floats.TEXTS_COORDS_X, Floats.COORDS_Y);

                public static readonly Vector2 BUTTONS_SIZE = DetailsPanelConstants.Vectors.FACTION_PANEL_DIMENSIONS *
                    new Vector2(Floats.SIZE_X, Floats.SIZE_Y);

                public static readonly Vector2 BUTTONS_COORDS =
                    new Vector2(Floats.BUTTONS_COORDS_X, Floats.COORDS_Y);
            }
        }

        public class PhalanxCallSigns
        {
            public class Floats
            {
                public static readonly float HEADER_SIZE_X = 1 / DetailsPanelConstants.Floats.FACTION_PANEL_SIZE_X;
                public static readonly float HEADER_COORDS_X = 0;
                public static readonly float LIST_SIZE_X = 4 / DetailsPanelConstants.Floats.FACTION_PANEL_SIZE_X ;
                public static readonly float LIST_COORDS_X = 1;
                public static readonly float SIZE_Y = 1 / DetailsPanelConstants.Floats.FACTION_PANEL_SIZE_Y;
                public static readonly float COORDS_Y = DetailsPanelConstants.Floats.FACTION_PANEL_SIZE_Y - 3;
            }

            public class Vectors
            {
                public static readonly Vector2 HEADER_SIZE = DetailsPanelConstants.Vectors.FACTION_PANEL_DIMENSIONS *
                    new Vector2(Floats.HEADER_SIZE_X, Floats.SIZE_Y);

                public static readonly Vector2 HEADER_COORDS =
                    new Vector2(Floats.HEADER_COORDS_X, Floats.COORDS_Y);

                public static readonly Vector2 LIST_SIZE = DetailsPanelConstants.Vectors.FACTION_PANEL_DIMENSIONS *
                    new Vector2(Floats.LIST_SIZE_X, Floats.SIZE_Y);

                public static readonly Vector2 LIST_COORDS =
                    new Vector2(Floats.LIST_COORDS_X, Floats.COORDS_Y);
            }
        }
    }
}