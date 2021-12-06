using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Views.Rosters.Combatants.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Views.Rosters.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Views.Rosters.Impls
{
    /// <summary>
    /// Roster View Construction Implementation
    /// </summary>
    public struct RosterViewConstruction : IRosterViewConstruction
    {
        // Todo
        private readonly ISet<ICombatantViewConstruction> _combatantViewConstrs;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantViewConstrs"></param>
        private RosterViewConstruction(ISet<ICombatantViewConstruction> combatantViewConstrs)
        {
            _combatantViewConstrs = combatantViewConstrs;
        }

        /// <inheritdoc/>
        ISet<ICombatantViewConstruction> IRosterViewConstruction.GetCombatantViewConstrs()
        {
            return new HashSet<ICombatantViewConstruction>(_combatantViewConstrs);
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
                IBuilder SetCombatantViewConstrs(ISet<ICombatantViewConstruction> combatantViewConstrs);
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
                private ISet<ICombatantViewConstruction> _combatantViewConstrs = null;

                /// <inheritdoc/>
                IBuilder IBuilder.SetCombatantViewConstrs(ISet<ICombatantViewConstruction> combatantViewConstrs)
                {
                    if (combatantViewConstrs != null)
                    {
                        _combatantViewConstrs = new HashSet<ICombatantViewConstruction>(combatantViewConstrs);
                    }
                    return this;
                }

                /// <inheritdoc/>
                protected override IRosterViewConstruction BuildObj()
                {
                    return new RosterViewConstruction(_combatantViewConstrs);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _combatantViewConstrs);
                }
            }
        }
    }
}