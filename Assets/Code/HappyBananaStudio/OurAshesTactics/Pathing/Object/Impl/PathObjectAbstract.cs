/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube;
using HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Util;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Api;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Util;
using System.Collections.Generic;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Pathing.Object.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class PathObjectAbstract
    : IPathObject
    {
        #region Protected Fields

        // Todo
        protected int pathObjectCost = int.MaxValue;

        // Todo
        protected CubeCoordinates tileCoordinatesEnd;

        // Todo
        protected CubeCoordinates tileCoordinatesStart;

        // Todo
        protected List<CubeCoordinates> tileCoordinatesStepList = new List<CubeCoordinates>();

        #endregion Protected Fields

        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileCoordinatesStart"></param>
        /// <param name="tileCoordinatesEnd">  </param>
        /// <param name="pathLength">          </param>
        public PathObjectAbstract(CubeCoordinates tileCoordinatesStart, CubeCoordinates tileCoordinatesEnd, int pathLength)
        {
            if (tileCoordinatesStart != null &&
                tileCoordinatesEnd != null &&
                pathLength > 0)
            {
                List<CubeCoordinates> tileCoordinatesStepList = new List<CubeCoordinates>
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
        /// <param name="tileCoordinatesStepList"></param>
        public PathObjectAbstract(List<CubeCoordinates> tileCoordinatesStepList)
        {
            if (tileCoordinatesStepList != null &&
                tileCoordinatesStepList.Count > 0)
            {
                int listLength = tileCoordinatesStepList.Count;
                CubeCoordinates cubeCoordinatesStart = tileCoordinatesStepList[0];
                CubeCoordinates cubeCoordinatesEnd = tileCoordinatesStepList[listLength - 1];
                int minimumPathDistance = CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFrom(cubeCoordinatesStart, cubeCoordinatesEnd);
                if (listLength >= minimumPathDistance)
                {
                    this.SetAttributes(tileCoordinatesStepList, cubeCoordinatesStart, cubeCoordinatesEnd);
                }
                else
                {
                    logger.Warn("Unable To Construct PathObject. List: TileObject is not the minimum distance.");
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
        /// <param name="pathObject"></param>
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

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public CubeCoordinates GetCubeCoordinatesEnd()
        {
            return this.tileCoordinatesEnd;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public CubeCoordinates GetCubeCoordinatesStart()
        {
            return this.tileCoordinatesStart;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public List<CubeCoordinates> GetCubeCoordinatesStepList()
        {
            return new List<CubeCoordinates>(this.tileCoordinatesStepList);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetPathObjectCost()
        {
            return this.pathObjectCost;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetPathObjectLength()
        {
            return this.GetCubeCoordinatesStepList().Count;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return PathObjectValidatorUtil.ValidPathObject(this);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join(", ", this.tileCoordinatesStepList);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Todo
        /// </summary>
        protected void CalculatePathCost()
        {
            this.pathObjectCost = 0;

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

        protected abstract int GetTileObjectPathCost(CubeCoordinates tileCoordinates);

        #endregion Protected Methods

        #region Private Methods

        private void SetAttributes(List<CubeCoordinates> tileCoordinatesStepList,
            CubeCoordinates tileCoordinatesStart, CubeCoordinates tileCoordinatesEnd)
        {
            this.tileCoordinatesStepList = new List<CubeCoordinates>(tileCoordinatesStepList);
            this.tileCoordinatesStart = tileCoordinatesStart;
            this.tileCoordinatesEnd = tileCoordinatesEnd;
            this.CalculatePathCost();
        }

        #endregion Private Methods
    }
}