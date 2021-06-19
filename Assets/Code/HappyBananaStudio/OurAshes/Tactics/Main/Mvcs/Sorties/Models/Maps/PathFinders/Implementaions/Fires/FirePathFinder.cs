using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Fires;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Implementaions.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Implementaions.Fires
{
    /// <summary>
    /// Todo
    /// </summary>
    public class FirePathFinder
        : AbstractPathFinder
    {
        // Provide logging capability
        private static readonly ILogger _logger = LoggerManager.GetSortieLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly float _APs = int.MinValue;

        // Todo
        private readonly float _RPs = int.MinValue;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <param name="mapReport">      </param>
        /// <param name="range">          </param>
        /// <param name="accuracy">       </param>
        private FirePathFinder(ICubeCoordinates cubeCoordinates,
            IMapReport mapReport, float range, float accuracy)
            : base(cubeCoordinates, mapReport)
        {
            _RPs = range;
            _APs = accuracy;
        }

        /// <inheritdoc/>
        protected override void PathFind()
        {
            _logger.Debug("PathFind for accuracy={}", _APs);
            ISet<ICubeCoordinates> allCubeCoordinates = this.mapReport.GetCubeCoordinates();
            ISet<ICubeCoordinates> validCubeCoordinates = new HashSet<ICubeCoordinates>();
            // Iterate over all of the CubeCoordinates
            foreach (ICubeCoordinates cubeCoordinates in allCubeCoordinates)
            {
                // Check that the cubeCoordinates is not the starting one
                if (cubeCoordinates != this.cubeCoordinates)
                {
                    this.mapReport.GetTileReport(cubeCoordinates).IfPresent((tileReport) =>
                    {
                        if (tileReport.GetCombatantCallSign() != CombatantCallSign.None)
                        {
                            validCubeCoordinates.Add(cubeCoordinates);
                        }
                    });
                }
            }

            // Iterate over all of the valid CubeCoordinates
            foreach (ICubeCoordinates cubeCoordinates in validCubeCoordinates)
            {
                IList<ICubeCoordinates> straightLinePath = this.PathFindFor(this.cubeCoordinates, cubeCoordinates);
                if (straightLinePath.Count <= _RPs)
                {
                    IPath path = new FirePath(straightLinePath, mapReport);
                    if (path.GetPathCost() <= _APs)
                    {
                        this.cubeCoordinatesPaths.Add(cubeCoordinates, path);
                    }
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathIndex">         </param>
        /// <param name="distance">          </param>
        /// <param name="cubeCoordinatesEnd"></param>
        /// <returns></returns>
        private ICubeCoordinates GetNextCubeCoordinates(int pathIndex, int distance, ICubeCoordinates cubeCoordinatesEnd)
        {
            float t = 1f / distance * pathIndex;
            int roundX, roundY, roundZ;
            float lerpX = this.Lerp(this.cubeCoordinates.GetX(), cubeCoordinatesEnd.GetX(), t);
            float lerpY = this.Lerp(this.cubeCoordinates.GetY(), cubeCoordinatesEnd.GetY(), t);
            float lerpZ = this.Lerp(this.cubeCoordinates.GetZ(), cubeCoordinatesEnd.GetZ(), t);

            roundX = (int)Math.Round(lerpX);
            roundY = (int)Math.Round(lerpY);
            roundZ = (int)Math.Round(lerpZ);

            bool updateX = Math.Abs(lerpX) % 1 == 0.5f;
            bool updateY = Math.Abs(lerpY) % 1 == 0.5f;
            bool updateZ = Math.Abs(lerpZ) % 1 == 0.5f;

            if (updateX || updateY || updateZ)
            {
                int newX = roundX + Math.Sign(lerpX);
                int newY = roundY + Math.Sign(lerpY);
                int newZ = roundZ + Math.Sign(lerpZ);

                float newXFireCost = (updateX && newX + roundY + roundZ == 0)
                    ? this.mapReport.GetTileReport(new CubeCoordinates(newX, roundY, roundZ)).GetValue()
                    .GetTileStats().GetTileAttributes().GetFireCost()
                    : -1;
                float newYFireCost = (updateX && roundX + newY + roundZ == 0)
                    ? this.mapReport.GetTileReport(new CubeCoordinates(roundX, newY, roundZ)).GetValue()
                    .GetTileStats().GetTileAttributes().GetFireCost()
                    : -1;
                float newZFireCost = (updateX && roundX + roundY + newZ == 0)
                    ? this.mapReport.GetTileReport(new CubeCoordinates(roundX, roundY, newZ)).GetValue()
                    .GetTileStats().GetTileAttributes().GetFireCost()
                    : -1;
                SortedSet<float> newFireCostSortedSet = new SortedSet<float> { newXFireCost, newYFireCost, newZFireCost };
                if (newFireCostSortedSet.Max != -1)
                {
                    if (newXFireCost == newFireCostSortedSet.Max)
                    {
                        roundX = newX;
                    }
                    else if (newYFireCost == newFireCostSortedSet.Max)
                    {
                        roundY = newY;
                    }
                    else if (newZFireCost == newFireCostSortedSet.Max)
                    {
                        roundZ = newZ;
                    }
                }
            }
            if (roundX + roundY + roundZ == 0)
            {
                return new CubeCoordinates(roundX, roundY, roundZ);
            }
            throw ExceptionUtil.Arguments.Build(
                "Unable to {}. Invalid Parameters. PathIndex={}, Distance={}, {} produced invalid {}, x={}, y={}, z={}",
                this.GetType(), pathIndex, distance, cubeCoordinatesEnd, typeof(ICubeCoordinates), roundX, roundY, roundZ);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private float Lerp(int a, int b, float t)
        {
            return a + ((b - a) * t);
        }

        /// <summary>
        /// </summary>
        /// <param name="cubeCoordinatesStart"></param>
        /// <param name="cubeCoordinatesEnd">  </param>
        /// <returns></returns>
        private IList<ICubeCoordinates> PathFindFor(ICubeCoordinates cubeCoordinatesStart, ICubeCoordinates cubeCoordinatesEnd)
        {
            int distance = cubeCoordinatesStart.GetDistanceFrom(cubeCoordinatesEnd);
            IList<ICubeCoordinates> cubeCoordinatesList = new List<ICubeCoordinates>();
            for (int i = 0; i < distance + 1; ++i)
            {
                try
                {
                    cubeCoordinatesList.Add(this.GetNextCubeCoordinates(i, distance, cubeCoordinatesEnd));
                }
                catch (ArgumentException e)
                {
                    _logger.Debug("Unable to {}. E={}", new StackFrame().GetMethod().Name, e);
                }
            }

            return cubeCoordinatesList;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private float _APs = float.MinValue;

            // Todo
            private ICubeCoordinates _cubeCoordinates = null;

            // Todo
            private IMapReport _mapReport = null;

            // Todo
            private float _RPs = float.MinValue;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IPathFinder Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new FirePathFinder(_cubeCoordinates, _mapReport, _RPs, _APs);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                        this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="accuracy"></param>
            /// <returns></returns>
            public Builder SetAPs(float accuracy)
            {
                _APs = accuracy;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="cubeCoordinates"></param>
            /// <returns></returns>
            public Builder SetCubeCoordinates(ICubeCoordinates cubeCoordinates)
            {
                _cubeCoordinates = cubeCoordinates;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="cubeCoordinates"></param>
            /// <returns></returns>
            public Builder SetMapReport(IMapReport mapReport)
            {
                _mapReport = mapReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="range"></param>
            /// <returns></returns>
            public Builder SetRPs(float range)
            {
                _RPs = range;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that cubeCoordinates has been set
                if (_cubeCoordinates == null)
                {
                    argumentExceptionSet.Add(typeof(ICubeCoordinates) + " cannot be null.");
                }
                // Check that mapReport has been set
                if (_mapReport == null)
                {
                    argumentExceptionSet.Add(typeof(IMapReport) + " cannot be null.");
                }
                // Check that range has been set
                if (_RPs == int.MinValue)
                {
                    argumentExceptionSet.Add("maxRange cannot be null.");
                }
                // Check that accuracy has been set
                if (_APs == float.MinValue)
                {
                    argumentExceptionSet.Add("maxAccuracy cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}