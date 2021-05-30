using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Combatants.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Loadouts.Reports.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Combatants.Models.Implementaions
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct CombatantModelConstruction
        : ICombatantModelConstruction
    {
        // Todo
        private readonly CombatantID _combatantID;

        // Todo
        private readonly ILoadoutReport _loadoutReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantID">  </param>
        /// <param name="loadoutReport"></param>
        private CombatantModelConstruction(CombatantID combatantID, ILoadoutReport loadoutReport)
        {
            _combatantID = combatantID;
            _loadoutReport = loadoutReport;
        }

        /// <inheritdoc/>
        CombatantID ICombatantModelConstruction.GetCombatantID()
        {
            return _combatantID;
        }

        /// <inheritdoc/>
        ILoadoutReport ICombatantModelConstruction.GetLoadoutReport()
        {
            return _loadoutReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private CombatantID _combatantID = CombatantID.None;

            // Todo
            private ILoadoutReport _loadoutReport = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ICombatantModelConstruction Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new construction
                    return new CombatantModelConstruction(_combatantID, _loadoutReport);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantID"></param>
            /// <returns></returns>
            public Builder SetCombatantID(CombatantID combatantID)
            {
                _combatantID = combatantID;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="loadoutReport"></param>
            /// <returns></returns>
            public Builder SetLoadoutReport(ILoadoutReport loadoutReport)
            {
                _loadoutReport = loadoutReport;
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
                // Check that _combatantID has been set
                if (_combatantID == CombatantID.None)
                {
                    argumentExceptionSet.Add(typeof(CombatantID).Name + " cannot be null.");
                }
                // Check that _loadoutReport has been set
                if (_loadoutReport == null)
                {
                    argumentExceptionSet.Add(typeof(ILoadoutReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}