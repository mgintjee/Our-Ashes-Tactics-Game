using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Constants;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Combatants.Constants
{
    /// <summary>
    /// Field Details Panel Constants
    /// </summary>
    public class CombatantDetailsPanelConstants
    {
        public static readonly int TEXT_COLUMN = 0;
        public static readonly int BUTTONS_COLUMN = 1;
        public static readonly float COMBATANT_ID_ROW = DetailsPanelConstants.PHALANX_PANEL_DIMENSIONS.Y - 1;
        public static readonly Vector2 TEXT_SIZE = DetailsPanelConstants.PHALANX_PANEL_DIMENSIONS * new Vector2(1 / 2f, 1 / 6f);
        public static readonly Vector2 COMBATANT_ID_TEXT_COORDS = new Vector2(TEXT_COLUMN, COMBATANT_ID_ROW);
        public static readonly Vector2 COMBATANT_ID_BUTTONS_COORDS = new Vector2(BUTTONS_COLUMN, COMBATANT_ID_ROW);
    }
}