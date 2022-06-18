using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Constants;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Phalanxes.Constants
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
        public static readonly float INFO_SIZE_X = DetailsPanelConstants.Phalanxes.Vectors.SIZE.X / 4;
        public static readonly Vector2 INFO_SIZE = new Vector2(INFO_SIZE_X, SIZE_Y);

        public class IDs
        {
            public static readonly float TEXT_COORDS_X = 0;
            public static readonly float BUTTON_COORDS_X = INFO_SIZE_X;
            public static readonly float COORDS_Y = DetailsPanelConstants.Phalanxes.Vectors.SIZE.Y - 1;
            public static readonly Vector2 TEXT_COORDS = new Vector2(TEXT_COORDS_X, COORDS_Y);
            public static readonly Vector2 BUTTON_COORDS = new Vector2(BUTTON_COORDS_X, COORDS_Y);
            public static readonly Vector2 COORDS = new Vector2(COORDS_X, COORDS_Y);
        }

        public class Icons
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Phalanxes.Vectors.SIZE.Y - 1;
            public static readonly float TEXT_COORDS_X = 2 * INFO_SIZE_X;
            public static readonly float BUTTON_COORDS_X = 3 * INFO_SIZE_X;
            public static readonly Vector2 TEXT_COORDS = new Vector2(TEXT_COORDS_X, COORDS_Y);
            public static readonly Vector2 BUTTON_COORDS = new Vector2(BUTTON_COORDS_X, COORDS_Y);
        }

        public class CombatantHeader
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Phalanxes.Vectors.SIZE.Y - 2;
            public static readonly float TEXT_COORDS_X = 0;
            public static readonly float BUTTON_COORDS_X = INFO_SIZE_X;
            public static readonly Vector2 TEXT_COORDS = new Vector2(TEXT_COORDS_X, COORDS_Y);
            public static readonly Vector2 MINUS_BUTTON_COORDS = new Vector2(2 * INFO_SIZE_X, COORDS_Y);
            public static readonly Vector2 ADD_BUTTON_COORDS = new Vector2(3 * INFO_SIZE_X, COORDS_Y);
            public static readonly Vector2 TEXT_SIZE = INFO_SIZE * new Vector2(2, 1);
        }

        public class CombatantList
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Phalanxes.Vectors.SIZE.Y - 3;
            public static readonly float COORDS_X = 0;
            public static readonly float SIZE_X = DetailsPanelConstants.Phalanxes.Vectors.SIZE.Y;
            public static readonly float SIZE_Y = 1;
            public static readonly Vector2 COORDS = new Vector2(COORDS_X, COORDS_Y);
            public static readonly Vector2 SIZE = new Vector2(SIZE_X, SIZE_Y);
        }

        public class Powers
        {
            public static readonly float COORDS_Y = 0;
            public static readonly float COORDS_X = 0;
            public static readonly float SIZE_X = DetailsPanelConstants.Phalanxes.Vectors.SIZE.X;
            public static readonly float SIZE_Y = 1;
            public static readonly Vector2 COORDS = new Vector2(COORDS_X, COORDS_Y);
            public static readonly Vector2 SIZE = new Vector2(SIZE_X, SIZE_Y);
        }
    }
}