using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Implementaions.Fires;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Implementaions.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Maps.Inters;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.PathFinders.Implementaions.Fires
{
    /// <summary>
    /// Todo
    /// </summary>
    public class FirePathFinder : AbstractPathFinder
    {
        // Provide logging capability
        private readonly IClassLogger _logger = LoggerManager.GetLogger(MvcType.Sortie)
            .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly float _accuracy = int.MinValue;

        // Todo
        private readonly float _range = int.MinValue;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <param name="mapReport">      </param>
        /// <param name="range">          </param>
        /// <param name="accuracy">       </param>
        private FirePathFinder(ICubeCoordinates cubeCoordinates,
            ISortieMapReport mapReport, float range, float accuracy)
        {
            _cubeCoordinates = cubeCoordinates;
            _mapReport = mapReport;
            _range = range;
            _accuracy = accuracy;
            PathFind();
        }

        /// <inheritdoc/>
        protected override void PathFind()
        {
            _logger.Debug("PathFind @ {} for accuracy={} and range={}", _cubeCoordinates, _accuracy, _range);
            ISet<ICubeCoordinates> allCubeCoordinates = _mapReport.GetCubeCoordinates();
            ISet<ICubeCoordinates> validCubeCoordinates = new HashSet<ICubeCoordinates>();
            // Iterate over all of the CubeCoordinates
            foreach (ICubeCoordinates cubeCoordinates in allCubeCoordinates)
            {
                // Check that the cubeCoordinates is not the starting one
                if (!cubeCoordinates.Equals(_cubeCoordinates))
                {
                    _mapReport.GetTileReport(cubeCoordinates).IfPresent((tileReport) =>
                    {
                        if (tileReport.GetCombatantCallSign() != CombatantCallSign.None)// &&
                        //_cubeCoordinates.GetDistanceFrom(tileReport.GetCubeCoordinates()) <= _range)
                        {
                            validCubeCoordinates.Add(cubeCoordinates);
                        }
                    });
                }
            }

            // Iterate over all of the valid CubeCoordinates
            foreach (ICubeCoordinates cubeCoordinates in validCubeCoordinates)
            {
                IList<ICubeCoordinates> straightLinePath = PathFindFor(_cubeCoordinates, cubeCoordinates);
                if (straightLinePath.Count <= _range &&
                    !straightLinePath.Contains(null))
                {
                    ISortieMapPath path = new SortieMapFirePath(straightLinePath, _mapReport);
                    if (path.GetPathCost() <= _accuracy &&
                        path.GetLength() < _range &&
                        path.IsValid())
                    {
                        _cubeCoordinatesPaths.Add(cubeCoordinates, path);
                    }
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end">  </param>
        /// <returns></returns>
        private IList<ICubeCoordinates> PathFindFor(ICubeCoordinates start, ICubeCoordinates end)
        {
            int distance = start.GetDistanceFrom(end);
            IList<ICubeCoordinates> cubeCoordinatesList = new List<ICubeCoordinates>();
            for (int i = 0; i < distance + 1; ++i)
            {
                GetNextCubeCoordinates(i, distance, end).IfPresent(cubeCoordinates =>
                {
                    cubeCoordinatesList.Add(cubeCoordinates);
                });
            }

            return cubeCoordinatesList;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathIndex"></param>
        /// <param name="distance"> </param>
        /// <param name="end">      </param>
        /// <returns></returns>
        private Optional<ICubeCoordinates> GetNextCubeCoordinates(int pathIndex, int distance, ICubeCoordinates end)
        {
            float t = 1f / distance * pathIndex;
            int roundX, roundY, roundZ;
            float lerpX = Lerp(_cubeCoordinates.GetX(), end.GetX(), t);
            float lerpY = Lerp(_cubeCoordinates.GetY(), end.GetY(), t);
            float lerpZ = Lerp(_cubeCoordinates.GetZ(), end.GetZ(), t);
            roundX = (int)Math.Round(lerpX, MidpointRounding.AwayFromZero);
            roundY = (int)Math.Round(lerpY, MidpointRounding.AwayFromZero);
            roundZ = (int)Math.Round(lerpZ, MidpointRounding.AwayFromZero);
            bool updateX = Math.Abs(lerpX) % 1 == 0.5f;
            bool updateY = Math.Abs(lerpY) % 1 == 0.5f;
            bool updateZ = Math.Abs(lerpZ) % 1 == 0.5f;
            int newX = roundX + Math.Sign(lerpX);
            int newY = roundY + Math.Sign(lerpY);
            int newZ = roundZ + Math.Sign(lerpZ);
            if (updateX || updateY || updateZ)
            {
                return GetUpdateCubeCoordinates(updateX, updateY, updateZ, roundX, roundY, roundZ, newX, newY, newZ);
            }
            else
            {
                return GetNoUpdateCubeCoordinates(roundX, roundY, roundZ);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="updateX"></param>
        /// <param name="updateY"></param>
        /// <param name="updateZ"></param>
        /// <param name="roundX"> </param>
        /// <param name="roundY"> </param>
        /// <param name="roundZ"> </param>
        /// <param name="newX">   </param>
        /// <param name="newY">   </param>
        /// <param name="newZ">   </param>
        /// <returns></returns>
        private Optional<ICubeCoordinates> GetUpdateCubeCoordinates(bool updateX, bool updateY, bool updateZ, int roundX, int roundY, int roundZ, int newX, int newY, int newZ)
        {
            ICubeCoordinates cubeCoordinates = null;
            if (updateX && updateY &&
                (newX + newY + roundZ == 0))
            {
                cubeCoordinates = CubeCoordinates.Builder.Get()
                    .SetX(newX).SetY(newY).SetZ(roundZ).Build();
            }
            else if (updateX && updateZ &&
                (newX + roundY + newZ == 0))
            {
                cubeCoordinates = CubeCoordinates.Builder.Get()
                    .SetX(newX).SetY(roundY).SetZ(newZ).Build();
            }
            else if (updateY && updateZ &&
                (roundX + newY + newZ == 0))
            {
                cubeCoordinates = CubeCoordinates.Builder.Get()
                    .SetX(roundX).SetY(newY).SetZ(newZ).Build();
            }
            else if (updateX &&
                (newX + roundY + roundZ == 0))
            {
                cubeCoordinates = CubeCoordinates.Builder.Get()
                    .SetX(newX).SetY(roundY).SetZ(roundZ).Build();
            }
            else if (updateY &&
                (roundX + newY + roundZ == 0))
            {
                cubeCoordinates = CubeCoordinates.Builder.Get()
                    .SetX(roundX).SetY(newY).SetZ(roundZ).Build();
            }
            else if (updateZ &&
                (roundX + roundY + newZ == 0))
            {
                cubeCoordinates = CubeCoordinates.Builder.Get()
                    .SetX(roundX).SetY(roundY).SetZ(newZ).Build();
            }
            if (_mapReport.GetCubeCoordinates().Contains(cubeCoordinates))
            {
                return Optional<ICubeCoordinates>.Of(cubeCoordinates);
            }
            else
            {
                return Optional<ICubeCoordinates>.Empty();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="roundX"></param>
        /// <param name="roundY"></param>
        /// <param name="roundZ"></param>
        /// <returns></returns>
        private Optional<ICubeCoordinates> GetNoUpdateCubeCoordinates(int roundX, int roundY, int roundZ)
        {
            if (roundX + roundY + roundZ == 0)
            {
                return Optional<ICubeCoordinates>.Of(CubeCoordinates.Builder.Get()
                    .SetX(roundX).SetY(roundY).SetZ(roundZ).Build());
            }
            else
            {
                return Optional<ICubeCoordinates>.Empty();
            }
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
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private float _APs = float.MinValue;

            // Todo
            private ICubeCoordinates _cubeCoordinates = null;

            // Todo
            private ISortieMapReport _mapReport = null;

            // Todo
            private float _RPs = float.MinValue;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IPathFinder Build()
            {
                ISet<string> invalidReasons = IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new FirePathFinder(_cubeCoordinates, _mapReport, _RPs, _APs);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                        GetType(), string.Join("\n", invalidReasons));
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
            public Builder SetMapReport(ISortieMapReport mapReport)
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
                    argumentExceptionSet.Add(typeof(ISortieMapReport) + " cannot be null.");
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