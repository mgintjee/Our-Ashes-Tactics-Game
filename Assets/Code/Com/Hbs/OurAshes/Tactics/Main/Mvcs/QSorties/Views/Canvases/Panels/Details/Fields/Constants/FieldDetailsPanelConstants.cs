using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Constants;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Fields.Constants
{
    /// <summary>
    /// Field Details Panel Constants
    /// </summary>
    public class FieldDetailsPanelConstants
    {
        public static readonly float FIELD_ID_Y = DetailsPanelConstants.Field.Vectors.SIZE.Y - 1;
        public static readonly float FIELD_BIOME_Y = DetailsPanelConstants.Field.Vectors.SIZE.Y - 2;
        public static readonly float FIELD_SIZE_Y = DetailsPanelConstants.Field.Vectors.SIZE.Y - 3;
        public static readonly float FIELD_SHAPE_Y = DetailsPanelConstants.Field.Vectors.SIZE.Y - 4;
        public static readonly Vector2 TEXT_SIZE = DetailsPanelConstants.Field.Vectors.SIZE * new Vector2(1 / 2f, 1 / 4f);
        public static readonly Vector2 FIELD_ID_TEXT_COORDS = new Vector2(0, FIELD_ID_Y);
        public static readonly Vector2 FIELD_ID_BUTTONS_COORDS = new Vector2(1, FIELD_ID_Y);
        public static readonly Vector2 FIELD_BIOME_TEXT_COORDS = new Vector2(0, FIELD_BIOME_Y);
        public static readonly Vector2 FIELD_SIZE_TEXT_COORDS = new Vector2(0, FIELD_SIZE_Y);
        public static readonly Vector2 FIELD_SHAPE_TEXT_COORDS = new Vector2(0, FIELD_SHAPE_Y);
        public static readonly Vector2 FIELD_BIOME_BUTTONS_COORDS = new Vector2(1, FIELD_BIOME_Y);
        public static readonly Vector2 FIELD_SIZE_BUTTONS_COORDS = new Vector2(1, FIELD_SIZE_Y);
        public static readonly Vector2 FIELD_SHAPE_BUTTONS_COORDS = new Vector2(1, FIELD_SHAPE_Y);
    }
}