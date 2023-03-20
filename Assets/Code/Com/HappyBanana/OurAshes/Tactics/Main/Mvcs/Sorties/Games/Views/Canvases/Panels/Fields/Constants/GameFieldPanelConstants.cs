using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Games.Views.Canvases.Panels.Fields.Constants
{
    /// <summary>
    /// Game Field Panel Constants
    /// </summary>
    public class GameFieldPanelConstants
    {
        public static readonly int PANEL_SIZE_X = 6;
        public static readonly int PANEL_SIZE_Y = 5;
        public static readonly int PANEL_COORDs_X = 2;
        public static readonly int PANEL_COORDS_Y = 0;
        public static readonly int BUTTON_PANEL_X = 6;
        public static readonly int BUTTON_PANEL_Y = 5;
        public static readonly Vector2 PANEL_SIZE = new Vector2(PANEL_SIZE_X, PANEL_SIZE_Y);
        public static readonly Vector2 PANEL_COORDS = new Vector2(PANEL_COORDs_X, PANEL_COORDS_Y);

        public static readonly IWidgetGridSpec WIDGET_GRID_SPEC = new WidgetGridSpecImpl()
            .SetCanvasGridCoords(PANEL_COORDS)
            .SetCanvasGridSize(PANEL_SIZE);

        public static readonly float BUTTON_Y_SIZE_RATIO = 1 / 6f;
        public static readonly Vector2 BUTTON_PANEL_SIZE = new Vector2(BUTTON_PANEL_X, BUTTON_PANEL_Y);
        public static readonly Vector2 BUTTON_SIZE = BUTTON_PANEL_SIZE * new Vector2(1, BUTTON_Y_SIZE_RATIO);
        public static readonly Vector2 BUTTON_FIELD_DETAILS_COORDS = BUTTON_PANEL_SIZE * new Vector2(0, 1 - BUTTON_Y_SIZE_RATIO);
        public static readonly Vector2 BUTTON_FACTION_DETAILS_COORDS = BUTTON_PANEL_SIZE * new Vector2(0, 1 - 2 * BUTTON_Y_SIZE_RATIO);
        public static readonly Vector2 BUTTON_PHALANX_DETAILS_COORDS = BUTTON_PANEL_SIZE * new Vector2(0, 1 - 3 * BUTTON_Y_SIZE_RATIO);
        public static readonly Vector2 BUTTON_COMBATANT_DETAILS_COORDS = BUTTON_PANEL_SIZE * new Vector2(0, 1 - 4 * BUTTON_Y_SIZE_RATIO);
        public static readonly Vector2 BUTTON_SORTIE_DETAILS_COORDS = BUTTON_PANEL_SIZE * new Vector2(0, 1 - 5 * BUTTON_Y_SIZE_RATIO);
        public static readonly Vector2 BUTTON_SORTIE_START_COORDS = new Vector2(0, 0);
    }
}