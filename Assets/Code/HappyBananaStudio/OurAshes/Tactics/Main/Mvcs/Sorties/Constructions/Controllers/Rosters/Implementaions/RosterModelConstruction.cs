using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Controllers.Rosters.Implementaions
{
    /// <summary>
    /// Roster Model Construction Implementation
    /// </summary>
    public struct RosterModelConstruction : IRosterModelConstruction
    {
        // Todo
        private readonly ISet<ICombatantModelConstruction> _combatantModelConstructions;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantModelConstructions"></param>
        private RosterModelConstruction(ISet<ICombatantModelConstruction> combatantModelConstructions)
        {
            _combatantModelConstructions = combatantModelConstructions;
        }

        /// <inheritdoc/>
        ISet<ICombatantModelConstruction> IRosterModelConstruction.GetCombatantModelConstructions()
        {
            return new HashSet<ICombatantModelConstruction>(_combatantModelConstructions);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IRosterModelConstruction>
            {
                IBuilder SetCombatantModelConstructions(ISet<ICombatantModelConstruction> combatantModelConstructions);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder : AbstractBuilder<IRosterModelConstruction>, IBuilder
            {
                // Todo
                private ISet<ICombatantModelConstruction> _combatantModelConstructions = null;

                /// <inheritdoc/>
                IBuilder IBuilder.SetCombatantModelConstructions(ISet<ICombatantModelConstruction> combatantModelConstructions)
                {
                    if (combatantModelConstructions != null)
                    {
                        _combatantModelConstructions = new HashSet<ICombatantModelConstruction>(combatantModelConstructions);
                    }
                    return this;
                }

                /// <inheritdoc/>
                protected override IRosterModelConstruction BuildObj()
                {
                    return new RosterModelConstruction(_combatantModelConstructions);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _combatantModelConstructions);
                }
            }
        }
    }
}