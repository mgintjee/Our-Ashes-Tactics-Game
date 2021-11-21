using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.Attributes.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Tiles.Attributes.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct SortieTileAttributes
        : ISortieTileAttributes
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
        private SortieTileAttributes(float fireCost, float moveCost)
        {
            _fireCost = fireCost;
            _moveCost = moveCost;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: _fireCost={1}, _moveCost={2}",
                GetType().Name, _fireCost, _moveCost);
        }

        /// <inheritdoc/>
        float ISortieTileAttributes.GetFireCost()
        {
            return _fireCost;
        }

        /// <inheritdoc/>
        float ISortieTileAttributes.GetMoveCost()
        {
            return _moveCost;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<ISortieTileAttributes>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="fireCost"></param>
                /// <returns></returns>
                IBuilder SetFireCost(float fireCost);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="moveCost"></param>
                /// <returns></returns>
                IBuilder SetMoveCost(float moveCost);
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
            private class InternalBuilder : AbstractBuilder<ISortieTileAttributes>, IBuilder
            {
                // Todo
                private float _fireCost = 0.0f;

                // Todo
                private float _moveCost = 0.0f;

                /// <inheritdoc/>
                IBuilder IBuilder.SetFireCost(float health)
                {
                    _moveCost = health;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetMoveCost(float armor)
                {
                    _fireCost = armor;
                    return this;
                }

                /// <inheritdoc/>
                protected override ISortieTileAttributes BuildObj()
                {
                    return new SortieTileAttributes(_fireCost, _moveCost);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _fireCost);
                    this.Validate(invalidReasons, _moveCost);
                }
            }
        }
    }
}