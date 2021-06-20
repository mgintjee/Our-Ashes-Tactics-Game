﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Abstracts
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractPath
        : IPath
    {
        // Provides logging capability to the SORTIE logs
        private static readonly ILogger _logger = LoggerManager.GetSortieLogger(new StackFrame().GetMethod().DeclaringType);
        // Todo
        protected IList<ICubeCoordinates> _cubeCoordinatesList = new List<ICubeCoordinates>();

        // Todo
        protected ICubeCoordinates _end;

        // Todo
        protected IMapReport _mapReport;

        // Todo
        protected float _pathCost = float.MaxValue;

        // Todo
        protected PathType _pathType;

        // Todo
        protected ICubeCoordinates _start;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesStart"></param>
        /// <param name="cubeCoordinatesEnd">  </param>
        /// <param name="pathLength">          </param>
        /// <param name="mapReport">           </param>
        public AbstractPath(ICubeCoordinates cubeCoordinatesStart, ICubeCoordinates cubeCoordinatesEnd,
            int pathLength, IMapReport mapReport)
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

                        this.SetAttributes(cubeCoordinatesStepList, cubeCoordinatesStart, cubeCoordinatesEnd, mapReport);
                    }
                    else
                    {
                        throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. " +
                            "PathLength={} must be greater than 0.",
                           this.GetType(), pathLength);
                    }
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. Ending {} is null.",
                       this.GetType(), typeof(ICubeCoordinates));
                }
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. Starting {} is null.",
                   this.GetType(), typeof(ICubeCoordinates));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesStepList"></param>
        /// <param name="mapReport">              </param>
        public AbstractPath(IList<ICubeCoordinates> cubeCoordinatesStepList, IMapReport mapReport)
        {
            if (cubeCoordinatesStepList != null)
            {
                if (cubeCoordinatesStepList.Count > 0)
                {
                    int listLength = cubeCoordinatesStepList.Count;
                    ICubeCoordinates cubeCoordinatesStart = cubeCoordinatesStepList[0];
                    ICubeCoordinates cubeCoordinatesEnd = cubeCoordinatesStepList[listLength - 1];
                    int minimumPathDistance = cubeCoordinatesStart.GetDistanceFrom(cubeCoordinatesEnd);
                    if (listLength >= minimumPathDistance)
                    {
                        this.SetAttributes(cubeCoordinatesStepList, cubeCoordinatesStart, cubeCoordinatesEnd, mapReport);
                    }
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. List: {} must be greater than 0.",
                       this.GetType(), typeof(ICubeCoordinates));
                }
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. List: {} is null.",
                   this.GetType(), typeof(ICubeCoordinates));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject"></param>
        public AbstractPath(IPath pathObject, IMapReport mapReport)
        {
            if (pathObject.IsValid())
            {
                this.SetAttributes( pathObject.GetCubeCoordinatesList(),
                    pathObject.GetStart(), pathObject.GetEnd(),  mapReport);
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {} is invalid.",
                   this.GetType(), typeof(IPath));
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: Cost={1}, List: {2}=[{3}]",
                this.GetType().Name, _pathCost, typeof(ICubeCoordinates).Name,
                string.Join(", ", this._cubeCoordinatesList));
        }

        /// <inheritdoc/>
        ICubeCoordinates IPath.GetEnd()
        {
            return this._end;
        }

        /// <inheritdoc/>
        ICubeCoordinates IPath.GetStart()
        {
            return this._start;
        }

        /// <inheritdoc/>
        IList<ICubeCoordinates> IPath.GetCubeCoordinatesList()
        {
            return new List<ICubeCoordinates>(this._cubeCoordinatesList);
        }

        /// <inheritdoc/>
        float IPath.GetPathCost()
        {
            return this._pathCost;
        }

        /// <inheritdoc/>
        int IPath.GetLength()
        {
            return this._cubeCoordinatesList.Count;
        }

        /// <inheritdoc/>
        PathType IPath.GetPathType()
        {
            return this._pathType;
        }

        /// <inheritdoc/>
        bool IPath.IsValid()
        {
            return this.ValidPathCount() && this.ValidPathCompleteness() && this.ValidPathConnectivity();
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected void CalculatePathCost()
        {
            this._pathCost = 0;

            // Start at the second step to avoid adding the cost of the start CubeCoordinates
            for (int i = 1; i < this._cubeCoordinatesList.Count; ++i)
            {
                ICubeCoordinates cubeCoordinates = this._cubeCoordinatesList[i];
                this._pathCost += (cubeCoordinates != null)
                    ? this.GetCubeCoordinatesCost(cubeCoordinates)
                    : int.MaxValue;
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        protected abstract float GetCubeCoordinatesCost(ICubeCoordinates cubeCoordinates);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesStepList"></param>
        /// <param name="cubeCoordinatesStart">   </param>
        /// <param name="cubeCoordinatesEnd">     </param>
        private void SetAttributes(IList<ICubeCoordinates> cubeCoordinatesStepList,
            ICubeCoordinates cubeCoordinatesStart, ICubeCoordinates cubeCoordinatesEnd, IMapReport mapReport)
        {
            this._cubeCoordinatesList = new List<ICubeCoordinates>(cubeCoordinatesStepList);
            this._start = cubeCoordinatesStart;
            this._end = cubeCoordinatesEnd;
            this._mapReport = mapReport;
            this.CalculatePathCost();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private bool ValidPathCompleteness()
        {
            return this._end.Equals(this._cubeCoordinatesList[this._cubeCoordinatesList.Count - 1]);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private bool ValidPathConnectivity()
        {
            ICubeCoordinates previous = this._cubeCoordinatesList[0];
            for (int i = 1; i < this._cubeCoordinatesList.Count; ++i)
            {
                ICubeCoordinates current = _cubeCoordinatesList[i];
                if (!previous.GetNeighbors().Contains(current))
                {
                    return false;
                }
                previous = current;
            }
            return true;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private bool ValidPathCount()
        {
            return this._cubeCoordinatesList.Count >= this._start.GetDistanceFrom(this._end);
        }
    }
}