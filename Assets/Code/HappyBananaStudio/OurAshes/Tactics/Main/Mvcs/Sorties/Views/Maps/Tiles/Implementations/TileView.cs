using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Tiles.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Tiles.Scripts.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Tiles.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TileView
        : ITileView
    {
        // Todo
        private readonly ITileViewScript viewScript;

        /// <summary>
        /// Todo
        /// </summary>
        private TileView()
        {
        }

        void ITileView.Clear()
        {
            throw new System.NotImplementedException();
        }
    }
}