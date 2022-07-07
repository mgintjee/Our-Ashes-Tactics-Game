using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Constants;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Units.Constants
{
    /// <summary>
    /// Field Details Panel Constants
    /// </summary>
    public class PanelConstants
    {
        public static readonly float COORDS_X = 0;
        public static readonly float SIZE_X = DetailsPanelConstants.Units.Vectors.SIZE.X;
        public static readonly float SIZE_Y = 1;
        public static readonly Vector2 SIZE = new Vector2(SIZE_X, SIZE_Y);
        public static readonly float INFO_SIZE_X = DetailsPanelConstants.Units.Vectors.SIZE.X / 4;
        public static readonly Vector2 INFO_SIZE = new Vector2(INFO_SIZE_X, SIZE_Y);

        public class IDs
        {
            public static readonly float TEXT_COORDS_X = 0;
            public static readonly float BUTTON_COORDS_X = INFO_SIZE_X;
            public static readonly float COORDS_Y = DetailsPanelConstants.Units.Vectors.SIZE.Y - 1;
            public static readonly Vector2 TEXT_COORDS = new Vector2(TEXT_COORDS_X, COORDS_Y);
            public static readonly Vector2 BUTTON_COORDS = new Vector2(BUTTON_COORDS_X, COORDS_Y);
            public static readonly Vector2 COORDS = new Vector2(COORDS_X, COORDS_Y);
        }

        public class Models
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Units.Vectors.SIZE.Y - 1;
            public static readonly float TEXT_COORDS_X = 2 * INFO_SIZE_X;
            public static readonly float BUTTON_COORDS_X = 3 * INFO_SIZE_X;
            public static readonly Vector2 TEXT_COORDS = new Vector2(TEXT_COORDS_X, COORDS_Y);
            public static readonly Vector2 BUTTON_COORDS = new Vector2(BUTTON_COORDS_X, COORDS_Y);
        }

        public class Armors
        {
            public static readonly float TEXT_COORDS_X = 0;
            public static readonly float BUTTON_COORDS_X = INFO_SIZE_X;
            public static readonly float COORDS_Y = DetailsPanelConstants.Units.Vectors.SIZE.Y - 2;
            public static readonly Vector2 TEXT_COORDS = new Vector2(TEXT_COORDS_X, COORDS_Y);
            public static readonly Vector2 BUTTON_COORDS = new Vector2(BUTTON_COORDS_X, COORDS_Y);
            public static readonly Vector2 COORDS = new Vector2(COORDS_X, COORDS_Y);
        }

        public class Engines
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Units.Vectors.SIZE.Y - 2;
            public static readonly float TEXT_COORDS_X = 2 * INFO_SIZE_X;
            public static readonly float BUTTON_COORDS_X = 3 * INFO_SIZE_X;
            public static readonly Vector2 TEXT_COORDS = new Vector2(TEXT_COORDS_X, COORDS_Y);
            public static readonly Vector2 BUTTON_COORDS = new Vector2(BUTTON_COORDS_X, COORDS_Y);
        }
        public class Cabins
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Units.Vectors.SIZE.Y - 2;
            public static readonly float TEXT_COORDS_X = 3 * INFO_SIZE_X;
            public static readonly float BUTTON_COORDS_X = 4 * INFO_SIZE_X;
            public static readonly Vector2 TEXT_COORDS = new Vector2(TEXT_COORDS_X, COORDS_Y);
            public static readonly Vector2 BUTTON_COORDS = new Vector2(BUTTON_COORDS_X, COORDS_Y);
        }

        public class WeaponHeader
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Units.Vectors.SIZE.Y - 3;
            public static readonly float TEXT_COORDS_X = 0;
            public static readonly float BUTTON_COORDS_X = INFO_SIZE_X;
            public static readonly Vector2 TEXT_COORDS = new Vector2(TEXT_COORDS_X, COORDS_Y);
            public static readonly Vector2 MINUS_BUTTON_COORDS = new Vector2(2 * INFO_SIZE_X, COORDS_Y);
            public static readonly Vector2 ADD_BUTTON_COORDS = new Vector2(3 * INFO_SIZE_X, COORDS_Y);
            public static readonly Vector2 TEXT_SIZE = INFO_SIZE * new Vector2(2, 1);
        }

        public class WeaponList
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Units.Vectors.SIZE.Y - 4;
            public static readonly float COORDS_X = 0;
            public static readonly float SIZE_X = DetailsPanelConstants.Units.Vectors.SIZE.X;
            public static readonly float SIZE_Y = 1;
            public static readonly Vector2 COORDS = new Vector2(COORDS_X, COORDS_Y);
            public static readonly Vector2 SIZE = new Vector2(SIZE_X, SIZE_Y);
        }

        public class Powers
        {
            public static readonly float COORDS_Y = 0;
            public static readonly float COORDS_X = 0;
            public static readonly float SIZE_X = DetailsPanelConstants.Units.Vectors.SIZE.X * 3 / 4;
            public static readonly float SIZE_Y = 1;
            public static readonly Vector2 COORDS = new Vector2(COORDS_X, COORDS_Y);
            public static readonly Vector2 SIZE = new Vector2(SIZE_X, SIZE_Y);
        }

        public class Stats
        {
            public static readonly float COORDS_Y = 0;
            public static readonly float COORDS_X = Powers.SIZE_X;
            public static readonly float SIZE_X = DetailsPanelConstants.Units.Vectors.SIZE.X / 4;
            public static readonly float SIZE_Y = 1;
            public static readonly Vector2 COORDS = new Vector2(COORDS_X, COORDS_Y);
            public static readonly Vector2 SIZE = new Vector2(SIZE_X, SIZE_Y);
        }
    }
}