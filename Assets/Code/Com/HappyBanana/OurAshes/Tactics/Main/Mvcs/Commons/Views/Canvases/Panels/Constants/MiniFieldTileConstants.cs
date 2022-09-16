using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Constants
{
    public class IconConstants
    {
        public static readonly IWidgetGridSpec PRIMARY_SPRITE_SPEC = new WidgetGridSpecImpl()
            .SetCanvasGridCoords(Vector2.One * (1 - Internals.PRIMARY_SIZE) / 2)
            .SetCanvasGridSize(Vector2.One * Internals.PRIMARY_SIZE);

        public static readonly IWidgetGridSpec SECONDARY_SPRITE_SPEC = new WidgetGridSpecImpl()
            .SetCanvasGridCoords(Vector2.One * (1 - Internals.SECONDARY_SIZE) / 2)
            .SetCanvasGridSize(Vector2.One * Internals.SECONDARY_SIZE);

        public static readonly IWidgetGridSpec TERTIARY_SPRITE_SPEC = new WidgetGridSpecImpl()
            .SetCanvasGridCoords(Vector2.One * (1 - Internals.TERTIARY_SIZE) / 2)
            .SetCanvasGridSize(Vector2.One * Internals.TERTIARY_SIZE);

        private class Internals
        {
            public static readonly float PRIMARY_SIZE = 0.7f;
            public static readonly float SECONDARY_SIZE = 0.6f;
            public static readonly float TERTIARY_SIZE = 0.5f;
        }
    }
}