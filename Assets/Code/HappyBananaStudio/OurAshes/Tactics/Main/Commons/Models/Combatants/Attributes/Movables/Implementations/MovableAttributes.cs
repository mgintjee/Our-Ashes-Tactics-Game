using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Movables.Implementations
{
    /// <summary>
    /// Movable Attributes Implementation
    /// </summary>
    public struct MovableAttributes
        : IMovableAttributes
    {
        // Todo
        private readonly float _actions;

        // Todo
        private readonly float _movements;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="movements"></param>
        /// <param name="actions">  </param>
        private MovableAttributes(float movements, float actions)
        {
            _movements = movements;
            _actions = actions;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: _actions={1}, _movements={2}",
                this.GetType().Name, _actions, _movements);
        }

        /// <inheritdoc/>
        float IMovableAttributes.GetActions()
        {
            return _actions;
        }

        /// <inheritdoc/>
        float IMovableAttributes.GetMovement()
        {
            return _movements;
        }

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder : IBuilder<IMovableAttributes>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="actions"></param>
                /// <returns></returns>
                IBuilder SetActions(float actions);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="movements"></param>
                /// <returns></returns>
                IBuilder SetMovements(float movements);
            }

            /// <summary>
            /// Get the Builder for this object
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Builder Implementation for this object
            /// </summary>
            private class InternalBuilder : AbstractBuilder<IMovableAttributes>, IBuilder
            {
                // Todo
                private float _actions = 0.0f;

                // Todo
                private float _movements = 0.0f;

                /// <inheritdoc/>
                IBuilder IBuilder.SetActions(float actions)
                {
                    _actions = actions;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetMovements(float movements)
                {
                    _movements = movements;
                    return this;
                }

                /// <inheritdoc/>
                protected override IMovableAttributes BuildObj()
                {
                    // Instantiate a new attributes
                    return new MovableAttributes(_actions, _movements);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _actions);
                    this.Validate(invalidReasons, _movements);
                }
            }
        }
    }
}