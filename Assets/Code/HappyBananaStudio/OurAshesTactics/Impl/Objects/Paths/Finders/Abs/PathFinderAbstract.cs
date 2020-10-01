/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Paths.Finder;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Paths.Object;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Paths.Finders.Abs
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
        protected Dictionary<ICubeCoordinates, IPathObject> pathObjectDictionary = new Dictionary<ICubeCoordinates, IPathObject>();

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
        public HashSet<ICubeCoordinates> GetCubeCoordiantesEndSet()
        {
            return new HashSet<ICubeCoordinates>(this.pathObjectDictionary.Keys);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public Dictionary<ICubeCoordinates, IPathObject> GetPathObjectDictionary()
        {
            return new Dictionary<ICubeCoordinates, IPathObject>(this.pathObjectDictionary);
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
    }
}