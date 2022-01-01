using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Commons.Maps.Paths.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Maps.PathFinders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Maps.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Maps.PathFinders.Implementaions.Abstrs
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractPathFinder : IPathFinder
    {
        // Todo
        protected IDictionary<ICubeCoordinates, ISortieMapPath> _cubeCoordinatesPaths = new Dictionary<ICubeCoordinates, ISortieMapPath>();

        // Todo
        protected ICubeCoordinates _cubeCoordinates;

        // Todo
        protected ISortieMapReport _mapReport;

        /// <inheritdoc/>
        IDictionary<ICubeCoordinates, ISortieMapPath> IPathFinder.GetCubeCoordinatesPaths()
        {
            return new Dictionary<ICubeCoordinates, ISortieMapPath>(_cubeCoordinatesPaths);
        }

        /// <inheritdoc/>
        ISet<ISortieMapPath> IPathFinder.GetPaths()
        {
            return new HashSet<ISortieMapPath>(_cubeCoordinatesPaths.Values);
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected abstract void PathFind();
    }
}