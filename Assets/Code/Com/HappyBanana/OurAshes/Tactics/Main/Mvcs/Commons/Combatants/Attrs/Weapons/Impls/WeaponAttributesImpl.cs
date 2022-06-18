using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Weapons.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Weapons.Impls
{
    /// <summary>
    /// Weapon Attributes Impl
    /// </summary>
    public struct WeaponAttributesImpl
        : IWeaponAttributes
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
        private WeaponAttributesImpl(float accuracy, float armorDamage,
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
            return string.Format("{0}: _accuracy={1}, _armorDamage={2}, " +
                "_armorPenetration={3}, _healthDamage={4}, _range={5}, _salvo={6}",
                this.GetType().Name, _accuracy, _armorDamage,
                _armorPenetration, _healthDamage, _range, _salvo);
        }

        /// <inheritdoc/>
        float IWeaponAttributes.GetArmorDamage()
        {
            return _armorDamage;
        }

        /// <inheritdoc/>
        float IWeaponAttributes.GetArmorPenetration()
        {
            return _armorPenetration;
        }

        /// <inheritdoc/>
        float IWeaponAttributes.GetAccuracy()
        {
            return _accuracy;
        }

        /// <inheritdoc/>
        float IWeaponAttributes.GetHealthDamage()
        {
            return _healthDamage;
        }

        /// <inheritdoc/>
        float IWeaponAttributes.GetRange()
        {
            return _range;
        }

        /// <inheritdoc/>
        float IWeaponAttributes.GetSalvo()
        {
            return _salvo;
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
                : IBuilder<IWeaponAttributes>
            {
                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="healthDamage"></param>
                /// <returns></returns>
                IInternalBuilder SetHealthDamage(float healthDamage);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="armorDamage"></param>
                /// <returns></returns>
                IInternalBuilder SetArmorDamage(float armorDamage);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="armorPenetration"></param>
                /// <returns></returns>
                IInternalBuilder SetArmorPenetration(float armorPenetration);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="accuracy"></param>
                /// <returns></returns>
                IInternalBuilder SetAccuracy(float accuracy);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="range"></param>
                /// <returns></returns>
                IInternalBuilder SetRange(float range);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="salvo"></param>
                /// <returns></returns>
                IInternalBuilder SetSalvo(float salvo);

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="attributes"></param>
                /// <returns></returns>
                IWeaponAttributes Build(ISet<IWeaponAttributes> attributes);
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
                : AbstractBuilder<IWeaponAttributes>, IInternalBuilder
            {
                // Todo
                private float _armorDamage = 0.0f;

                // Todo
                private float _armorPenetration = 0.0f;

                // Todo
                private float _accuracy = 0.0f;

                // Todo
                private float _healthDamage = 0.0f;

                // Todo
                private float _range = 0.0f;

                // Todo
                private float _salvo = 0.0f;

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetHealthDamage(float healthDamage)
                {
                    _healthDamage = healthDamage;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetArmorDamage(float armorDamage)
                {
                    _armorDamage = armorDamage;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetArmorPenetration(float armorPenetration)
                {
                    _armorPenetration = armorPenetration;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetAccuracy(float accuracy)
                {
                    _accuracy = accuracy;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetRange(float range)
                {
                    _range = range;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetSalvo(float salvo)
                {
                    _salvo = salvo;
                    return this;
                }

                /// <inheritdoc/>
                IWeaponAttributes IInternalBuilder.Build(ISet<IWeaponAttributes> attributes)
                {
                    _accuracy = 0.0f;
                    _armorDamage = 0.0f;
                    _armorPenetration = 0.0f;
                    _healthDamage = 0.0f;
                    _range = 0.0f;
                    _salvo = 0.0f;

                    foreach (IWeaponAttributes attrs in attributes)
                    {
                        _accuracy += attrs.GetAccuracy();
                        _armorDamage += attrs.GetArmorDamage();
                        _armorPenetration += attrs.GetArmorPenetration();
                        _healthDamage += attrs.GetHealthDamage();
                        _range += attrs.GetRange();
                        _salvo += attrs.GetSalvo();
                    }

                    return this.BuildObj();
                }

                /// <inheritdoc/>
                protected override IWeaponAttributes BuildObj()
                {
                    // Instantiate a new attributes
                    return new WeaponAttributesImpl(_accuracy, _armorDamage,
                        _armorPenetration, _healthDamage, _range, _salvo);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _accuracy);
                    this.Validate(invalidReasons, _armorDamage);
                    this.Validate(invalidReasons, _armorPenetration);
                    this.Validate(invalidReasons, _healthDamage);
                    this.Validate(invalidReasons, _range);
                    this.Validate(invalidReasons, _salvo);
                }
            }
        }
    }
}