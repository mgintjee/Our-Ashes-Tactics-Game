/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Paths.Object;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Paths.Object;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Paths.Objects.Abs
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class PathObjectAbstract
    : IPathObject
    {
        // Todo
        protected int pathObjectCost = int.MaxValue;

        // Todo
        protected ICubeCoordinates tileCoordinatesEnd;

        // Todo
        protected ICubeCoordinates tileCoordinatesStart;

        // Todo
        protected List<ICubeCoordinates> tileCoordinatesStepList = new List<ICubeCoordinates>();

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileCoordinatesStart">
        /// </param>
        /// <param name="tileCoordinatesEnd">
        /// </param>
        /// <param name="pathLength">
        /// </param>
        public PathObjectAbstract(ICubeCoordinates tileCoordinatesStart, ICubeCoordinates tileCoordinatesEnd, int pathLength)
        {
            if (tileCoordinatesStart != null &&
                tileCoordinatesEnd != null &&
                pathLength > 0)
            {
                List<ICubeCoordinates> tileCoordinatesStepList = new List<ICubeCoordinates>
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
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileCoordinatesStepList">
        /// </param>
        public PathObjectAbstract(List<ICubeCoordinates> tileCoordinatesStepList)
        {
            if (tileCoordinatesStepList != null &&
                tileCoordinatesStepList.Count > 0)
            {
                int listLength = tileCoordinatesStepList.Count;
                ICubeCoordinates cubeCoordinatesStart = tileCoordinatesStepList[0];
                ICubeCoordinates cubeCoordinatesEnd = tileCoordinatesStepList[listLength - 1];
                int minimumPathDistance = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFrom(cubeCoordinatesStart, cubeCoordinatesEnd);
                if (listLength >= minimumPathDistance)
                {
                    this.SetAttributes(tileCoordinatesStepList, cubeCoordinatesStart, cubeCoordinatesEnd);
                }
            }
            else
            {
                logger.Warn("Unable To Construct PathObject. List: TileCoordinates is null or not populated fully.");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject">
        /// </param>
        public PathObjectAbstract(IPathObject pathObject)
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
                logger.Warn("Unable To Construct PathObject. Parameterized PathObject is invalid.");
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
        public List<ICubeCoordinates> GetCubeCoordinatesStepList()
        {
            return new List<ICubeCoordinates>(this.tileCoordinatesStepList);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetPathObjectCost()
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

        protected abstract int GetTileObjectPathCost(ICubeCoordinates tileCoordinates);

        private void SetAttributes(List<ICubeCoordinates> tileCoordinatesStepList,
            ICubeCoordinates tileCoordinatesStart, ICubeCoordinates tileCoordinatesEnd)
        {
            this.tileCoordinatesStepList = new List<ICubeCoordinates>(tileCoordinatesStepList);
            this.tileCoordinatesStart = tileCoordinatesStart;
            this.tileCoordinatesEnd = tileCoordinatesEnd;
            this.CalculatePathCost();
        }
    }
}