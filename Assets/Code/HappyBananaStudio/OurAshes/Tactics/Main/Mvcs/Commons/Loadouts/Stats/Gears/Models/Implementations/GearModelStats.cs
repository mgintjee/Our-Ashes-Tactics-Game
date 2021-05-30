using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Sizes.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Gears.Models.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Gears.Models.Implementations
{
    /// <summary>
    /// Gear Model Stats Implementation
    /// </summary>
    public struct GearModelStats
        : IGearModelStats
    {
        // Todo
        private readonly ICombatantAttributes _combatantAttributes;

        // Todo
        private readonly CombatantType _combatantType;

        // Todo
        private readonly GearSize _gearSize;

        // Todo
        private readonly GearType _gearType;

        // Todo
        private readonly Rarity _rarity;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantAttributes"></param>
        /// <param name="combatantType">      </param>
        /// <param name="gearSize">           </param>
        /// <param name="gearType">           </param>
        /// <param name="rarity">             </param>
        private GearModelStats(ICombatantAttributes combatantAttributes,
            CombatantType combatantType, GearSize gearSize, GearType gearType, Rarity rarity)
        {
            _combatantAttributes = combatantAttributes;
            _combatantType = combatantType;
            _gearSize = gearSize;
            _gearType = gearType;
            _rarity = rarity;
        }

        ICombatantAttributes IGearModelStats.GetCombatantAttributes()
        {
            return _combatantAttributes;
        }

        CombatantType IGearModelStats.GetCombatantType()
        {
            return _combatantType;
        }

        GearSize IGearModelStats.GetGearSize()
        {
            return _gearSize;
        }

        GearType IGearModelStats.GetGearType()
        {
            return _gearType;
        }

        Rarity IGearModelStats.GetRarity()
        {
            return _rarity;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ICombatantAttributes _combatantAttributes;

            // Todo
            private CombatantType _combatantType;

            // Todo
            private GearSize _gearSize;

            // Todo
            private GearType _gearType;

            // Todo
            private Rarity _rarity;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IGearModelStats Build()
            {
                return new GearModelStats(_combatantAttributes,
                    _combatantType, _gearSize, _gearType, _rarity);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantAttributes"></param>
            /// <returns></returns>
            public Builder SetCombatantAttributes(ICombatantAttributes combatantAttributes)
            {
                _combatantAttributes = combatantAttributes;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantType"></param>
            /// <returns></returns>
            public Builder SetCombatantType(CombatantType combatantType)
            {
                _combatantType = combatantType;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gearSize"></param>
            /// <returns></returns>
            public Builder SetGearSize(GearSize gearSize)
            {
                _gearSize = gearSize;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gearType"></param>
            /// <returns></returns>
            public Builder SetGearType(GearType gearType)
            {
                _gearType = gearType;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="rarity"></param>
            /// <returns></returns>
            public Builder SetRarity(Rarity rarity)
            {
                _rarity = rarity;
                return this;
            }
        }
    }
}