namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Abs
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Utils;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Utils;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractPathObject
        : IPathObject
    {
        // Todo
        protected float pathObjectCost = float.MaxValue;

        // Todo
        protected ICubeCoordinates cubeCoordinatesEnd;

        // Todo
        protected ICubeCoordinates cubeCoordinatesStart;

        // Todo
        protected IList<ICubeCoordinates> cubeCoordinatesStepList = new List<ICubeCoordinates>();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesStart">
        /// </param>
        /// <param name="cubeCoordinatesEnd">
        /// </param>
        /// <param name="pathLength">
        /// </param>
        public AbstractPathObject(ICubeCoordinates cubeCoordinatesStart,
            ICubeCoordinates cubeCoordinatesEnd, int pathLength)
        {
            if (cubeCoordinatesStart != null)
            {
                if (cubeCoordinatesEnd != null)
                {
                    if (pathLength > 0)
                    {
                        IList<ICubeCoordinates> cubeCoordinatesStepList = new List<ICubeCoordinates>
                        {
                            cubeCoordinatesStart
                        };
                        for (int i = 1; i < pathLength - 1; ++i)
                        {
                            cubeCoordinatesStepList.Add(null);
                        }
                        cubeCoordinatesStepList.Add(cubeCoordinatesEnd);

                        this.SetAttributes(cubeCoordinatesStepList, cubeCoordinatesStart, cubeCoordinatesEnd);
                    }
                    else
                    {
                        throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. " +
                            "PathLength=? must be greater than 0.",
                           this.GetType(), pathLength);
                    }
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. Ending ? is null.",
                       this.GetType(), typeof(ICubeCoordinates));
                }
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. Starting ? is null.",
                   this.GetType(), typeof(ICubeCoordinates));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesStepList">
        /// </param>
        public AbstractPathObject(IList<ICubeCoordinates> cubeCoordinatesStepList)
        {
            if (cubeCoordinatesStepList != null)
            {
                if (cubeCoordinatesStepList.Count > 0)
                {
                    int listLength = cubeCoordinatesStepList.Count;
                    ICubeCoordinates cubeCoordinatesStart = cubeCoordinatesStepList[0];
                    ICubeCoordinates cubeCoordinatesEnd = cubeCoordinatesStepList[listLength - 1];
                    int minimumPathDistance = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFrom(
                        cubeCoordinatesStart, cubeCoordinatesEnd);
                    if (listLength >= minimumPathDistance)
                    {
                        this.SetAttributes(cubeCoordinatesStepList, cubeCoordinatesStart, cubeCoordinatesEnd);
                    }
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. List: ? must be greater than 0.",
                       this.GetType(), typeof(ICubeCoordinates));
                }
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. List: ? is null.",
                   this.GetType(), typeof(ICubeCoordinates));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject">
        /// </param>
        public AbstractPathObject(IPathObject pathObject)
        {
            if (PathObjectValidatorUtil.ValidPathObject(pathObject))
            {
                this.SetAttributes(
                    pathObject.GetCubeCoordinatesStepList(),
                    pathObject.GetCubeCoordinatesStart(),
                    pathObject.GetCubeCoordinatesEnd());
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ? is invalid.",
                   this.GetType(), typeof(IPathObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ICubeCoordinates IPathObject.GetCubeCoordinatesEnd()
        {
            return this.cubeCoordinatesEnd;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ICubeCoordinates IPathObject.GetCubeCoordinatesStart()
        {
            return this.cubeCoordinatesStart;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IList<ICubeCoordinates> IPathObject.GetCubeCoordinatesStepList()
        {
            return new List<ICubeCoordinates>(this.cubeCoordinatesStepList);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        float IPathObject.GetPathObjectCost()
        {
            return this.pathObjectCost;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int IPathObject.GetPathObjectLength()
        {
            return this.cubeCoordinatesStepList.Count;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: List: {1}=[{2}]",
                this.GetType().Name, typeof(ICubeCoordinates).Name,
                string.Join(", ", this.cubeCoordinatesStepList));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public bool IsValid()
        {
            return PathObjectValidatorUtil.ValidPathObject(this);
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected void CalculatePathCost()
        {
            this.pathObjectCost = 0;

            // Start at the second step to avoid adding the cost of the start CubeCoordinates
            for (int i = 1; i < this.cubeCoordinatesStepList.Count; ++i)
            {
                if (this.cubeCoordinatesStepList[i] != null)
                {
                    this.pathObjectCost += this.GetCubeCoordinatesPathCost(this.cubeCoordinatesStepList[i]);
                }
                else
                {
                    this.pathObjectCost += int.MaxValue;
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        protected abstract float GetCubeCoordinatesPathCost(ICubeCoordinates cubeCoordinates);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesStepList"></param>
        /// <param name="cubeCoordinatesStart"></param>
        /// <param name="cubeCoordinatesEnd"></param>
        private void SetAttributes(IList<ICubeCoordinates> cubeCoordinatesStepList,
            ICubeCoordinates cubeCoordinatesStart, ICubeCoordinates cubeCoordinatesEnd)
        {
            this.cubeCoordinatesStepList = new List<ICubeCoordinates>(cubeCoordinatesStepList);
            this.cubeCoordinatesStart = cubeCoordinatesStart;
            this.cubeCoordinatesEnd = cubeCoordinatesEnd;
            this.CalculatePathCost();
        }
    }
}