using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Weapons.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Weapons.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Loadouts.Models.Traits.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Loadouts.Models.Traits.Implementations
{
    /// <summary>
    /// Trait Model Constants Implementation
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
            /// Builder Implementation for this object
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