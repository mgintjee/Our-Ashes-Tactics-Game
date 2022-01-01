using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Rosters.Combatants.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Rosters.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Rosters.Impls
{
    /// <summary>
    /// Roster Model Construction Impl
    /// </summary>
    public struct RosterModelConstruction : IRosterModelConstruction
    {
        // Todo
        private readonly ISet<ICombatantModelConstruction> _combatantModelConstrs;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantModelConstrs"></param>
        private RosterModelConstruction(ISet<ICombatantModelConstruction> combatantModelConstrs)
        {
            _combatantModelConstrs = combatantModelConstrs;
        }

        /// <inheritdoc/>
        ISet<ICombatantModelConstruction> IRosterModelConstruction.GetCombatantModelConstrs()
        {
            return new HashSet<ICombatantModelConstruction>(_combatantModelConstrs);
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
                IBuilder SetCombatantModelConstrs(ISet<ICombatantModelConstruction> combatantModelConstrs);
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
                private ISet<ICombatantModelConstruction> _combatantModelConstrs = null;

                /// <inheritdoc/>
                IBuilder IBuilder.SetCombatantModelConstrs(ISet<ICombatantModelConstruction> combatantModelConstrs)
                {
                    if (combatantModelConstrs != null)
                    {
                        _combatantModelConstrs = new HashSet<ICombatantModelConstruction>(combatantModelConstrs);
                    }
                    return this;
                }

                /// <inheritdoc/>
                protected override IRosterModelConstruction BuildObj()
                {
                    return new RosterModelConstruction(_combatantModelConstrs);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _combatantModelConstrs);
                }
            }
        }
    }
}