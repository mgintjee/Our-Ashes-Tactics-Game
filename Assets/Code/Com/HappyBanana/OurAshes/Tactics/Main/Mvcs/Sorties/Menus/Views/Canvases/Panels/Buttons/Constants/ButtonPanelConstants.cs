using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Views.Canvases.Panels.Buttons.Constants
{
    /// <summary>
    /// Button Panel Constants
    /// </summary>
    public class ButtonPanelConstants
    {
        public static readonly int BUTTON_PANEL_X = 1;
        public static readonly int BUTTON_PANEL_Y = 5;
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