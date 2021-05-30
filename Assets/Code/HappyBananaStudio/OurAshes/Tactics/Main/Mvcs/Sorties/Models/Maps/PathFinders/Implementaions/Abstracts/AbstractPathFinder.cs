using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Interfaces;
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
        protected readonly IDictionary<ICubeCoordinates, IPath> cubeCoordinatesPaths =
            new Dictionary<ICubeCoordinates, IPath>();

        // Todo
        protected ICubeCoordinates cubeCoordinates;

        // Todo
        protected IMapReport mapReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesStart"></param>
        public AbstractPathFinder(ICubeCoordinates cubeCoordinatesStart, IMapReport mapReport)
        {
            this.cubeCoordinates = cubeCoordinatesStart;
            this.mapReport = mapReport;
            this.cubeCoordinatesPaths = new Dictionary<ICubeCoordinates, IPath>();
            this.PathFind();
        }

        /// <inheritdoc/>
        IDictionary<ICubeCoordinates, IPath> IPathFinder.GetCubeCoordinatesPaths()
        {
            return new Dictionary<ICubeCoordinates, IPath>(this.cubeCoordinatesPaths);
        }

        /// <inheritdoc/>
        ISet<IPath> IPathFinder.GetPaths()
        {
            return new HashSet<IPath>(this.cubeCoordinatesPaths.Values);
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected abstract void PathFind();
    }
}