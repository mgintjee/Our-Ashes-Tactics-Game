using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Constants;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Combatants.Constants
{
    /// <summary>
    /// Field Details Panel Constants
    /// </summary>
    public class PanelConstants
    {
        public static readonly float COORDS_X = 0;
        public static readonly float SIZE_X = DetailsPanelConstants.Combatant.Vectors.SIZE.X;
        public static readonly float SIZE_Y = 1;
        public static readonly Vector2 SIZE = new Vector2(SIZE_X, SIZE_Y);

        public class CombatantIDs
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Combatant.Vectors.SIZE.Y - 1;
            public static readonly Vector2 COORDS = new Vector2(COORDS_X, COORDS_Y);
        }

        public class ModelIDs
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Combatant.Vectors.SIZE.Y - 2;
            public static readonly Vector2 COORDS = new Vector2(COORDS_X, COORDS_Y);
        }

        public class ArmorGearIDs
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Combatant.Vectors.SIZE.Y - 3;
            public static readonly Vector2 COORDS = new Vector2(COORDS_X, COORDS_Y);
        }

        public class EngineGearIDs
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Combatant.Vectors.SIZE.Y - 4;
            public static readonly Vector2 COORDS = new Vector2(COORDS_X, COORDS_Y);
        }

        public class WeaponGearIDList
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Combatant.Vectors.SIZE.Y - 5;
            public static readonly float HEADER_SIZE_X = 1;
            public static readonly float HEADER_COORDS_X = 0;
            public static readonly Vector2 HEADER_SIZE = new Vector2(HEADER_SIZE_X, SIZE_Y);
            public static readonly Vector2 HEADER_COORDS = new Vector2(HEADER_COORDS_X, COORDS_Y);
            public static readonly float LIST_SIZE_X = 3;
            public static readonly float LIST_COORDS_X = 1;
            public static readonly Vector2 LIST_SIZE = new Vector2(LIST_SIZE_X, SIZE_Y);
            public static readonly Vector2 LIST_COORDS = new Vector2(LIST_COORDS_X, COORDS_Y);
            public static readonly float BUTTONS_SIZE_X = 2;
            public static readonly float BUTTONS_COORDS_X = 4;
            public static readonly Vector2 BUTTONS_SIZE = new Vector2(BUTTONS_SIZE_X, SIZE_Y);
            public static readonly Vector2 BUTTONS_COORDS = new Vector2(BUTTONS_COORDS_X, COORDS_Y);
        }

        public class WeaponGearIDSpinner
        {
            public static readonly float COORDS_Y = DetailsPanelConstants.Combatant.Vectors.SIZE.Y - 6;
            public static readonly Vector2 COORDS = new Vector2(COORDS_X, COORDS_Y);
        }
    }
}