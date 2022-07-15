using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Fields.Constants
{
    public class MiniFieldConstants
    {
        public static readonly int LEVEL = 1;
        public static readonly float ALPHA = 1f;
        public static readonly string BACK_NAME = "BackImage";
        public static readonly string MID_NAME = "MidImage";
        public static readonly string FORE_NAME = "ForeImage";
        public static ColorID BACK_COLOR_ID = ColorID.Gray;
        public static SpriteID TILE_SPRITE_ID = SpriteID.HexagonBorderless;

        public static readonly IWidgetGridSpec MINI_FIELD_SPEC = new WidgetGridSpecImpl()
            .SetCanvasGridCoords(Vector2.Zero)
            .SetCanvasGridSize(new Vector2(4, 3));
        public static readonly IWidgetGridSpec BACK_SPEC = new WidgetGridSpecImpl()
            .SetCanvasGridCoords(Vector2.Zero)
            .SetCanvasGridSize(Vector2.One);
        public static readonly IWidgetGridSpec MID_SPEC = new WidgetGridSpecImpl()
            .SetCanvasGridCoords(Vector2.One * 0.05f)
            .SetCanvasGridSize(Vector2.One * 0.9f);
        public static readonly IWidgetGridSpec FORE_SPEC = new WidgetGridSpecImpl()
            .SetCanvasGridCoords(Vector2.One * 0.1f)
            .SetCanvasGridSize(Vector2.One * 0.8f);
    }
}