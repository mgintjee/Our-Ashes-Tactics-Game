using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Weapons.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Weapons.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Traits.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Traits.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Rarities;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Loadouts.Models.Traits.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Loadouts.Models.Traits.Impls
{
    /// <summary>
    /// Trait Model Constants Impl
    /// </summary>
    public struct TraitModelConstants : ITraitModelConstants
    {
        private readonly ICombatantAttributes _combatantAttributes;
        private readonly IWeaponAttributes _weaponAttributes;
        private readonly string _name;
        private readonly Rarity _rarity;
        private readonly TraitID _traitID;
        private readonly TraitType _traitType;

        private TraitModelConstants(ICombatantAttributes combatantAttributes, IWeaponAttributes weaponAttributes,
            string name, Rarity rarity, TraitID traitID, TraitType traitType)
        {
            _combatantAttributes = combatantAttributes;
            _weaponAttributes = weaponAttributes;
            _name = name;
            _rarity = rarity;
            _traitID = traitID;
            _traitType = traitType;
        }

        /// <inheritdoc/>
        ICombatantAttributes ITraitModelConstants.GetCombatantAttributes()
        {
            return _combatantAttributes;
        }

        /// <inheritdoc/>
        string ITraitModelConstants.GetName()
        {
            return _name;
        }

        /// <inheritdoc/>
        Rarity ITraitModelConstants.GetRarity()
        {
            return _rarity;
        }

        /// <inheritdoc/>
        TraitID ITraitModelConstants.GetTraitID()
        {
            return _traitID;
        }

        /// <inheritdoc/>
        TraitType ITraitModelConstants.GetTraitType()
        {
            return _traitType;
        }

        /// <inheritdoc/>
        IWeaponAttributes ITraitModelConstants.GetWeaponAttributes()
        {
            return _weaponAttributes;
        }

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder : IBuilder<ITraitModelConstants>
            {
                IBuilder SetName(string name);

                IBuilder SetTraitID(TraitID traitID);

                IBuilder SetCombatantAttributes(ICombatantAttributes combatantAttributes);

                IBuilder SetWeaponAttributes(IWeaponAttributes weaponAttributes);

                IBuilder SetRarity(Rarity rarity);

                IBuilder SetTraitType(TraitType traitType);
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
            /// Builder Impl for this object
            /// </summary>
            private class InternalBuilder : AbstractBuilder<ITraitModelConstants>, IBuilder
            {
                private TraitType _traitType;
                private TraitID _traitID;
                private ICombatantAttributes _combatantAttributes = CombatantAttributes.Builder.Get().Build();
                private IWeaponAttributes _weaponAttributes = WeaponAttributes.Builder.Get().Build();
                private string _name;
                private Rarity _rarity;

                /// <inheritdoc/>
                IBuilder IBuilder.SetCombatantAttributes(ICombatantAttributes combatantAttributes)
                {
                    _combatantAttributes = combatantAttributes;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetName(string name)
                {
                    _name = name;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetRarity(Rarity rarity)
                {
                    _rarity = rarity;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetWeaponAttributes(IWeaponAttributes weaponAttributes)
                {
                    _weaponAttributes = weaponAttributes;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetTraitID(TraitID traitID)
                {
                    _traitID = traitID;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetTraitType(TraitType traitType)
                {
                    _traitType = traitType;
                    return this;
                }

                /// <inheritdoc/>
                protected override ITraitModelConstants BuildObj()
                {
                    // Instantiate a new attributes
                    return new TraitModelConstants(_combatantAttributes, _weaponAttributes, _name, _rarity, _traitID, _traitType);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _combatantAttributes);
                    this.Validate(invalidReasons, _weaponAttributes);
                    this.Validate(invalidReasons, _name);
                    this.Validate(invalidReasons, _rarity);
                    this.Validate(invalidReasons, _traitType);
                    this.Validate(invalidReasons, _traitID);
                }
            }
        }
    }
}