using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Constants;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Fields.Constants
{
    /// <summary>
    /// Field Details Panel Constants
    /// </summary>
    public class PanelConstants
    {
        public static readonly float COORDS_X = 0;
        public static readonly float INFO_SIZE_X = DetailsPanelConstants.Fields.Vectors.SIZE.X / 4;
        public static readonly float SIZE_Y = 1;
        public static readonly Vector2 INFO_SIZE = new Vector2(INFO_SIZE_X, SIZE_Y);

        public class PopUps
        {
            public static readonly Vector2 SIZE = Vector2.One;
            public static readonly Vector2 COORDS = new Vector2(0, 1);
        }

        public class IDs
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Fields.Vectors.SIZE.Y - 1;
            public static readonly float TEXT_COORDS_X = 0;
            public static readonly float BUTTON_COORDS_X = INFO_SIZE_X;
            public static readonly Vector2 TEXT_COORDS = new Vector2(TEXT_COORDS_X, COORDS_Y);
            public static readonly Vector2 BUTTON_COORDS = new Vector2(BUTTON_COORDS_X, COORDS_Y);
        }

        public class Biomes
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Fields.Vectors.SIZE.Y - 1;
            public static readonly float TEXT_COORDS_X = 2 * INFO_SIZE_X;
            public static readonly float BUTTON_COORDS_X = 3 * INFO_SIZE_X;
            public static readonly Vector2 TEXT_COORDS = new Vector2(TEXT_COORDS_X, COORDS_Y);
            public static readonly Vector2 BUTTON_COORDS = new Vector2(BUTTON_COORDS_X, COORDS_Y);
        }

        public class Sizes
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Fields.Vectors.SIZE.Y - 2;
            public static readonly float TEXT_COORDS_X = 0;
            public static readonly float BUTTON_COORDS_X = INFO_SIZE_X;
            public static readonly Vector2 TEXT_COORDS = new Vector2(TEXT_COORDS_X, COORDS_Y);
            public static readonly Vector2 BUTTON_COORDS = new Vector2(BUTTON_COORDS_X, COORDS_Y);
        }

        public class Shapes
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Fields.Vectors.SIZE.Y - 2;
            public static readonly float TEXT_COORDS_X = 2 * INFO_SIZE_X;
            public static readonly float BUTTON_COORDS_X = 3 * INFO_SIZE_X;
            public static readonly Vector2 TEXT_COORDS = new Vector2(TEXT_COORDS_X, COORDS_Y);
            public static readonly Vector2 BUTTON_COORDS = new Vector2(BUTTON_COORDS_X, COORDS_Y);
        }
    }
}