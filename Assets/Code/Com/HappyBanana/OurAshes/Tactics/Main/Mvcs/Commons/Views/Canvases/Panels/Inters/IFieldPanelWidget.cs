using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Optionals;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters
{
    public interface IFieldPanelWidget
        : IPanelWidget
    {
        IOptional<IFieldTilePanelWidget> GetFileTilePanelWidget(Vector3 tileCoords);

        IList<Vector3> GetAvailableCoords();
    }
}