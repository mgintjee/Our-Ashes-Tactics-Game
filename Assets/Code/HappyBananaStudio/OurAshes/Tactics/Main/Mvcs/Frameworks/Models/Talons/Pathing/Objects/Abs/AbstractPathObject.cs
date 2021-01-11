namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Abs
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Utils;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Utils;
    using HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractPathObject
        : IPathObject
    {
        // Todo
        protected float pathObjectCost = float.MaxValue;

        // Todo
        protected ICubeCoordinates tileCoordinatesEnd;

        // Todo
        protected ICubeCoordinates tileCoordinatesStart;

        // Todo
        protected IList<ICubeCoordinates> tileCoordinatesStepList = new List<ICubeCoordinates>();

        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileCoordinatesStart">
        /// </param>
        /// <param name="tileCoordinatesEnd">
        /// </param>
        /// <param name="pathLength">
        /// </param>
        public AbstractPathObject(ICubeCoordinates tileCoordinatesStart, ICubeCoordinates tileCoordinatesEnd, int pathLength)
        {
            if (tileCoordinatesStart != null)
            {
                if (tileCoordinatesEnd != null)
                {
                    if (pathLength > 0)
                    {
                        IList<ICubeCoordinates> tileCoordinatesStepList = new List<ICubeCoordinates>
                        {
                            tileCoordinatesStart
                        };
                        for (int i = 1; i < pathLength - 1; ++i)
                        {
                            tileCoordinatesStepList.Add(null);
                        }
                        tileCoordinatesStepList.Add(tileCoordinatesEnd);

                        this.SetAttributes(tileCoordinatesStepList, tileCoordinatesStart, tileCoordinatesEnd);
                    }
                    else
                    {
                        throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. " +
                            "PathLength=? must be greater than 0.",
                           this.GetType(), pathLength);
                    }
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. Ending ? is null.",
                       this.GetType(), typeof(ICubeCoordinates));
                }
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. Starting ? is null.",
                   this.GetType(), typeof(ICubeCoordinates));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileCoordinatesStepList">
        /// </param>
        public AbstractPathObject(IList<ICubeCoordinates> tileCoordinatesStepList)
        {
            if (tileCoordinatesStepList != null)
            {
                if (tileCoordinatesStepList.Count > 0)
                {
                    int listLength = tileCoordinatesStepList.Count;
                    ICubeCoordinates cubeCoordinatesStart = tileCoordinatesStepList[0];
                    ICubeCoordinates cubeCoordinatesEnd = tileCoordinatesStepList[listLength - 1];
                    int minimumPathDistance = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFrom(
                        cubeCoordinatesStart, cubeCoordinatesEnd);
                    if (listLength >= minimumPathDistance)
                    {
                        this.SetAttributes(tileCoordinatesStepList, cubeCoordinatesStart, cubeCoordinatesEnd);
                    }
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. List: ? must be greater than 0.",
                       this.GetType(), typeof(ICubeCoordinates));
                }
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. List: ? is null.",
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
                throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. ? is invalid.",
                   this.GetType(), typeof(IPathObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ICubeCoordinates GetCubeCoordinatesEnd()
        {
            return this.tileCoordinatesEnd;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ICubeCoordinates GetCubeCoordinatesStart()
        {
            return this.tileCoordinatesStart;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IList<ICubeCoordinates> GetCubeCoordinatesStepList()
        {
            return new List<ICubeCoordinates>(this.tileCoordinatesStepList);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public float GetPathObjectCost()
        {
            return this.pathObjectCost;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetPathObjectLength()
        {
            return this.GetCubeCoordinatesStepList().Count;
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
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return string.Join(", ", this.tileCoordinatesStepList);
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected void CalculatePathCost()
        {
            this.pathObjectCost = 0;

            // Start at the second step to avoid adding the cost of the start CubeCoordinates
            for (int i = 1; i < this.GetPathObjectLength(); ++i)
            {
                if (this.GetCubeCoordinatesStepList()[i] != null)
                {
                    this.pathObjectCost += this.GetTileObjectPathCost(this.GetCubeCoordinatesStepList()[i]);
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
        /// <param name="tileCoordinates"></param>
        /// <returns></returns>
        protected abstract float GetTileObjectPathCost(ICubeCoordinates tileCoordinates);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileCoordinatesStepList"></param>
        /// <param name="tileCoordinatesStart"></param>
        /// <param name="tileCoordinatesEnd"></param>
        private void SetAttributes(IList<ICubeCoordinates> tileCoordinatesStepList,
            ICubeCoordinates tileCoordinatesStart, ICubeCoordinates tileCoordinatesEnd)
        {
            this.tileCoordinatesStepList = new List<ICubeCoordinates>(tileCoordinatesStepList);
            this.tileCoordinatesStart = tileCoordinatesStart;
            this.tileCoordinatesEnd = tileCoordinatesEnd;
            this.CalculatePathCost();
        }
    }
}