using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Movables.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Movables.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Characteristics.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Movables.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Movables.Implementaions
{
    /// <summary>
    /// Movable Model Impl
    /// </summary>
    public class MovableModel
        : IMovableModel
    {
        // Todo
        private readonly IMovableAttributes _maximumAttributes;

        // Todo
        private IMovableAttributes currentAttributes;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantAttributes"></param>
        public MovableModel(ICollection<ICombatantAttributes> combatantAttributes)
        {
            float actions = 0.0f;
            float movements = 0.0f;

            foreach (ICombatantAttributes attributes in combatantAttributes)
            {
                IMovableAttributes movableAttributes = attributes.GetMovableAttributes();
                actions += movableAttributes.GetActions();
                movements += movableAttributes.GetMovement();
            }
            this.currentAttributes = MovableAttributes.Builder.Get()
                .SetActions(actions)
                .SetMovements(movements)
                .Build();
            _maximumAttributes = MovableAttributes.Builder.Get()
                .SetActions(actions)
                .SetMovements(movements)
                .Build();
        }

        /// <inheritdoc/>
        void ICharacteristicModel.ApplyCombatantAttributes(ICombatantAttributes combatantAttributes)
        {
            float APs = this.currentAttributes.GetActions();
            float MPs = this.currentAttributes.GetMovement();
            IMovableAttributes movableAttributes = combatantAttributes.GetMovableAttributes();
            APs += movableAttributes.GetActions();
            MPs += movableAttributes.GetMovement();
            this.currentAttributes = MovableAttributes.Builder.Get()
                .SetActions(APs)
                .SetMovements(MPs)
                .Build();
        }

        /// <inheritdoc/>
        IMovableAttributes IMovableModel.GetCurrentAttributes()
        {
            return this.currentAttributes;
        }

        /// <inheritdoc/>
        IMovableAttributes IMovableModel.GetMaximumAttributes()
        {
            return _maximumAttributes;
        }

        /// <inheritdoc/>
        void ICharacteristicModel.ResetForPhase()
        {
            this.currentAttributes = MovableAttributes.Builder.Get()
                .SetActions(_maximumAttributes.GetActions())
                .SetMovements(_maximumAttributes.GetMovement())
                .Build();
        }
    }
}