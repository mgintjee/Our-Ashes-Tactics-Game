using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Orders.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Orders.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class OrderReport : AbstractReport, IOrderReport
    {
        // Todo
        private readonly IList<CombatantCallSign> _currentCallSigns;

        // Todo
        private readonly IList<CombatantCallSign> _upcomingCallSigns;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="currentCallSigns"> </param>
        /// <param name="upcomingCallSigns"></param>
        private OrderReport(IList<CombatantCallSign> currentCallSigns, IList<CombatantCallSign> upcomingCallSigns)
        {
            _currentCallSigns = currentCallSigns;
            _upcomingCallSigns = upcomingCallSigns;
        }

        /// <inheritdoc/>
        IList<CombatantCallSign> IOrderReport.GetCurrentCallSigns()
        {
            return new List<CombatantCallSign>(_currentCallSigns);
        }

        /// <inheritdoc/>
        IList<CombatantCallSign> IOrderReport.GetUpcomingCallSigns()
        {
            return new List<CombatantCallSign>(_upcomingCallSigns);
        }

        protected override string GetContent()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IList<CombatantCallSign> _currentCallSigns = null;

            // Todo
            private IList<CombatantCallSign> _upcomingCallSigns = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IOrderReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new report
                    return new OrderReport(_currentCallSigns, _upcomingCallSigns);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="currentCallSigns"></param>
            /// <returns></returns>
            public Builder SetCurrentCallSigns(IList<CombatantCallSign> currentCallSigns)
            {
                if (currentCallSigns != null)
                {
                    _currentCallSigns = new List<CombatantCallSign>(currentCallSigns);
                }
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="upcomingCallSigns"></param>
            /// <returns></returns>
            public Builder SetUpcomingCallSigns(IList<CombatantCallSign> upcomingCallSigns)
            {
                if (upcomingCallSigns != null)
                {
                    _upcomingCallSigns = new List<CombatantCallSign>(upcomingCallSigns);
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
                // Check that _currentCallSigns has been set
                if (_currentCallSigns == null)
                {
                    argumentExceptionSet.Add("Current List: " + typeof(CombatantCallSign).Name + " cannot be null.");
                }
                // Check that _upcomingCallSigns has been set
                if (_upcomingCallSigns == null)
                {
                    argumentExceptionSet.Add("Upcoming List: " + typeof(CombatantCallSign).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}