using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Reports.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MapReport
        : IMapReport
    {
        // Provides logging capability to the SORTIE logs
        private static readonly ILogger _logger = LoggerManager.GetSortieLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly bool _isMirrored;

        // Todo
        private readonly int _radius;

        // Todo
        private readonly ISet<ITileReport> _tileReports;

        // Todo
        private readonly ISet<ICubeCoordinates> _cubeCoordinates;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="isMirrored"> </param>
        /// <param name="radius">     </param>
        /// <param name="tileReports"></param>
        private MapReport(bool isMirrored, int radius, ISet<ITileReport> tileReports)
        {
            _isMirrored = isMirrored;
            _radius = radius;
            _tileReports = tileReports;
            _cubeCoordinates = new HashSet<ICubeCoordinates>();
            foreach (ITileReport tileReport in _tileReports)
            {
                _cubeCoordinates.Add(tileReport.GetCubeCoordinates());
            }
        }

        /// <inheritdoc/>
        ISet<ICubeCoordinates> IMapReport.GetCubeCoordinates()
        {
            return new HashSet<ICubeCoordinates>(_cubeCoordinates);
        }

        /// <inheritdoc/>
        bool IMapReport.IsMirrored()
        {
            return _isMirrored;
        }

        /// <inheritdoc/>
        int IMapReport.GetRadius()
        {
            return _radius;
        }

        /// <inheritdoc/>
        Optional<ITileReport> IMapReport.GetTileReport(ICubeCoordinates cubeCoordinates)
        {
            foreach (ITileReport tileReport in _tileReports)
            {
                if (tileReport.GetCubeCoordinates().Equals(cubeCoordinates))
                {
                    return Optional<ITileReport>.Of(tileReport);
                }
            }
            return Optional<ITileReport>.Empty();
        }

        /// <inheritdoc/>
        Optional<ITileReport> IMapReport.GetTileReport(CombatantCallSign callSign)
        {
            foreach (ITileReport tileReport in _tileReports)
            {
                if (tileReport.GetCombatantCallSign() == callSign)
                {
                    return Optional<ITileReport>.Of(tileReport);
                }
            }
            return Optional<ITileReport>.Empty();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            string tileReportsString = (_tileReports.Count != 0)
                ? string.Join("\n", _tileReports)
                : "empty";
            return string.Format("{0}: _radius={1}, _isMirrored={2}" +
                "\n{3}",
                this.GetType().Name, _radius, _isMirrored,
                StringUtils.Format(typeof(ITileReport), tileReportsString));
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private bool _isMirrored = false;

            // Todo
            private int _radius = -1;

            // Todo
            private ISet<ITileReport> _tileReports = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMapReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new construction
                    return new MapReport(_isMirrored, _radius, _tileReports);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="tileReports"></param>
            /// <returns></returns>
            public Builder SetTileReports(ISet<ITileReport> tileReports)
            {
                if (tileReports != null)
                {
                    _tileReports = new HashSet<ITileReport>(tileReports);
                }
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="isMirrored"></param>
            /// <returns></returns>
            public Builder SetIsMirrored(bool isMirrored)
            {
                _isMirrored = isMirrored;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="radius"></param>
            /// <returns></returns>
            public Builder SetRadius(int radius)
            {
                _radius = radius;
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
                // Check that _radius has been set
                if (_radius < 0)
                {
                    argumentExceptionSet.Add("_radius cannot be null.");
                }
                // Check that _tileReports has been set
                if (_tileReports == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(ITileReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}