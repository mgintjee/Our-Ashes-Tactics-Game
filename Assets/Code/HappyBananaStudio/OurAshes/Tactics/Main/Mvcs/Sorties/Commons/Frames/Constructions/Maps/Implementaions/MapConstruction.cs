using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Maps.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Spawns.Positions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Types.Enums;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Maps.Implementaions
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct MapConstruction
        : IMapConstruction
    {
        // Todo
        private readonly bool _mirroredMap;

        // Todo
        private readonly int _radius;

        // Todo
        private readonly IDictionary<CombatantCallSign, ISpawnPosition> _combatantCallSignSpawnPositions;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mapType">    </param>
        /// <param name="radius">     </param>
        /// <param name="mirroredMap"></param>
        private MapConstruction(int radius, bool mirroredMap,
            IDictionary<CombatantCallSign, ISpawnPosition> combatantCallSignSpawnPositions)
        {
            _mirroredMap = mirroredMap;
            _radius = radius;
            this._combatantCallSignSpawnPositions = combatantCallSignSpawnPositions;
        }

        /// <inheritdoc/>
        IDictionary<CombatantCallSign, ISpawnPosition> IMapConstruction.GetCombatantCallSignSpawnPosition()
        {
            return new Dictionary<CombatantCallSign, ISpawnPosition>(this._combatantCallSignSpawnPositions);
        }

        /// <inheritdoc/>
        bool IMapConstruction.GetMirroredMap()
        {
            return _mirroredMap;
        }

        /// <inheritdoc/>
        int IMapConstruction.GetRadius()
        {
            return _radius;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private bool _mirroredMap = false;

            // Todo
            private int _radius = 0;

            // Todo
            private IDictionary<CombatantCallSign, ISpawnPosition> _combatantCallSignSpawnPositions = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMapConstruction Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new construction
                    return new MapConstruction(_radius, _mirroredMap, _combatantCallSignSpawnPositions);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mirroredMap"></param>
            /// <returns></returns>
            public Builder SetMirroredMap(bool mirroredMap)
            {
                _mirroredMap = mirroredMap;
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
            /// <param name="combatantCallSignSpawnPositions"></param>
            /// <returns></returns>
            public Builder SetCombatantCallSignCubeCoordinates(IDictionary<CombatantCallSign, ISpawnPosition> combatantCallSignSpawnPositions)
            {
                if (combatantCallSignSpawnPositions != null)
                {
                    this._combatantCallSignSpawnPositions =
                        new Dictionary<CombatantCallSign, ISpawnPosition>(combatantCallSignSpawnPositions);
                }
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
                if (_radius < 3)
                {
                    argumentExceptionSet.Add("_radius cannot be less than 3.");
                }
                return argumentExceptionSet;
            }
        }
    }
}