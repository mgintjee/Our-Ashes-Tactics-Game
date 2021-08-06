using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Maps.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Tiles.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Maps.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class SortieMapReport : AbstractReport, ISortieMapReport
    {
        // Provides logging capability to the SORTIE logs
        private readonly ILogger _logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly bool _isMirrored;

        // Todo
        private readonly int _radius;

        // Todo
        private readonly ISet<ISortieTileReport> _tileReports;

        // Todo
        private readonly ISet<ICubeCoordinates> _cubeCoordinates;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="isMirrored"> </param>
        /// <param name="radius">     </param>
        /// <param name="tileReports"></param>
        private SortieMapReport(bool isMirrored, int radius, ISet<ISortieTileReport> tileReports)
        {
            _isMirrored = isMirrored;
            _radius = radius;
            _tileReports = tileReports;
            _cubeCoordinates = new HashSet<ICubeCoordinates>();
            foreach (ISortieTileReport tileReport in _tileReports)
            {
                _cubeCoordinates.Add(tileReport.GetCubeCoordinates());
            }
        }

        /// <inheritdoc/>
        ISet<ICubeCoordinates> ISortieMapReport.GetCubeCoordinates()
        {
            return new HashSet<ICubeCoordinates>(_cubeCoordinates);
        }

        /// <inheritdoc/>
        bool ISortieMapReport.IsMirrored()
        {
            return _isMirrored;
        }

        /// <inheritdoc/>
        int ISortieMapReport.GetRadius()
        {
            return _radius;
        }

        /// <inheritdoc/>
        Optional<ISortieTileReport> ISortieMapReport.GetTileReport(ICubeCoordinates cubeCoordinates)
        {
            foreach (ISortieTileReport tileReport in _tileReports)
            {
                if (tileReport.GetCubeCoordinates().Equals(cubeCoordinates))
                {
                    return Optional<ISortieTileReport>.Of(tileReport);
                }
            }
            return Optional<ISortieTileReport>.Empty();
        }

        /// <inheritdoc/>
        Optional<ISortieTileReport> ISortieMapReport.GetTileReport(CombatantCallSign callSign)
        {
            foreach (ISortieTileReport tileReport in _tileReports)
            {
                if (tileReport.GetCombatantCallSign() == callSign)
                {
                    return Optional<ISortieTileReport>.Of(tileReport);
                }
            }
            return Optional<ISortieTileReport>.Empty();
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            ISet<ISortieTileReport> occupiedTileReports = new HashSet<ISortieTileReport>();
            ISet<ISortieTileReport> unoccupiedTileReports = new HashSet<ISortieTileReport>();
            foreach (ISortieTileReport tileReport in _tileReports)
            {
                if (tileReport.GetCombatantCallSign() != CombatantCallSign.None)
                {
                    occupiedTileReports.Add(tileReport);
                }
                else
                {
                    unoccupiedTileReports.Add(tileReport);
                }
            }
            return string.Format("_radius={0}, _isMirrored={1}, Occupied {2}, Unoccupied {3}",
                _radius, _isMirrored, StringUtils.FormatCollection(occupiedTileReports), StringUtils.FormatCollection(unoccupiedTileReports));
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
            private ISet<ISortieTileReport> _tileReports = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ISortieMapReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new construction
                    return new SortieMapReport(_isMirrored, _radius, _tileReports);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="tileReports"></param>
            /// <returns></returns>
            public Builder SetTileReports(ISet<ISortieTileReport> tileReports)
            {
                if (tileReports != null)
                {
                    _tileReports = new HashSet<ISortieTileReport>(tileReports);
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
                    argumentExceptionSet.Add("Set: " + typeof(ISortieTileReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}