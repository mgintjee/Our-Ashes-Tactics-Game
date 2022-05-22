using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Constants;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Phalanxes.Constants
{
    /// <summary>
    /// Field Details Panel Constants
    /// </summary>
    public class PhalanxDetailsPanelConstants
    {
        public static readonly int TEXT_COLUMN = 0;
        public static readonly int BUTTONS_COLUMN = 1;
        public static readonly float ALPHA_ROW = DetailsPanelConstants.Vectors.PHALANX_PANEL_DIMENSIONS.Y - 1;
        public static readonly float BRAVO_ROW = DetailsPanelConstants.Vectors.PHALANX_PANEL_DIMENSIONS.Y - 2;
        public static readonly float CHARLIE_ROW = DetailsPanelConstants.Vectors.PHALANX_PANEL_DIMENSIONS.Y - 3;
        public static readonly float DELTA_ROW = DetailsPanelConstants.Vectors.PHALANX_PANEL_DIMENSIONS.Y - 4;
        public static readonly float ECHO_ROW = DetailsPanelConstants.Vectors.PHALANX_PANEL_DIMENSIONS.Y - 5;
        public static readonly float FOXTROT_ROW = DetailsPanelConstants.Vectors.PHALANX_PANEL_DIMENSIONS.Y - 6;
        public static readonly Vector2 TEXT_SIZE = DetailsPanelConstants.Vectors.PHALANX_PANEL_DIMENSIONS * new Vector2(1 / 2f, 1 / 6f);
        public static readonly Vector2 ALPHA_TEXT_COORDS = new Vector2(TEXT_COLUMN, ALPHA_ROW);
        public static readonly Vector2 BRAVO_TEXT_COORDS = new Vector2(TEXT_COLUMN, BRAVO_ROW);
        public static readonly Vector2 CHARLIE_TEXT_COORDS = new Vector2(TEXT_COLUMN, CHARLIE_ROW);
        public static readonly Vector2 DELTA_TEXT_COORDS = new Vector2(TEXT_COLUMN, DELTA_ROW);
        public static readonly Vector2 ECHO_TEXT_COORDS = new Vector2(TEXT_COLUMN, ECHO_ROW);
        public static readonly Vector2 FOXTROT_TEXT_COORDS = new Vector2(TEXT_COLUMN, FOXTROT_ROW);
        public static readonly Vector2 ALPHA_BUTTONS_COORDS = new Vector2(BUTTONS_COLUMN, ALPHA_ROW);
        public static readonly Vector2 BRAVO_BUTTONS_COORDS = new Vector2(BUTTONS_COLUMN, BRAVO_ROW);
        public static readonly Vector2 CHARLIE_BUTTONS_COORDS = new Vector2(BUTTONS_COLUMN, CHARLIE_ROW);
        public static readonly Vector2 DELTA_BUTTONS_COORDS = new Vector2(BUTTONS_COLUMN, DELTA_ROW);
        public static readonly Vector2 ECHO_BUTTONS_COORDS = new Vector2(BUTTONS_COLUMN, ECHO_ROW);
        public static readonly Vector2 FOXTROT_BUTTONS_COORDS = new Vector2(BUTTONS_COLUMN, FOXTROT_ROW);
    }
}