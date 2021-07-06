using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Reports.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Tiles.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Tiles.Implementations
{
    /// <summary>
    /// Sortie Tile Model
    /// </summary>
    public class TileModel
        : ITileModel
    {
        // Provides logging capability to the SORTIE logs
        private readonly ILogger _logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly ICubeCoordinates _cubeCoordinates;

        // Todo
        private readonly TileType _tileType;

        // Todo
        private readonly ITileStats _tileStats;

        // Todo
        private CombatantCallSign _combatantCallSign;

        // Todo
        private ITileReport _report;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <param name="tileType">       </param>
        private TileModel(ICubeCoordinates cubeCoordinates, TileType tileType)
        {
            _logger.Info("Constructing with {} and {}", cubeCoordinates, StringUtils.Format(tileType));
            _cubeCoordinates = cubeCoordinates;
            _tileType = tileType;
            _combatantCallSign = CombatantCallSign.None;
            _tileStats = TileStatsManager.GetStats(_tileType);
            this.BuildReport();
        }

        /// <inheritdoc/>
        ITileReport ITileModel.GetReport()
        {
            return _report;
        }

        /// <inheritdoc/>
        void ITileModel.SetCombatantCallSign(CombatantCallSign combatantCallSign)
        {
            if (combatantCallSign != CombatantCallSign.None)
            {
                _logger.Info("Setting {} @ {}", combatantCallSign, _cubeCoordinates);
            }
            else
            {
                _logger.Info("Clearing {} @ {}", typeof(CombatantCallSign), _cubeCoordinates);
            }
            _combatantCallSign = combatantCallSign;
            this.BuildReport();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildReport()
        {
            _report = new TileReport.Builder()
                    .SetCombatantCallSign(_combatantCallSign)
                    .SetCubeCoordinates(_cubeCoordinates)
                    .SetTileType(_tileType)
                    .SetTileStats(_tileStats)
                    .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ICubeCoordinates _cubeCoordinates = null;

            // Todo
            private TileType _tileType = TileType.None;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ITileModel Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new model
                    return new TileModel(_cubeCoordinates, _tileType);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
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
            /// <param name="tileType"></param>
            /// <returns></returns>
            public Builder SetTileType(TileType tileType)
            {
                _tileType = tileType;
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
                // Check that _tileType has been set
                if (_tileType == TileType.None)
                {
                    argumentExceptionSet.Add(typeof(TileType).Name + " cannot be null.");
                }
                // Check that _cubeCoordinates has been set
                if (_cubeCoordinates == null)
                {
                    argumentExceptionSet.Add(typeof(ICubeCoordinates).Name + " cannot be null.");
                }

                return argumentExceptionSet;
            }
        }
    }
}