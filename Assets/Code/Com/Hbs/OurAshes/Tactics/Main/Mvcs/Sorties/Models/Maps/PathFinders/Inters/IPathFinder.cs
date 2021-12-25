using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Inters
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