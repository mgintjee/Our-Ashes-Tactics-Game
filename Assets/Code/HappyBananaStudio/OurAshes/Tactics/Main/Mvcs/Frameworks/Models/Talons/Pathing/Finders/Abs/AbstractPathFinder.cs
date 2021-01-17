namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Finders.Abs
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Finders.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractPathFinder
        : IPathFinder
    {
        // Todo
        protected ICubeCoordinates cubeCoordinatesStart;

        // Todo
        protected IDictionary<ICubeCoordinates, IPathObject> pathObjectDictionary =
            new Dictionary<ICubeCoordinates, IPathObject>();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesStart">
        /// </param>
        public AbstractPathFinder(ICubeCoordinates cubeCoordinatesStart)
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
        /// <returns>
        /// </returns>
        public IDictionary<ICubeCoordinates, IPathObject> GetPathObjectDictionary()
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
                    throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? has no corresponding ?.",
                        this.GetType(), typeof(ICubeCoordinates), typeof(IPathObject));
                }
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is null.",
                    this.GetType(), typeof(ICubeCoordinates));
            }
        }
    }
}