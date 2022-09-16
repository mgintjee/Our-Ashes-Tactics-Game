using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Structs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Views.Canvases.Panels.Details.Constants;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Views.Canvases.Panels.Details.Factions.Constants
{
    public class PhalanxesConstants
    {
        public static readonly float SIZE_X = DetailsPanelConstants.Factions.Vectors.SIZE.X;
        public static readonly float SIZE_Y = 1;
        public static readonly float SIZE = SIZE_X / 4;
        public static readonly float COORDS_Y = DetailsPanelConstants.Factions.Vectors.SIZE.Y - 2;

        public static readonly IWidgetGridSpec TEXT_SPEC = new WidgetGridSpecImpl()
            .SetCanvasGridCoords(new Vector2(0, COORDS_Y))
            .SetCanvasGridSize(new Vector2(2 * SIZE, SIZE_Y));

        public static readonly IWidgetGridSpec MINUS_BUTTON_SPEC = new WidgetGridSpecImpl()
            .SetCanvasGridCoords(new Vector2(2 * SIZE, COORDS_Y))
            .SetCanvasGridSize(new Vector2(SIZE, SIZE_Y));

        public static readonly IWidgetGridSpec ADD_BUTTON_SPEC = new WidgetGridSpecImpl()
            .SetCanvasGridCoords(new Vector2(3 * SIZE, COORDS_Y))
            .SetCanvasGridSize(new Vector2(SIZE, SIZE_Y));

        public static readonly IWidgetGridSpec LIST_SPEC = new WidgetGridSpecImpl()
            .SetCanvasGridCoords(new Vector2(0, COORDS_Y - 1))
            .SetCanvasGridSize(new Vector2(SIZE_X, SIZE_Y));

        public static readonly IList<TextImageWidgetStruct> TEXT_TIWS = new List<TextImageWidgetStruct>()
            {
                new TextImageWidgetStruct("Phalanxes:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };

        public static readonly IList<TextImageWidgetStruct> LIST_TIWS = new List<TextImageWidgetStruct>()
            {
                new TextImageWidgetStruct("[]",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
    }
}