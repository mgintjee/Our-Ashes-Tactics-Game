using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Rosters.Combatants.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Rosters.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Rosters.Implementations
{
    /// <summary>
    /// Roster View Construction Implementation
    /// </summary>
    public struct RosterViewConstruction : IRosterViewConstruction
    {
        // Todo
        private readonly ISet<ICombatantViewConstruction> _combatantViewConstructions;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantViewConstructions"></param>
        private RosterViewConstruction(ISet<ICombatantViewConstruction> combatantViewConstructions)
        {
            _combatantViewConstructions = combatantViewConstructions;
        }

        /// <inheritdoc/>
        ISet<ICombatantViewConstruction> IRosterViewConstruction.GetCombatantViewConstructions()
        {
            return new HashSet<ICombatantViewConstruction>(_combatantViewConstructions);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IRosterViewConstruction>
            {
                IBuilder SetCombatantViewConstructions(ISet<ICombatantViewConstruction> combatantViewConstructions);
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
            private class InternalBuilder : AbstractBuilder<IRosterViewConstruction>, IBuilder
            {
                // Todo
                private ISet<ICombatantViewConstruction> _combatantViewConstructions = null;

                /// <inheritdoc/>
                IBuilder IBuilder.SetCombatantViewConstructions(ISet<ICombatantViewConstruction> combatantViewConstructions)
                {
                    if (combatantViewConstructions != null)
                    {
                        _combatantViewConstructions = new HashSet<ICombatantViewConstruction>(combatantViewConstructions);
                    }
                    return this;
                }

                /// <inheritdoc/>
                protected override IRosterViewConstruction BuildObj()
                {
                    return new RosterViewConstruction(_combatantViewConstructions);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _combatantViewConstructions);
                }
            }
        }
    }
}