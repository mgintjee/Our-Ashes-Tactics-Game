using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Reports.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Tiles.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Maps.Tiles.Implementations
{
    /// <summary>
    /// Sortie Tile Model
    /// </summary>
    public class TileModel
        : ITileModel
    {
        // Todo
        private readonly ICubeCoordinates _cubeCoordinates;

        // Todo
        private readonly TileType _tileType;

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
            _cubeCoordinates = cubeCoordinates;
            _tileType = tileType;
            _combatantCallSign = CombatantCallSign.None;
            _report = new TileReport.Builder()
                    .SetCombatantCallSign(_combatantCallSign)
                    .SetCubeCoordinates(_cubeCoordinates)
                    .SetTileType(_tileType)
                    .Build();
        }

        /// <inheritdoc/>
        ITileReport ITileModel.GetReport()
        {
            return _report;
        }

        /// <inheritdoc/>
        void ITileModel.SetCombatantCallSign(CombatantCallSign combatantCallSign)
        {
            _combatantCallSign = combatantCallSign;
            _report = new TileReport.Builder()
                    .SetCombatantCallSign(_combatantCallSign)
                    .SetCubeCoordinates(_cubeCoordinates)
                    .SetTileType(_tileType)
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