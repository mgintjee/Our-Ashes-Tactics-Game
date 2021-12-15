using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Destructibles.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Destructibles.Impls
{
    /// <summary>
    /// Destructible Attributes Impl
    /// </summary>
    public struct DestructibleAttributes
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
        private DestructibleAttributes(float armor, float health)
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
            public interface IBuilder : IBuilder<IDestructibleAttributes>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="health"></param>
                /// <returns></returns>
                IBuilder SetHealth(float health);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="armor"></param>
                /// <returns></returns>
                IBuilder SetArmor(float armor);
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
            private class InternalBuilder : AbstractBuilder<IDestructibleAttributes>, IBuilder
            {
                // Todo
                private float _armor = 0.0f;

                // Todo
                private float _health = 0.0f;

                /// <inheritdoc/>
                IBuilder IBuilder.SetHealth(float health)
                {
                    _health = health;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetArmor(float armor)
                {
                    _armor = armor;
                    return this;
                }

                /// <inheritdoc/>
                protected override IDestructibleAttributes BuildObj()
                {
                    return new DestructibleAttributes(_armor, _health);
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