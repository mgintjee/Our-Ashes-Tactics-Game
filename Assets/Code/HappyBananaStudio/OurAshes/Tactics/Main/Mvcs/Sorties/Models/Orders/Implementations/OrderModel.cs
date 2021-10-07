using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Orders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combatants.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Orders.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Orders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Rosters.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Orders.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class OrderModel : IOrderModel
    {
        // Provides logging capability to the SORTIE logs
        private readonly ILogger _logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IList<CombatantCallSign> _currentCallSigns;

        // Todo
        private readonly IList<CombatantCallSign> _upcomingCallSigns;

        // Todo
        private IOrderReport _report;

        /// <summary>
        /// Todo
        /// </summary>
        public OrderModel()
        {
            _logger.Info("Instantiating");
            _currentCallSigns = new List<CombatantCallSign>();
            _upcomingCallSigns = new List<CombatantCallSign>();
            this.BuildReport();
        }

        /// <inheritdoc/>
        IOrderReport IOrderModel.GetReport()
        {
            return _report;
        }

        /// <inheritdoc/>
        void IOrderModel.Process(IRosterModelReport rosterReport)
        {
            if (_currentCallSigns.Count == 0 && _upcomingCallSigns.Count == 0)
            {
                foreach (CombatantCallSign combatantCallSign in rosterReport.GetActiveCombatantCallSigns())
                {
                    _upcomingCallSigns.Add(combatantCallSign);
                }
            }
            this.RemoveInactiveCallSigns(rosterReport, _currentCallSigns);
            this.RemoveInactiveCallSigns(rosterReport, _upcomingCallSigns);
            this.UpdateCurrentCallSigns(rosterReport);
            this.BuildReport();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildReport()
        {
            _report = new OrderReport.Builder()
                .SetCurrentCallSigns(_currentCallSigns)
                .SetUpcomingCallSigns(_upcomingCallSigns)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSigns"></param>
        private void OrderCallSigns(IRosterModelReport combatantRosterReport, IList<CombatantCallSign> callSigns)
        {
            ((List<CombatantCallSign>)callSigns).Sort(
                new OrderPointsComparer(combatantRosterReport));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="rosterReport"></param>
        /// <param name="callSigns">   </param>
        private void RemoveInactiveCallSigns(IRosterModelReport rosterReport,
            IList<CombatantCallSign> callSigns)
        {
            ISet<CombatantCallSign> activeCallSigns = rosterReport.GetActiveCombatantCallSigns();
            ISet<CombatantCallSign> inactiveCallSigns = new HashSet<CombatantCallSign>();
            foreach (CombatantCallSign callSign in callSigns)
            {
                if (!activeCallSigns.Contains(callSign))
                {
                    inactiveCallSigns.Add(callSign);
                }
            }
            foreach (CombatantCallSign callSign in inactiveCallSigns)
            {
                callSigns.Remove(callSign);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="rosterReport"></param>
        private void UpdateCurrentCallSigns(IRosterModelReport rosterReport)
        {
            // Default an empty set
            ISet<CombatantCallSign> completeCallSigns = new HashSet<CombatantCallSign>();
            _logger.Info("Current [{}]", string.Join(", ", _currentCallSigns));
            // Iterate over all of the currentCallSigns
            foreach (CombatantCallSign callSign in _currentCallSigns)
            {
                // Collect the combatantReport for this callSign
                Optional<ICombatantReport> combatantReport = rosterReport.GetCombatantReport(callSign);
                combatantReport.IfPresent((combatantReport) =>
                {
                    // Check if the combatant has any remaining actions
                    if (combatantReport.GetCurrentAttributes().GetMovableAttributes().GetActions() <= 0)
                    {
                        _logger.Info(" {} No longer has actions", callSign);
                        // Add this callSign to the completed callSigns
                        completeCallSigns.Add(callSign);
                    }
                });
            }
            // Iterate over the completedCallSigns
            foreach (CombatantCallSign callSign in completeCallSigns)
            {
                // Remove the callSign from the currentCallSigns
                _currentCallSigns.Remove(callSign);
                if (!_upcomingCallSigns.Contains(callSign))
                {
                    // Add the callSign to the upcomingCallSigns
                    _upcomingCallSigns.Add(callSign);
                }
            }
            // Order the upcomingCallSigns
            this.OrderCallSigns(rosterReport, _upcomingCallSigns);
            // Check if the currentCallSigns is empty
            if (_currentCallSigns.Count == 0)
            {
                _logger.Info("Current {} is empty. Populating with Upcoming {} {}s.", typeof(CombatantCallSign), _upcomingCallSigns.Count, typeof(CombatantCallSign));
                // Iterate over the upcomingCallSigns
                foreach (CombatantCallSign callSign in _upcomingCallSigns)
                {
                    // Add the upcoming callSign to the currentCallSigns
                    _currentCallSigns.Add(callSign);
                }
                // Clear the upcomingCallSigns
                _upcomingCallSigns.Clear();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        private class OrderPointsComparer
            : IComparer<CombatantCallSign>
        {
            // Todo
            private readonly IRosterModelReport combatantRosterReport;

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantRosterReport"></param>
            public OrderPointsComparer(IRosterModelReport combatantRosterReport)
            {
                this.combatantRosterReport = combatantRosterReport;
            }

            /// <inheritdoc/>
            int IComparer<CombatantCallSign>.Compare(CombatantCallSign left, CombatantCallSign right)
            {
                if (left == right)
                {
                    return 0;
                }
                Optional<ICombatantReport> leftReport = this.combatantRosterReport.GetCombatantReport(left);
                Optional<ICombatantReport> rightReport = this.combatantRosterReport.GetCombatantReport(right);

                if (!leftReport.IsPresent() &&
                    rightReport.IsPresent())
                {
                    return 1;
                }
                else if (leftReport.IsPresent() &&
                    !rightReport.IsPresent())
                {
                    return -1;
                }
                else if (!leftReport.IsPresent() &&
                    !rightReport.IsPresent())
                {
                    return 0;
                }

                float leftOP = this.GetOrderPoints(leftReport.GetValue().GetCurrentAttributes().GetMovableAttributes());
                float rightOP = this.GetOrderPoints(rightReport.GetValue().GetCurrentAttributes().GetMovableAttributes());
                if (leftOP > rightOP)
                {
                    return -1;
                }
                else if (leftOP < rightOP)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="movableAttributes"></param>
            /// <returns></returns>
            private float GetOrderPoints(IMovableAttributes movableAttributes)
            {
                return 10 * movableAttributes.GetActions() + movableAttributes.GetMovement();
            }
        }
    }
}