using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Constructions.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Constructions.Implementaions
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct RosterConstruction
        : IRosterConstruction
    {
        // Todo
        private readonly ISet<ICombatantConstruction> _combatantConstructions;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantConstructions"></param>
        private RosterConstruction(ISet<ICombatantConstruction> combatantConstructions)
        {
            _combatantConstructions = combatantConstructions;
        }

        /// <inheritdoc/>
        ISet<ICombatantConstruction> IRosterConstruction.GetCombatantConstructions()
        {
            return new HashSet<ICombatantConstruction>(_combatantConstructions);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ISet<ICombatantConstruction> _combatantConstructions = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IRosterConstruction Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new construction
                    return new RosterConstruction(_combatantConstructions);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantConstructions"></param>
            /// <returns></returns>
            public Builder SetCombatantConstructions(ISet<ICombatantConstruction> combatantConstructions)
            {
                if (combatantConstructions != null)
                {
                    _combatantConstructions = new HashSet<ICombatantConstruction>(combatantConstructions);
                }
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that _combatantConstructions has been set
                if (_combatantConstructions == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(ICombatantConstruction).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}