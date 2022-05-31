using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Constants;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Phalanxes.Constants
{
    /// <summary>
    /// Phalanx Details Panel Constants
    /// </summary>
    public class PanelConstants
    {
        public static readonly float COORDS_X = 0;
        public static readonly float SIZE_X = DetailsPanelConstants.Phalanxes.Vectors.SIZE.X;
        public static readonly float SIZE_Y = 1;
        public static readonly Vector2 SIZE = new Vector2(SIZE_X, SIZE_Y);

        public class PhalanxSpinners
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Phalanxes.Vectors.SIZE.Y - 1;
            public static readonly Vector2 COORDS = new Vector2(COORDS_X, COORDS_Y);
        }

        public class CombatantIDLists
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Phalanxes.Vectors.SIZE.Y - 2;
            public class Headers
            {
                public static readonly float HEADER_SIZE_X = 1;
                public static readonly float HEADER_COORDS_X = 0;
                public static readonly Vector2 HEADER_SIZE = new Vector2(HEADER_SIZE_X, SIZE_Y);
                public static readonly Vector2 HEADER_COORDS = new Vector2(HEADER_COORDS_X, COORDS_Y);
            }

            public class Lists
            {

                public static readonly float LIST_SIZE_X = 3;
                public static readonly float LIST_COORDS_X = HEADER_SIZE_X;
                public static readonly Vector2 LIST_SIZE = new Vector2(LIST_SIZE_X, SIZE_Y);
                public static readonly Vector2 LIST_COORDS = new Vector2(LIST_COORDS_X, COORDS_Y);
            }

            public class Buttons
            {
                public static readonly float BUTTONS_SIZE_X = 2;
                public static readonly float BUTTONS_COORDS_X = LIST_SIZE_X + HEADER_SIZE_X;
                public static readonly Vector2 BUTTONS_SIZE = new Vector2(BUTTONS_SIZE_X, SIZE_Y);
                public static readonly Vector2 BUTTONS_COORDS = new Vector2(BUTTONS_COORDS_X, COORDS_Y);

            }
            public static readonly float HEADER_SIZE_X = 1;
            public static readonly float HEADER_COORDS_X = 0;
            public static readonly float LIST_SIZE_X = 3;
            public static readonly float LIST_COORDS_X = HEADER_SIZE_X;
            public static readonly float BUTTONS_SIZE_X = 2;
            public static readonly float BUTTONS_COORDS_X = LIST_SIZE_X + HEADER_SIZE_X;
            public static readonly Vector2 HEADER_SIZE = new Vector2(HEADER_SIZE_X, SIZE_Y);
            public static readonly Vector2 HEADER_COORDS = new Vector2(HEADER_COORDS_X, COORDS_Y);
            public static readonly Vector2 LIST_SIZE = new Vector2(LIST_SIZE_X, SIZE_Y);
            public static readonly Vector2 LIST_COORDS = new Vector2(LIST_COORDS_X, COORDS_Y);
            public static readonly Vector2 BUTTONS_SIZE = new Vector2(BUTTONS_SIZE_X, SIZE_Y);
            public static readonly Vector2 BUTTONS_COORDS = new Vector2(BUTTONS_COORDS_X, COORDS_Y);
        }

        public class CombatantSpinners
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Phalanxes.Vectors.SIZE.Y - 3;
            public static readonly Vector2 COORDS = new Vector2(COORDS_X, COORDS_Y);
        }
    }
}