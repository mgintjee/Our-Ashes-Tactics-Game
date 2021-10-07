using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IPathFinder
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IDictionary<ICubeCoordinates, ISortieMapPath> GetCubeCoordinatesPaths();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<ISortieMapPath> GetPaths();
    }
}