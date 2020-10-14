/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
using HappyBananaStudio.OurAshes.Tactics.Api.Paths.Finders;
using HappyBananaStudio.OurAshes.Tactics.Api.Paths.Objects;
using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Impl.Objects.Paths.Finders.Abs
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class PathFinderAbstract
    : IPathFinder
    {
        // Todo
        protected ICubeCoordinates cubeCoordinatesStart;

        // Todo
        protected IDictionary<ICubeCoordinates, IPathObject> pathObjectDictionary = new Dictionary<ICubeCoordinates, IPathObject>();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesStart">
        /// </param>
        public PathFinderAbstract(ICubeCoordinates cubeCoordinatesStart)
        {
            this.cubeCoordinatesStart = cubeCoordinatesStart;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public abstract void BeginPathFinding();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ISet<ICubeCoordinates> GetCubeCoordiantesEndSet()
        {
            return new HashSet<ICubeCoordinates>(this.pathObjectDictionary.Keys);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesEnd">
        /// </param>
        /// <returns>
        /// </returns>
        public IPathObject GetPathObjectForCubeCoordinatesEnd(ICubeCoordinates cubeCoordinatesEnd)
        {
            if (cubeCoordinatesEnd != null)
            {
                if (this.pathObjectDictionary.ContainsKey(cubeCoordinatesEnd))
                {
                    return this.pathObjectDictionary[cubeCoordinatesEnd];
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? has no corresponding ?.",
                        this.GetType(), typeof(ICubeCoordinates), typeof(IPathObject));
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is null.",
                    this.GetType(), typeof(ICubeCoordinates));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<ICubeCoordinates, IPathObject> GetPathObjectDictionary()
        {
            return new Dictionary<ICubeCoordinates, IPathObject>(this.pathObjectDictionary);
        }
    }
}
