using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Maps.Spawns.Areas;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Maps.Spawns.Sides;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Spawns.Positions.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Spawns.Positions.Implementations
{
    /// <summary>
    /// Spawn Position Implementation
    /// </summary>
    public struct SpawnPosition
        : ISpawnPosition
    {
        // Todo
        private readonly SpawnSide _spawnSide;

        // Todo
        private readonly SpawnArea _spawnArea;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="spawnArea"></param>
        /// <param name="spawnSide"></param>
        private SpawnPosition(SpawnArea spawnArea, SpawnSide spawnSide)
        {
            _spawnArea = spawnArea;
            _spawnSide = spawnSide;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}, {2}",
                this.GetType().Name,
                StringUtils.Format(_spawnArea),
                StringUtils.Format(_spawnSide));
        }

        /// <inheritdoc/>
        SpawnArea ISpawnPosition.GetSpawnArea()
        {
            return _spawnArea;
        }

        /// <inheritdoc/>
        SpawnSide ISpawnPosition.GetSpawnSide()
        {
            return _spawnSide;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private SpawnSide _spawnSide = SpawnSide.None;

            // Todo
            private SpawnArea _spawnArea = SpawnArea.None;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ISpawnPosition Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new position
                    return new SpawnPosition(_spawnArea, _spawnSide);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="spawnArea"></param>
            /// <returns></returns>
            public Builder SetSpawnArea(SpawnArea spawnArea)
            {
                _spawnArea = spawnArea;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="spawnSide"></param>
            /// <returns></returns>
            public Builder SetSpawnSide(SpawnSide spawnSide)
            {
                _spawnSide = spawnSide;
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
                // Check that _spawnArea has been set
                if (_spawnArea == SpawnArea.None)
                {
                    argumentExceptionSet.Add(typeof(SpawnArea).Name + " cannot be none.");
                }
                // Check that _spawnSide has been set
                if (_spawnSide == SpawnSide.None)
                {
                    argumentExceptionSet.Add(typeof(SpawnSide).Name + " cannot be none.");
                }
                return argumentExceptionSet;
            }
        }
    }
}