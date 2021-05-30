using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Fireables.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Fireables.Implementations
{
    /// <summary>
    /// Fireable Attributes Implementation
    /// </summary>
    public struct FireableAttributes
        : IFireableAttributes
    {
        // Armor Damage Points
        private readonly float _armorDamage;

        // Armor Penetration Points
        private readonly float _armorPenetration;

        // Accuracy Points
        private readonly float _accuracy;

        // Health Damage Points
        private readonly float _healthDamage;

        // Range Points
        private readonly float _range;

        // Salvo Points
        private readonly float _salvo;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="accuracy">        </param>
        /// <param name="armorDamage">     </param>
        /// <param name="armorPenetration"></param>
        /// <param name="healthDamage">    </param>
        /// <param name="range">           </param>
        /// <param name="salvo">           </param>
        private FireableAttributes(float accuracy, float armorDamage,
            float armorPenetration, float healthDamage, float range, float salvo)
        {
            _accuracy = accuracy;
            _armorDamage = armorDamage;
            _armorPenetration = armorPenetration;
            _healthDamage = healthDamage;
            _range = range;
            _salvo = salvo;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}:" +
                "\n\t>_accuracy={1}, _armorDamage={2}, " +
                "\n\t>_armorPenetration={3}, _healthDamage={4}, " +
                "\n\t>_range={5}, _salvo={6}",
                this.GetType().Name, _accuracy, _armorDamage,
                _armorPenetration, _healthDamage, _range, _salvo);
        }

        /// <inheritdoc/>
        float IFireableAttributes.GetArmorDamage()
        {
            return _armorDamage;
        }

        /// <inheritdoc/>
        float IFireableAttributes.GetArmorPenetration()
        {
            return _armorPenetration;
        }

        /// <inheritdoc/>
        float IFireableAttributes.GetAccuracy()
        {
            return _accuracy;
        }

        /// <inheritdoc/>
        float IFireableAttributes.GetHealthDamage()
        {
            return _healthDamage;
        }

        /// <inheritdoc/>
        float IFireableAttributes.GetRange()
        {
            return _range;
        }

        /// <inheritdoc/>
        float IFireableAttributes.GetSalvo()
        {
            return _salvo;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private float _armorDamage = 0;

            // Todo
            private float _armorPenetration = 0;

            // Todo
            private float _accuracy = 0;

            // Todo
            private float _healthDamage = 0;

            // Todo
            private float _range = 0;

            // Todo
            private float _salvo = 0;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IFireableAttributes Build()
            {
                // Instantiate a new attributes
                return new FireableAttributes(_accuracy, _armorDamage,
                    _armorPenetration, _healthDamage, _range, _salvo);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IFireableAttributes Build(ICollection<IFireableAttributes> fireableAttributes)
            {
                _accuracy = 0;
                _armorDamage = 0;
                _armorPenetration = 0;
                _healthDamage = 0;
                _range = 0;
                _salvo = 0;

                foreach (IFireableAttributes attributes in fireableAttributes)
                {
                    _accuracy += attributes.GetAccuracy();
                    _armorDamage += attributes.GetArmorDamage();
                    _armorPenetration += attributes.GetArmorPenetration();
                    _healthDamage += attributes.GetHealthDamage();
                    _range += attributes.GetRange();
                    _salvo += attributes.GetSalvo();
                }

                // Instantiate a new attributes
                return new FireableAttributes(_accuracy, _armorDamage,
                    _armorPenetration, _healthDamage, _range, _salvo);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="armorDamage"></param>
            public Builder SetArmorDamage(float armorDamage)
            {
                _armorDamage = armorDamage;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="armorPenetration"></param>
            public Builder SetArmorPenetration(float armorPenetration)
            {
                _armorPenetration = armorPenetration;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="accuracy"></param>
            public Builder SetAccuracy(float accuracy)
            {
                _accuracy = accuracy;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="healthDamage"></param>
            public Builder SetHealthDamage(float healthDamage)
            {
                _healthDamage = healthDamage;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="range"></param>
            public Builder SetRange(float range)
            {
                _range = range;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="salvo"></param>
            public Builder SetSalvo(float salvo)
            {
                _salvo = salvo;
                return this;
            }
        }
    }
}