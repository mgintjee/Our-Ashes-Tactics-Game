using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Attributes.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Tiles.Attributes.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct TileAttributes
        : ITileAttributes
    {
        // Todo
        private readonly float _fireCost;

        // Todo
        private readonly float _moveCost;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="fireCost"></param>
        /// <param name="moveCost"></param>
        private TileAttributes(float fireCost, float moveCost)
        {
            _fireCost = fireCost;
            _moveCost = moveCost;
        }

        /// <inheritdoc/>
        float ITileAttributes.GetFireCost()
        {
            return _fireCost;
        }

        /// <inheritdoc/>
        float ITileAttributes.GetMoveCost()
        {
            return _moveCost;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private float _fireCost = 0.0f;

            // Todo
            private float _moveCost = 0.0f;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ITileAttributes Build()
            {
                // Instantiate a new attributes
                return new TileAttributes(_fireCost, _moveCost);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="fireCost"></param>
            /// <returns></returns>
            public Builder SetFireCost(float fireCost)
            {
                _fireCost = fireCost;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="moveCost"></param>
            /// <returns></returns>
            public Builder SetMoveCost(float moveCost)
            {
                _moveCost = moveCost;
                return this;
            }
        }
    }
}