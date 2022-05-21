using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Views.Canvases.Panels.Details.Maps
{
    /// <summary>
    /// Field Details Panel Constants
    /// </summary>
    public class FieldDetailsPanelConstants
    {
        public static readonly Vector2 HEADER_COORDS = DetailsPanelConstants.FIELD_PANEL_DIMENSIONS * DetailsPanelConstants.PANEL_HEADER_COORDS_RATIO;
        public static readonly Vector2 HEADER_SIZE = DetailsPanelConstants.FIELD_PANEL_DIMENSIONS * DetailsPanelConstants.PANEL_HEADER_SIZE_RATIO;
        public static readonly Vector2 TEXT_SIZE = DetailsPanelConstants.FIELD_PANEL_DIMENSIONS * new Vector2(1 / 2f, 1 / 4f);
        public static readonly Vector2 TEXT_FIELD_ID_COORDS = new Vector2(0, 3);
        public static readonly Vector2 TEXT_FIELD_BIOME_COORDS = new Vector2(1, 3);
        public static readonly Vector2 TEXT_FIELD_SIZE_COORDS = new Vector2(0, 2);
        public static readonly Vector2 TEXT_FIELD_SHAPE_COORDS = new Vector2(1, 2);
    }
}