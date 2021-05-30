using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Fireables.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Fireables.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Characteristics.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Fireables.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Fireables.Implementaions
{
    /// <summary>
    /// Fireable Model Impl
    /// </summary>
    public class FireableModel
        : IFireableModel
    {
        // Todo
        private readonly IFireableAttributes _attributes;

        // Todo
        private IFireableAttributes currentAttributes;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantAttributes"></param>
        public FireableModel(ICollection<ICombatantAttributes> combatantAttributes)
        {
            // Default the current values
            float armorDamage = 0;
            float armorPenetration = 0;
            float accuracy = 0;
            float healthDamage = 0;
            float range = 0;
            float salvo = 0;

            foreach (ICombatantAttributes attributes in combatantAttributes)
            {
                IFireableAttributes fireableAttributes = attributes.GetFireableAttributes();
                armorDamage += fireableAttributes.GetArmorDamage();
                armorPenetration += fireableAttributes.GetArmorPenetration();
                accuracy += fireableAttributes.GetAccuracy();
                healthDamage += fireableAttributes.GetHealthDamage();
                range += fireableAttributes.GetRange();
                salvo += fireableAttributes.GetSalvo();
            }
            this._attributes = new FireableAttributes.Builder()
                .SetArmorDamage(armorDamage)
                .SetArmorPenetration(armorPenetration)
                .SetAccuracy(accuracy)
                .SetHealthDamage(healthDamage)
                .SetRange(range)
                .SetSalvo(salvo)
                .Build();
            this.currentAttributes = new FireableAttributes.Builder()
                .SetArmorDamage(armorDamage)
                .SetArmorPenetration(armorPenetration)
                .SetAccuracy(accuracy)
                .SetHealthDamage(healthDamage)
                .SetRange(range)
                .SetSalvo(salvo)
                .Build();
        }

        /// <inheritdoc/>
        void ICharacteristicModel.ApplyCombatantAttributes(ICombatantAttributes combatantAttributes)
        {
            // Collect the current values
            float armorDamage = this.currentAttributes.GetArmorDamage();
            float armorPenetration = this.currentAttributes.GetArmorPenetration();
            float accuracy = this.currentAttributes.GetAccuracy();
            float healthDamage = this.currentAttributes.GetHealthDamage();
            float range = this.currentAttributes.GetRange();
            float salvo = this.currentAttributes.GetSalvo();
            // Collect the FireableAttributes from the CombatantAttributes
            IFireableAttributes fireableAttributes = combatantAttributes.GetFireableAttributes();
            // Increment the current values by the combatantAttributes
            armorDamage += fireableAttributes.GetArmorDamage();
            armorPenetration += fireableAttributes.GetArmorPenetration();
            accuracy += fireableAttributes.GetAccuracy();
            healthDamage += fireableAttributes.GetHealthDamage();
            range += fireableAttributes.GetRange();
            salvo += fireableAttributes.GetSalvo();
            // Build the new FireableAttributes using the up-to-date current values
            this.currentAttributes = new FireableAttributes.Builder()
                .SetArmorDamage(armorDamage)
                .SetArmorPenetration(armorPenetration)
                .SetAccuracy(accuracy)
                .SetHealthDamage(healthDamage)
                .SetRange(range)
                .SetSalvo(salvo)
                .Build();
        }

        /// <inheritdoc/>
        IFireableAttributes IFireableModel.GetCurrentAttributes()
        {
            return this.currentAttributes;
        }

        /// <inheritdoc/>
        IFireableAttributes IFireableModel.GetMaximumAttributes()
        {
            return _attributes;
        }

        /// <inheritdoc/>
        void ICharacteristicModel.ResetForPhase()
        {
            this.currentAttributes = new FireableAttributes.Builder()
                .SetArmorDamage(_attributes.GetArmorDamage())
                .SetArmorPenetration(_attributes.GetArmorPenetration())
                .SetAccuracy(_attributes.GetAccuracy())
                .SetHealthDamage(_attributes.GetHealthDamage())
                .SetRange(_attributes.GetRange())
                .SetSalvo(_attributes.GetSalvo())
                .Build();
        }
    }
}