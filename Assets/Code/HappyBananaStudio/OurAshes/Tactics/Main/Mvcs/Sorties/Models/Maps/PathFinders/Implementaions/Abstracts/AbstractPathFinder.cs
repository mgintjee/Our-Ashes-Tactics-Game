using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Maps.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Implementaions.Abstracts
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractPathFinder
        : IPathFinder
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