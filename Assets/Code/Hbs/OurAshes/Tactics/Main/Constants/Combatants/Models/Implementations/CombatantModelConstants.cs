using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Gears.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Rarities;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Combatants.Models.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Combatants.Models.Implementations
{
    /// <summary>
    /// Combatant Model Constants Implementation
    /// </summary>
    public struct CombatantModelConstants : ICombatantModelConstants
    {
        private readonly ICollection<GearType> _gearTypes;
        private readonly ICombatantAttributes _combatantAttributes;
        private readonly CombatantID _combatantID;
        private readonly CombatantType _combatantType;
        private readonly string _name;
        private readonly Rarity _rarity;

        private CombatantModelConstants(ICombatantAttributes combatantAttributes, CombatantID combatantID,
            CombatantType combatantType, string name, Rarity rarity, ICollection<GearType> gearTypes)
        {
            _combatantAttributes = combatantAttributes;
            _combatantID = combatantID;
            _combatantType = combatantType;
            _name = name;
            _rarity = rarity;
            _gearTypes = gearTypes;
        }

        ICombatantAttributes ICombatantModelConstants.GetCombatantAttributes()
        {
            return _combatantAttributes;
        }

        CombatantID ICombatantModelConstants.GetCombatantID()
        {
            return _combatantID;
        }

        CombatantType ICombatantModelConstants.GetCombatantType()
        {
            return _combatantType;
        }

        ISet<GearType> ICombatantModelConstants.GetGearTypes()
        {
            return new HashSet<GearType>(_gearTypes);
        }

        string ICombatantModelConstants.GetName()
        {
            return _name;
        }

        Rarity ICombatantModelConstants.GetRarity()
        {
            return _rarity;
        }

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder : IBuilder<ICombatantModelConstants>
            {
                IBuilder SetCombatantAttributes(ICombatantAttributes combatantAttributes);

                IBuilder SetCombatantID(CombatantID combatantID);

                IBuilder SetCombatantType(CombatantType combatantType);

                IBuilder SetName(string name);

                IBuilder SetRarity(Rarity rarity);

                IBuilder SetGearTypes(ICollection<GearType> gearTypes);
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
            private class InternalBuilder : AbstractBuilder<ICombatantModelConstants>, IBuilder
            {
                private ICombatantAttributes _combatantAttributes;
                private CombatantID _combatantID;
                private CombatantType _combatantType;
                private string _name;
                private Rarity _rarity;
                private ICollection<GearType> _gearTypes;

                IBuilder IBuilder.SetCombatantAttributes(ICombatantAttributes combatantAttributes)
                {
                    _combatantAttributes = combatantAttributes;
                    return this;
                }

                IBuilder IBuilder.SetCombatantID(CombatantID combatantID)
                {
                    _combatantID = combatantID;
                    return this;
                }

                IBuilder IBuilder.SetCombatantType(CombatantType combatantType)
                {
                    _combatantType = combatantType;
                    return this;
                }

                IBuilder IBuilder.SetName(string name)
                {
                    _name = name;
                    return this;
                }

                IBuilder IBuilder.SetRarity(Rarity rarity)
                {
                    _rarity = rarity;
                    return this;
                }

                IBuilder IBuilder.SetGearTypes(ICollection<GearType> gearTypes)
                {
                    _gearTypes = new HashSet<GearType>(gearTypes);
                    return this;
                }

                /// <inheritdoc/>
                protected override ICombatantModelConstants BuildObj()
                {
                    // Instantiate a new attributes
                    return new CombatantModelConstants(_combatantAttributes, _combatantID, _combatantType, _name, _rarity, _gearTypes);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _combatantAttributes);
                    this.Validate(invalidReasons, _combatantID);
                    this.Validate(invalidReasons, _combatantType);
                    this.Validate(invalidReasons, _name);
                    this.Validate(invalidReasons, _rarity);
                    this.Validate(invalidReasons, _gearTypes);
                }
            }
        }
    }
}