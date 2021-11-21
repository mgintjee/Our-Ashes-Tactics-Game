using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Weapons.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Weapons.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Gears.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Gears.Sizes;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Gears.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Traits.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Rarities;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Loadouts.Models.Gears.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Loadouts.Models.Gears.Implementations
{
    /// <summary>
    /// Gear Model Constants Implementation
    /// </summary>
    public struct GearModelConstants : IGearModelConstants
    {
        private readonly ICollection<TraitType> _traitTypes;
        private readonly ICombatantAttributes _combatantAttributes;
        private readonly ICollection<CombatantType> _combatantTypes;
        private readonly GearID _gearID;
        private readonly GearSize _gearSize;
        private readonly GearType _gearType;
        private readonly IWeaponAttributes _weaponAttributes;
        private readonly string _name;
        private readonly Rarity _rarity;

        private GearModelConstants(ICombatantAttributes combatantAttributes, ICollection<CombatantType> combatantTypes,
            GearID gearID, GearSize gearSize, GearType gearType, IWeaponAttributes weaponAttributes, string name,
            Rarity rarity, ICollection<TraitType> traitTypes)
        {
            _combatantAttributes = combatantAttributes;
            _combatantTypes = combatantTypes;
            _gearID = gearID;
            _gearSize = gearSize;
            _gearType = gearType;
            _name = name;
            _weaponAttributes = weaponAttributes;
            _rarity = rarity;
            _traitTypes = traitTypes;
        }

        /// <inheritdoc/>
        ICombatantAttributes IGearModelConstants.GetCombatantAttributes()
        {
            return _combatantAttributes;
        }

        /// <inheritdoc/>
        ISet<CombatantType> IGearModelConstants.GetCombatantTypes()
        {
            return new HashSet<CombatantType>(_combatantTypes);
        }

        /// <inheritdoc/>
        GearID IGearModelConstants.GetGearID()
        {
            return _gearID;
        }

        /// <inheritdoc/>
        GearSize IGearModelConstants.GetGearSize()
        {
            return _gearSize;
        }

        /// <inheritdoc/>
        GearType IGearModelConstants.GetGearType()
        {
            return _gearType;
        }

        /// <inheritdoc/>
        string IGearModelConstants.GetName()
        {
            return _name;
        }

        /// <inheritdoc/>
        Rarity IGearModelConstants.GetRarity()
        {
            return _rarity;
        }

        /// <inheritdoc/>
        ISet<TraitType> IGearModelConstants.GetTraitTypes()
        {
            return new HashSet<TraitType>(_traitTypes);
        }

        /// <inheritdoc/>
        IWeaponAttributes IGearModelConstants.GetWeaponAttributes()
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
            public interface IBuilder : IBuilder<IGearModelConstants>
            {
                IBuilder SetCombatantAttributes(ICombatantAttributes combatantAttributes);

                IBuilder SetGearID(GearID gearID);

                IBuilder SetGearType(GearType gearType);

                IBuilder SetGearSize(GearSize gearSize);

                IBuilder SetCombatantTypes(ICollection<CombatantType> combatantType);

                IBuilder SetWeaponAttributes(IWeaponAttributes weaponAttributes);

                IBuilder SetName(string name);

                IBuilder SetRarity(Rarity rarity);

                IBuilder SetTraitTypes(ICollection<TraitType> traitTypes);
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
            private class InternalBuilder : AbstractBuilder<IGearModelConstants>, IBuilder
            {
                private ICombatantAttributes _combatantAttributes = CombatantAttributes.Builder.Get().Build();
                private ICollection<CombatantType> _combatantTypes;
                private GearID _gearID;
                private GearSize _gearSize;
                private GearType _gearType;
                private IWeaponAttributes _weaponAttributes = WeaponAttributes.Builder.Get().Build();
                private string _name;
                private Rarity _rarity;
                private ISet<TraitType> _traitTypes;

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
                IBuilder IBuilder.SetGearID(GearID gearID)
                {
                    _gearID = gearID;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetGearType(GearType gearType)
                {
                    _gearType = gearType;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetGearSize(GearSize gearSize)
                {
                    _gearSize = gearSize;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetCombatantTypes(ICollection<CombatantType> combatantTypes)
                {
                    _combatantTypes = new HashSet<CombatantType>(combatantTypes);
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetWeaponAttributes(IWeaponAttributes weaponAttributes)
                {
                    _weaponAttributes = weaponAttributes;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetTraitTypes(ICollection<TraitType> traitTypes)
                {
                    _traitTypes = new HashSet<TraitType>(traitTypes);
                    return this;
                }

                /// <inheritdoc/>
                protected override IGearModelConstants BuildObj()
                {
                    // Instantiate a new attributes
                    return new GearModelConstants(_combatantAttributes, _combatantTypes, _gearID,
                        _gearSize, _gearType, _weaponAttributes, _name, _rarity, _traitTypes);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _combatantAttributes);
                    this.Validate(invalidReasons, _combatantTypes);
                    this.Validate(invalidReasons, _gearID);
                    this.Validate(invalidReasons, _gearSize);
                    this.Validate(invalidReasons, _weaponAttributes);
                    this.Validate(invalidReasons, _name);
                    this.Validate(invalidReasons, _rarity);
                    this.Validate(invalidReasons, _gearType);
                }
            }
        }
    }
}