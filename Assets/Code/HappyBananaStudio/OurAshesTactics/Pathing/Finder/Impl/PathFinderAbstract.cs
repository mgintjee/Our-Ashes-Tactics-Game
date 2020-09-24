/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Pathing.Finder.Api;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Api;
using System.Collections.Generic;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Pathing.Finder.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class PathFinderAbstract
    : IPathFinder
    {
        #region Protected Fields

        // Todo
        protected CubeCoordinates cubeCoordinatesStart;

        // Todo
        protected Dictionary<CubeCoordinates, IPathObject> pathObjectDictionary = new Dictionary<CubeCoordinates, IPathObject>();

        #endregion Protected Fields

        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        #endregion Private Fields

        #region Public Constructors

        public PathFinderAbstract(CubeCoordinates cubeCoordinatesStart)
        {
            this.cubeCoordinatesStart = cubeCoordinatesStart;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        public abstract void BeginPathFinding();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public HashSet<CubeCoordinates> GetCubeCoordiantesEndSet()
        {
            return new HashSet<CubeCoordinates>(this.pathObjectDictionary.Keys);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public Dictionary<CubeCoordinates, IPathObject> GetPathObjectDictionary()
        {
            return new Dictionary<CubeCoordinates, IPathObject>(this.pathObjectDictionary);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesEnd"></param>
        /// <returns></returns>
        public IPathObject GetPathObjectForCubeCoordinatesEnd(CubeCoordinates cubeCoordinatesEnd)
        {
            if (cubeCoordinatesEnd != null)
            {
                if (this.pathObjectDictionary.ContainsKey(cubeCoordinatesEnd))
                {
                    return this.pathObjectDictionary[cubeCoordinatesEnd];
                }
                else
                {
                    logger.Warn("Unable to get PathObject for CubeCoordinates. Parameterized CubeCoordinates=? has no associated PathObject.", cubeCoordinatesEnd);
                }
            }
            else
            {
                logger.Warn("Unable to get PathObject for CubeCoordinates. Parameterized CubeCoordinates is null.");
            }
            return null;
        }

        #endregion Public Methods
    }
}