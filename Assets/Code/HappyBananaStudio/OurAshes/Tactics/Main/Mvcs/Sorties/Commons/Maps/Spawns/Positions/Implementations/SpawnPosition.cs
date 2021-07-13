using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sorties.Maps.Spawns.Areas;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sorties.Maps.Spawns.Sides;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Spawns.Positions.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Spawns.Positions.Implementations
{
    /// <summary>
    /// Spawn Position Implementation
    /// </summary>
    public struct SpawnPosition : ISpawnPosition
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
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<ISpawnPosition>
            {
                IBuilder SetSpawnArea(SpawnArea spawnArea);

                IBuilder SetSpawnSide(SpawnSide spawnSide);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder : AbstractBuilder<ISpawnPosition>, IBuilder
            {
                // Todo
                private SpawnArea _spawnArea;

                // Todo
                private SpawnSide _spawnSide;

                /// <inheritdoc/>
                IBuilder IBuilder.SetSpawnArea(SpawnArea spawnArea)
                {
                    _spawnArea = spawnArea;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetSpawnSide(SpawnSide spawnSide)
                {
                    _spawnSide = spawnSide;
                    return this;
                }

                /// <inheritdoc/>
                protected override ISpawnPosition BuildObj()
                {
                    return new SpawnPosition(_spawnArea, _spawnSide);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _spawnArea);
                    this.Validate(invalidReasons, _spawnSide);
                }
            }
        }
    }
}