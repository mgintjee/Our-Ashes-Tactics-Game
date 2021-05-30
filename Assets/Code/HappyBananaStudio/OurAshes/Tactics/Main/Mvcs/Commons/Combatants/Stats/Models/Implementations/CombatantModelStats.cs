using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Models.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Models.Implementations
{
    /// <summary>
    /// Combatant Model Stats Implementation
    /// </summary>
    public struct CombatantModelStats
        : ICombatantModelStats
    {
        // Todo
        private readonly ICombatantAttributes combatantAttributes;

        // Todo
        private readonly CombatantType combatantType;

        // Todo
        private readonly Rarity rarity;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantAttributes"></param>
        /// <param name="combatantType">      </param>
        /// <param name="rarity">             </param>
        private CombatantModelStats(ICombatantAttributes combatantAttributes, CombatantType combatantType, Rarity rarity)
        {
            this.combatantAttributes = combatantAttributes;
            this.combatantType = combatantType;
            this.rarity = rarity;
        }

        ICombatantAttributes ICombatantModelStats.GetCombatantAttributes()
        {
            return combatantAttributes;
        }

        CombatantType ICombatantModelStats.GetCombatantType()
        {
            return combatantType;
        }

        Rarity ICombatantModelStats.GetRarity()
        {
            return rarity;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ICombatantAttributes combatantAttributes = null;

            // Todo
            private CombatantType combatantType = CombatantType.None;

            // Todo
            private Rarity rarity = Rarity.None;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ICombatantModelStats Build()
            {
                return new CombatantModelStats(combatantAttributes, combatantType, rarity);
            }

            public Builder SetCombatantAttributes(ICombatantAttributes combatantAttributes)
            {
                this.combatantAttributes = combatantAttributes;
                return this;
            }

            public Builder SetRarity(Rarity rarity)
            {
                this.rarity = rarity;
                return this;
            }

            public Builder SetCombatantType(CombatantType combatantType)
            {
                this.combatantType = combatantType;
                return this;
            }
        }
    }
}