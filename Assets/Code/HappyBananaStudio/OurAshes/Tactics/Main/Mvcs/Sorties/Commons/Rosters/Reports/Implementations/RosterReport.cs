using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Reports.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Reports.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct RosterReport
        : IRosterReport
    {
        // Todo
        private readonly ISet<CombatantCallSign> _activeCallSigns;

        // Todo
        private readonly ISet<CombatantCallSign> _allCallSigns;

        // Todo
        private readonly ISet<ICombatantReport> _combatantReports;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="activeCallSigns"> </param>
        /// <param name="allCallSigns">    </param>
        /// <param name="combatantReports"></param>
        private RosterReport(ISet<CombatantCallSign> activeCallSigns,
            ISet<CombatantCallSign> allCallSigns, ISet<ICombatantReport> combatantReports)
        {
            _activeCallSigns = activeCallSigns;
            _allCallSigns = allCallSigns;
            _combatantReports = combatantReports;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            string activeString = (_activeCallSigns.Count != 0)
                ? string.Join(", ", _activeCallSigns) : "empty";
            string allString = (_allCallSigns.Count != 0)
                ? string.Join(", ", _allCallSigns) : "empty";
            string reportString = (_combatantReports.Count != 0)
                ? string.Join(", ", _combatantReports) : "empty";
            return string.Format("{0}: " +
                "\nActive {1}" +
                "\nAll {2}" +
                "\n{3}",
                this.GetType().Name,
                StringUtils.Format(typeof(CombatantCallSign), activeString),
                StringUtils.Format(typeof(CombatantCallSign), allString),
                StringUtils.Format(typeof(ICombatantReport), reportString));
        }

        /// <inheritdoc/>
        ISet<CombatantCallSign> IRosterReport.GetActiveCombatantCallSigns()
        {
            return new HashSet<CombatantCallSign>(_activeCallSigns);
        }

        /// <inheritdoc/>
        ISet<CombatantCallSign> IRosterReport.GetAllCombatantCallSigns()
        {
            return new HashSet<CombatantCallSign>(_allCallSigns);
        }

        /// <inheritdoc/>
        Optional<ICombatantReport> IRosterReport.GetCombatantReport(CombatantCallSign callSign)
        {
            foreach (ICombatantReport combatantReport in _combatantReports)
            {
                if (combatantReport.GetCombatantCallSign() == callSign)
                {
                    return Optional<ICombatantReport>.Of(combatantReport);
                }
            }
            return Optional<ICombatantReport>.Empty();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ISet<CombatantCallSign> _activeCallSigns = null;

            // Todo
            private ISet<CombatantCallSign> _allCallSigns = null;

            // Todo
            private ISet<ICombatantReport> _combatantReports = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IRosterReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new report
                    return new RosterReport(_activeCallSigns,
                        _allCallSigns, _combatantReports);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="activeCallSigns"></param>
            /// <returns></returns>
            public Builder SetActiveCallSigns(ISet<CombatantCallSign> activeCallSigns)
            {
                if (activeCallSigns != null)
                {
                    _activeCallSigns = new HashSet<CombatantCallSign>(activeCallSigns);
                }
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="allCallSigns"></param>
            /// <returns></returns>
            public Builder SetAllCallSigns(ISet<CombatantCallSign> allCallSigns)
            {
                if (allCallSigns != null)
                {
                    _allCallSigns = new HashSet<CombatantCallSign>(allCallSigns);
                }
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantReports"></param>
            /// <returns></returns>
            public Builder SetCombatantReports(ISet<ICombatantReport> combatantReports)
            {
                if (combatantReports != null)
                {
                    _combatantReports = new HashSet<ICombatantReport>(combatantReports);
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
                // Check that _activeCallSigns has been set
                if (_activeCallSigns == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(CombatantCallSign).Name + " cannot be null.");
                }
                // Check that _allCallSigns has been set
                if (_allCallSigns == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(CombatantCallSign).Name + " cannot be null.");
                }
                // Check that _combatantReports has been set
                if (_combatantReports == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(ICombatantReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}