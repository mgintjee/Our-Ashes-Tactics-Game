using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Constants;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Sorties.Constants
{
    /// <summary>
    /// Sortie Details Panel Constants
    /// </summary>
    public class PanelConstants
    {
        public static readonly float COUNTER_SIZE_X = DetailsPanelConstants.Sorties.Vectors.SIZE.X / 2;
        public static readonly float SIZE_Y = 1;
        public static readonly Vector2 COUNTER_SIZE = new Vector2(COUNTER_SIZE_X, SIZE_Y);

        public class Factions
        {
            public static readonly float COORDS_X = 0;
            public static readonly float COORDS_Y = DetailsPanelConstants.Sorties.Vectors.SIZE.Y - 1;
            public static readonly Vector2 COORDS = new Vector2(COORDS_X, COORDS_Y);
        }

        public class Phalanxes
        {
            public static readonly float COORDS_X = 1;
            public static readonly float COORDS_Y = DetailsPanelConstants.Sorties.Vectors.SIZE.Y - 1;
            public static readonly Vector2 COORDS = new Vector2(COORDS_X, COORDS_Y);
        }

        public class Combatants
        {
            public static readonly float COORDS_X = 0;
            public static readonly float COORDS_Y = DetailsPanelConstants.Sorties.Vectors.SIZE.Y - 2;
            public static readonly Vector2 COORDS = new Vector2(COORDS_X, COORDS_Y);
        }

        public class Fields
        {
            public static readonly float COORDS_X = 1;
            public static readonly float COORDS_Y = DetailsPanelConstants.Sorties.Vectors.SIZE.Y - 2;
            public static readonly Vector2 COORDS = new Vector2(COORDS_X, COORDS_Y);
        }
    }
}