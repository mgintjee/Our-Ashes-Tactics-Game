﻿using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Structs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Constants;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Factions.Constants
{
    public class IconsConstants
    {
        public static readonly float SIZE_X = DetailsPanelConstants.Factions.Vectors.SIZE.X;
        public static readonly float SIZE_Y = 1;
        public static readonly float SIZE = SIZE_X / 4;
        public static readonly float COORDS_Y = DetailsPanelConstants.Factions.Vectors.SIZE.Y - 1;

        public static readonly IWidgetGridSpec TEXT_SPEC = new WidgetGridSpecImpl()
            .SetCanvasGridCoords(new Vector2(2*SIZE, COORDS_Y))
            .SetCanvasGridSize(new Vector2(SIZE, SIZE_Y));

        public static readonly IList<TextImageWidgetStruct> TEXT_TIWS = new List<TextImageWidgetStruct>()
            {
                new TextImageWidgetStruct("Icon:",
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_TEXT_COLOR,
                    WidgetConstants.BUTTON_INTERACTABLE_DISABLED_IMAGE_COLOR)
            };
    }
}