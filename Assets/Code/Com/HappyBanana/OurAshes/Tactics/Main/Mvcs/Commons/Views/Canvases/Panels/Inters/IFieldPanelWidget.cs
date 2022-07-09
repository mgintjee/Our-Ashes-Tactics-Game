using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters
{
    public interface IFieldPanelWidget
        : IPanelWidget
    {
        Optional<IFieldTilePanelWidget> GetFileTilePanelWidget(Vector2 tileCoords);

        IList<Vector2> GetAvailableCoords();
    }
}