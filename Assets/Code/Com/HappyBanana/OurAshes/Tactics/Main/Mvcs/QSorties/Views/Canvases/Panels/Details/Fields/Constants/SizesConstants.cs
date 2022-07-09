using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Structs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Constants;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Fields.Constants
{
    public class SizesConstants
    {
        public static readonly float SIZE_X = DetailsPanelConstants.Fields.Vectors.SIZE.X;
        public static readonly float SIZE_Y = 1;
        public static readonly float SIZE = SIZE_X / 4;
        public static readonly float COORDS_Y = DetailsPanelConstants.Fields.Vectors.SIZE.Y - 2;

        public static readonly IWidgetGridSpec TEXT_SPEC = new WidgetGridSpecImpl()
            .SetCanvasGridCoords(new Vector2(2 * SIZE, COORDS_Y))
            .SetCanvasGridSize(new Vector2(SIZE, SIZE_Y));

        public static readonly IWidgetGridSpec BUTTON_SPEC = new WidgetGridSpecImpl()
            .SetCanvasGridCoords(new Vector2(3 * SIZE, COORDS_Y))
            .SetCanvasGridSize(new Vector2(SIZE, SIZE_Y));

        public static readonly IList<TextImageWidgetStruct> TEXT_TIWS = new List<TextImageWidgetStruct>()
            {
                new TextImageWidgetStruct("Size:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
    }
}