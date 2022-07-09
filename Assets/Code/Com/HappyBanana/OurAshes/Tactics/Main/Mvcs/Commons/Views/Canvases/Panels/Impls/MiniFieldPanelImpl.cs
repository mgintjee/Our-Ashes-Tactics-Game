using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls
{
    /// <summary>
    /// Fiekd Tile Panel Impl
    /// </summary>
    public class MiniFieldPanelImpl
        : AbstractPanelWidget, IFieldPanelWidget
    {
        private IDictionary<Vector2, IFieldTilePanelWidget> tileCoordPanelWidgets = new Dictionary<Vector2, IFieldTilePanelWidget>();

        IList<Vector2> IFieldPanelWidget.GetAvailableCoords()
        {
            return new List<Vector2>(this.tileCoordPanelWidgets.Keys);
        }

        Optional<IFieldTilePanelWidget> IFieldPanelWidget.GetFileTilePanelWidget(Vector2 tileCoords)
        {
            IFieldTilePanelWidget fieldTilePanelWidget = null;

            if (this.tileCoordPanelWidgets.ContainsKey(tileCoords))
            {
                fieldTilePanelWidget = this.tileCoordPanelWidgets[tileCoords];
            }

            return Optional<IFieldTilePanelWidget>.Of(fieldTilePanelWidget);
        }

        protected override void InitialBuild()
        {
            // Todo
        }
    }
}