using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Paths.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Paths.Scripts.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Maps.Paths.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PathView
        : IPathView
    {
        // Todo
        private readonly IPathViewScript viewScript;

        /// <summary>
        /// Todo
        /// </summary>
        private PathView()
        {
        }

        void IPathView.Clear()
        {
            throw new System.NotImplementedException();
        }
    }
}