using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Fireables.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Fireables.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Characteristics.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Fireables.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Fireables.Implementaions
{
    /// <summary>
    /// Fireable Model Impl
    /// </summary>
    public class FireableModel : IFireableModel
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
            float accuracy = 0;
            float range = 0;

            foreach (ICombatantAttributes attributes in combatantAttributes)
            {
                IFireableAttributes fireableAttributes = attributes.GetFireableAttributes();
                accuracy += fireableAttributes.GetAccuracy();
                range += fireableAttributes.GetRange();
            }
            _attributes = FireableAttributes.Builder.Get()
                .SetAccuracy(accuracy)
                .SetRange(range)
                .Build();
            this.currentAttributes = FireableAttributes.Builder.Get()
                .SetAccuracy(accuracy)
                .SetRange(range)
                .Build();
        }

        /// <inheritdoc/>
        void ICharacteristicModel.ApplyCombatantAttributes(ICombatantAttributes combatantAttributes)
        {
            // Collect the current values
            float accuracy = this.currentAttributes.GetAccuracy();
            float range = this.currentAttributes.GetRange();
            // Collect the FireableAttributes from the CombatantAttributes
            IFireableAttributes fireableAttributes = combatantAttributes.GetFireableAttributes();
            // Increment the current values by the combatantAttributes
            accuracy += fireableAttributes.GetAccuracy();
            range += fireableAttributes.GetRange();
            // Build the new FireableAttributes using the up-to-date current values
            this.currentAttributes = FireableAttributes.Builder.Get()
                .SetAccuracy(accuracy)
                .SetRange(range)
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
            this.currentAttributes = FireableAttributes.Builder.Get()
                .SetAccuracy(_attributes.GetAccuracy())
                .SetRange(_attributes.GetRange())
                .Build();
        }
    }
}