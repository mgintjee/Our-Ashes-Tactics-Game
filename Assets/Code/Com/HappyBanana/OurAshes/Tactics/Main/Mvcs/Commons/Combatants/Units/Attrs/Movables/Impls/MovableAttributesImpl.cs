using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Movables.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Movables.Impls
{
    /// <summary>
    /// Movable Attributes Impl
    /// </summary>
    public struct MovableAttributesImpl
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
        private MovableAttributesImpl(float movements, float actions)
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
            public interface IInternalBuilder
                : IBuilder<IMovableAttributes>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="actions"></param>
                /// <returns></returns>
                IInternalBuilder SetActions(float actions);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="movements"></param>
                /// <returns></returns>
                IInternalBuilder SetMovements(float movements);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="attributes"></param>
                /// <returns></returns>
                IMovableAttributes Build(ISet<IMovableAttributes> attributes);
            }

            /// <summary>
            /// Get the Builder for this object
            /// </summary>
            /// <returns></returns>
            public static IInternalBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Builder Impl for this object
            /// </summary>
            private class InternalBuilder
                : AbstractBuilder<IMovableAttributes>, IInternalBuilder
            {
                // Todo
                private float _actions = 0.0f;

                // Todo
                private float _movements = 0.0f;

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetActions(float actions)
                {
                    _actions = actions;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetMovements(float movements)
                {
                    _movements = movements;
                    return this;
                }

                /// <inheritdoc/>
                IMovableAttributes IInternalBuilder.Build(ISet<IMovableAttributes> attributes)
                {
                    _actions = 0.0f;
                    _movements = 0.0f;

                    foreach (IMovableAttributes attrs in attributes)
                    {
                        _actions += attrs.GetActions();
                        _movements += attrs.GetMovement();
                    }

                    return this.BuildObj();
                }

                /// <inheritdoc/>
                protected override IMovableAttributes BuildObj()
                {
                    // Instantiate a new attributes
                    return new MovableAttributesImpl(_actions, _movements);
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