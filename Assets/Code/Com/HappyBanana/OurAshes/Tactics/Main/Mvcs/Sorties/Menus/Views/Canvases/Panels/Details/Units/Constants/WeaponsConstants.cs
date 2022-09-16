using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Structs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Views.Canvases.Panels.Details.Constants;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Views.Canvases.Panels.Details.Units.Constants
{
    public class WeaponsConstants
    {
        public static readonly float SIZE_X = DetailsPanelConstants.Units.Vectors.SIZE.X;
        public static readonly float SIZE_Y = 1;
        public static readonly float SIZE = SIZE_X / 4;
        public static readonly float COORDS_Y = DetailsPanelConstants.Units.Vectors.SIZE.Y - 3;

        public static readonly IWidgetGridSpec TEXT_SPEC = new WidgetGridSpecImpl()
            .SetCanvasGridCoords(new Vector2(0, COORDS_Y))
            .SetCanvasGridSize(new Vector2(2 * SIZE, SIZE_Y));

        public static readonly IWidgetGridSpec MOD_BUTTON_SPEC = new WidgetGridSpecImpl()
            .SetCanvasGridCoords(new Vector2(SIZE, COORDS_Y))
            .SetCanvasGridSize(new Vector2(SIZE, SIZE_Y));

        public static readonly IWidgetGridSpec LIST_SPEC = new WidgetGridSpecImpl()
            .SetCanvasGridCoords(new Vector2(0, COORDS_Y - 1))
            .SetCanvasGridSize(new Vector2(SIZE_X, SIZE_Y));

        public static readonly IList<TextImageWidgetStruct> TEXT_TIWS = new List<TextImageWidgetStruct>()
            {
                new TextImageWidgetStruct("Weapons:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };

        public static readonly IList<TextImageWidgetStruct> LIST_TIWS = new List<TextImageWidgetStruct>()
            {
                new TextImageWidgetStruct("[]",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };

        public static readonly IList<IWidgetGridSpec> MOD_BUTTON_SPECS = BuildButtonSpecs();

        private static IList<IWidgetGridSpec> BuildButtonSpecs()
        {
            IList<IWidgetGridSpec> widgetGridSpecs = new List<IWidgetGridSpec>();
            for (int i = 0; i < 6; ++i)
            {
                widgetGridSpecs.Add(BuildButtonSpec(i));
            }
            return widgetGridSpecs;
        }

        private static IWidgetGridSpec BuildButtonSpec(int i)
        {
            float x = ((i <= 1) ? (i + 2) : (i - 2)) * SIZE;
            float y = (i <= 1) ? COORDS_Y : COORDS_Y - 1;
            Vector2 coords = new Vector2(x, y);
            return new WidgetGridSpecImpl()
                .SetCanvasGridCoords(coords)
                .SetCanvasGridSize(new Vector2(SIZE, SIZE_Y));
        }
    }
}