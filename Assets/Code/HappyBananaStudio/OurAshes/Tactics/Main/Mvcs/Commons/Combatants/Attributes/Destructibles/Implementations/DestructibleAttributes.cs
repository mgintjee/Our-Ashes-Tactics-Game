using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Destructibles.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Destructibles.Implementations
{
    /// <summary>
    /// Destructible Attributes Implementation
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
        /// <param name="APs"></param>
        /// <param name="HPs"></param>
        private DestructibleAttributes(float APs, float HPs)
        {
            this._armor = APs;
            this._health = HPs;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: _armor={1}, _health={2}",
                this.GetType().Name, _armor, _health);
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
            // Todo
            private float _armor = 0.0f;

            // Todo
            private float _health = 0.0f;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IDestructibleAttributes Build()
            {
                // Instantiate a new Attributes
                return new DestructibleAttributes(_armor, _health);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IDestructibleAttributes Build(ICollection<IDestructibleAttributes> destructibleAttributes)
            {
                this._armor = 0;
                this._health = 0;

                foreach (IDestructibleAttributes attributes in destructibleAttributes)
                {
                    this._armor += attributes.GetArmor();
                    this._health += attributes.GetHealth();
                }

                // Instantiate a new Attributes
                return new DestructibleAttributes(this._armor, this._health);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="armor"></param>
            public Builder SetArmor(float armor)
            {
                this._armor = armor;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="health"></param>
            public Builder SetHealth(float health)
            {
                this._health = health;
                return this;
            }
        }
    }
}