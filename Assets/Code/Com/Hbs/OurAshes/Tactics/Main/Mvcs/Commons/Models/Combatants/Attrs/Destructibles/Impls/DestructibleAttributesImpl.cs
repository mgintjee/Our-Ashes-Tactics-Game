using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Combatants.Attrs.Destructibles.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Combatants.Attrs.Destructibles.Impls
{
    /// <summary>
    /// Destructible Attributes Impl
    /// </summary>
    public struct DestructibleAttributesImpl
        : IDestructibleAttributes
    {
        // Todo
        private readonly float _armor;

        // Todo
        private readonly float _health;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armor"> </param>
        /// <param name="health"></param>
        private DestructibleAttributesImpl(float armor, float health)
        {
            _armor = armor;
            _health = health;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: _armor={1}, _health={2}",
                GetType().Name, _armor, _health);
        }

        /// <inheritdoc/>
        float IDestructibleAttributes.GetArmor()
        {
            return _armor;
        }

        /// <inheritdoc/>
        float IDestructibleAttributes.GetHealth()
        {
            return _health;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IInternalBuilder
                : IBuilder<IDestructibleAttributes>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="health"></param>
                /// <returns></returns>
                IInternalBuilder SetHealth(float health);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="armor"></param>
                /// <returns></returns>
                IInternalBuilder SetArmor(float armor);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="attributes"></param>
                /// <returns></returns>
                IDestructibleAttributes Build(ISet<IDestructibleAttributes> attributes);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IInternalBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder
                : AbstractBuilder<IDestructibleAttributes>, IInternalBuilder
            {
                // Todo
                private float _armor = 0.0f;

                // Todo
                private float _health = 0.0f;

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetHealth(float health)
                {
                    _health = health;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetArmor(float armor)
                {
                    _armor = armor;
                    return this;
                }

                /// <inheritdoc/>
                IDestructibleAttributes IInternalBuilder.Build(ISet<IDestructibleAttributes> attributes)
                {
                    _health = 0.0f;
                    _armor = 0.0f;

                    foreach (IDestructibleAttributes attrs in attributes)
                    {
                        _health += attrs.GetHealth();
                        _armor += attrs.GetArmor();
                    }

                    return this.BuildObj();
                }

                /// <inheritdoc/>
                protected override IDestructibleAttributes BuildObj()
                {
                    return new DestructibleAttributesImpl(_armor, _health);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _armor);
                    this.Validate(invalidReasons, _health);
                }
            }
        }
    }
}