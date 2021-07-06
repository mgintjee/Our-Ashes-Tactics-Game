using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Stats.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Types.Enums;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Reports.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TileReport
        : AbstractReport, ITileReport
    {
        // Todo
        private readonly CombatantCallSign _combatantCallSign;

        // Todo
        private readonly ICubeCoordinates _cubeCoordinates;

        // Todo
        private readonly ITileStats _tileStats;

        // Todo
        private readonly TileType _tileType;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <param name="sortieTileType"> </param>
        /// <param name="callSign">       </param>
        private TileReport(ICubeCoordinates cubeCoordinates,
            TileType sortieTileType, CombatantCallSign callSign, ITileStats tileStats)
        {
            _cubeCoordinates = cubeCoordinates;
            _tileType = sortieTileType;
            _combatantCallSign = callSign;
            _tileStats = tileStats;
        }

        /// <inheritdoc/>
        CombatantCallSign ITileReport.GetCombatantCallSign()
        {
            return _combatantCallSign;
        }

        /// <inheritdoc/>
        ICubeCoordinates ITileReport.GetCubeCoordinates()
        {
            return _cubeCoordinates;
        }

        /// <inheritdoc/>
        ITileStats ITileReport.GetTileStats()
        {
            return _tileStats;
        }

        /// <inheritdoc/>
        TileType ITileReport.GetTileType()
        {
            return _tileType;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}, {1}, {2}",
                _cubeCoordinates, StringUtils.Format(_combatantCallSign), _tileStats);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private CombatantCallSign _combatantCallSign = CombatantCallSign.None;

            // Todo
            private ICubeCoordinates _cubeCoordinates = null;

            // Todo
            private ITileStats _tileStats = null;

            // Todo
            private TileType _tileType = TileType.None;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ITileReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new TileReport(_cubeCoordinates, _tileType, _combatantCallSign, _tileStats);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantCallSign"></param>
            /// <returns></returns>
            public Builder SetCombatantCallSign(CombatantCallSign combatantCallSign)
            {
                _combatantCallSign = combatantCallSign;
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
            /// <param name="tileStats"></param>
            /// <returns></returns>
            public Builder SetTileStats(ITileStats tileStats)
            {
                _tileStats = tileStats;
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
                // Check that cubeCoordinates has been set
                if (_cubeCoordinates == null)
                {
                    argumentExceptionSet.Add(typeof(ICubeCoordinates) + " cannot be null.");
                }
                // Check that sortieTileType has been set
                if (_tileType == TileType.None)
                {
                    argumentExceptionSet.Add(typeof(TileType) + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}