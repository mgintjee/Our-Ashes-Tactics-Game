using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Destructibles.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Destructibles.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Rosters.Combatants.Characteristics.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Rosters.Combatants.Destructables.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Rosters.Combatants.Destructables.Implementaions
{
    /// <summary>
    /// Destructible Model Impl
    /// </summary>
    public class DestructibleModel : IDestructibleModel
    {
        // Todo
        private readonly IDestructibleAttributes _attributes;

        // Todo
        private IDestructibleAttributes currentAttributes;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantAttributes"></param>
        public DestructibleModel(ICollection<ICombatantAttributes> combatantAttributes)
        {
            float APs = 0.0f;
            float HPs = 0.0f;

            foreach (ICombatantAttributes attributes in combatantAttributes)
            {
                IDestructibleAttributes destructibleAttributes = attributes.GetDestructibleAttributes();
                APs += destructibleAttributes.GetArmor();
                HPs += destructibleAttributes.GetHealth();
            }
            this.currentAttributes = DestructibleAttributes.Builder.Get()
                .SetArmor(APs)
                .SetHealth(HPs)
                .Build();
            _attributes = DestructibleAttributes.Builder.Get()
                .SetArmor(APs)
                .SetHealth(HPs)
                .Build();
        }

        /// <inheritdoc/>
        void ICharacteristicModel.ApplyCombatantAttributes(ICombatantAttributes combatantAttributes)
        {
            float currentAPs = this.currentAttributes.GetArmor();
            float currentHPs = this.currentAttributes.GetHealth();
            IDestructibleAttributes destructibleAttributes = combatantAttributes.GetDestructibleAttributes();
            currentAPs += destructibleAttributes.GetArmor();
            currentHPs += destructibleAttributes.GetHealth();
            this.currentAttributes = DestructibleAttributes.Builder.Get()
                .SetArmor(currentAPs)
                .SetHealth(currentHPs)
                .Build();
        }

        /// <inheritdoc/>
        IDestructibleAttributes IDestructibleModel.GetCurrentAttributes()
        {
            return this.currentAttributes;
        }

        /// <inheritdoc/>
        IDestructibleAttributes IDestructibleModel.GetMaximumAttributes()
        {
            return _attributes;
        }

        /// <inheritdoc/>
        void ICharacteristicModel.ResetForPhase()
        {
            this.currentAttributes = DestructibleAttributes.Builder.Get()
                .SetArmor(_attributes.GetArmor())
                .SetHealth(_attributes.GetHealth())
                .Build();
        }
    }
}