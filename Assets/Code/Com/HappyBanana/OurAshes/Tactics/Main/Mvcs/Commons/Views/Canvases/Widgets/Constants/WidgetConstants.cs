using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants
{
    /// <summary>
    /// Field Details Panel Constants
    /// </summary>
    public class WidgetConstants
    {
        public static readonly ColorID BUTTON_INTERACTABLE_ENABLED_IMAGE_COLOR = ColorID.Red;
        public static readonly ColorID BUTTON_INTERACTABLE_ENABLED_TEXT_COLOR = ColorID.White;
        public static readonly ColorID BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR = ColorID.Gray;
        public static readonly ColorID BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR = ColorID.Black;
        public static readonly ColorID PRIMARY_COLOR_ID = ColorID.DodgerBlue;
        public static readonly ColorID SECONDARY_COLOR_ID = ColorID.GoldenRod;

        public static readonly IWidgetGridSpec POP_UP_WIDGET_GRID_SPEC = new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(Vector2.One / 4)
                    .SetCanvasGridSize(Vector2.One / 2);
    }
}