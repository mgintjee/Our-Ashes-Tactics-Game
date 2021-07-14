using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sorties.Maps.Paths.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Abstracts
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractSortieMapPath : ISortieMapPath
    {
        // Todo
        protected IList<ICubeCoordinates> _stepList = new List<ICubeCoordinates>();

        // Todo
        protected ICubeCoordinates _end;

        // Todo
        protected ISortieMapReport _mapReport;

        // Todo
        protected float _pathCost = float.MaxValue;

        // Todo
        protected PathType _pathType;

        // Todo
        protected ICubeCoordinates _start;

        // Provides logging capability to the SORTIE logs
        private readonly ILogger _logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesStart"></param>
        /// <param name="cubeCoordinatesEnd">  </param>
        /// <param name="pathLength">          </param>
        /// <param name="mapReport">           </param>
        public AbstractSortieMapPath(ICubeCoordinates cubeCoordinatesStart, ICubeCoordinates cubeCoordinatesEnd,
            int pathLength, ISortieMapReport mapReport)
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

                        SetAttributes(cubeCoordinatesStepList, cubeCoordinatesStart, cubeCoordinatesEnd, mapReport);
                    }
                    else
                    {
                        throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. " +
                            "PathLength={} must be greater than 0.",
                           GetType(), pathLength);
                    }
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. Ending {} is null.",
                       GetType(), typeof(ICubeCoordinates));
                }
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. Starting {} is null.",
                   GetType(), typeof(ICubeCoordinates));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="stepList"> </param>
        /// <param name="mapReport"></param>
        public AbstractSortieMapPath(IList<ICubeCoordinates> stepList, ISortieMapReport mapReport)
        {
            if (stepList != null)
            {
                if (stepList.Count > 0)
                {
                    int listLength = stepList.Count;
                    ICubeCoordinates start = stepList[0];
                    ICubeCoordinates end = stepList[listLength - 1];
                    int minimumPathDistance = start.GetDistanceFrom(end);
                    if (listLength >= minimumPathDistance)
                    {
                        SetAttributes(stepList, start, end, mapReport);
                    }
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. List: {} must be greater than 0.",
                       GetType(), typeof(ICubeCoordinates));
                }
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. List: {} is null.",
                   GetType(), typeof(ICubeCoordinates));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject"></param>
        public AbstractSortieMapPath(ISortieMapPath pathObject, ISortieMapReport mapReport)
        {
            if (pathObject.IsValid())
            {
                SetAttributes(pathObject.GetCubeCoordinatesList(),
                    pathObject.GetStart(), pathObject.GetEnd(), mapReport);
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {} is invalid.",
                   GetType(), typeof(ISortieMapPath));
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: Cost={1}, List: {2}=[{3}]",
                GetType().Name, _pathCost, typeof(ICubeCoordinates).Name,
                string.Join(", ", _stepList));
        }

        /// <inheritdoc/>
        ICubeCoordinates ISortieMapPath.GetEnd()
        {
            return _end;
        }

        /// <inheritdoc/>
        ICubeCoordinates ISortieMapPath.GetStart()
        {
            return _start;
        }

        /// <inheritdoc/>
        IList<ICubeCoordinates> ISortieMapPath.GetCubeCoordinatesList()
        {
            return new List<ICubeCoordinates>(_stepList);
        }

        /// <inheritdoc/>
        float ISortieMapPath.GetPathCost()
        {
            return _pathCost;
        }

        /// <inheritdoc/>
        int ISortieMapPath.GetLength()
        {
            return _stepList.Count;
        }

        /// <inheritdoc/>
        PathType ISortieMapPath.GetPathType()
        {
            return _pathType;
        }

        /// <inheritdoc/>
        bool ISortieMapPath.IsValid()
        {
            return ValidPathDistance() && ValidPathCompleteness() && ValidPathConnectivity();
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected void CalculatePathCost()
        {
            _pathCost = 0;

            // Start at the second step to avoid adding the cost of the start CubeCoordinates
            for (int i = 1; i < _stepList.Count; ++i)
            {
                ICubeCoordinates cubeCoordinates = _stepList[i];
                _pathCost += (cubeCoordinates != null)
                    ? GetCubeCoordinatesCost(cubeCoordinates)
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
            ICubeCoordinates cubeCoordinatesStart, ICubeCoordinates cubeCoordinatesEnd, ISortieMapReport mapReport)
        {
            _stepList = new List<ICubeCoordinates>(cubeCoordinatesStepList);
            _start = cubeCoordinatesStart;
            _end = cubeCoordinatesEnd;
            _mapReport = mapReport;
            CalculatePathCost();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private bool ValidPathCompleteness()
        {
            return _end.Equals(_stepList[_stepList.Count - 1]);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private bool ValidPathConnectivity()
        {
            ICubeCoordinates previous = _stepList[0];
            for (int i = 1; i < _stepList.Count; ++i)
            {
                ICubeCoordinates current = _stepList[i];
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
        private bool ValidPathDistance()
        {
            return _stepList.Count >= _start.GetDistanceFrom(_end);
        }
    }
}