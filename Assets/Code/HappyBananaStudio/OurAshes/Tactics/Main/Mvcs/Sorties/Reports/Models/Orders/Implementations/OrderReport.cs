using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Orders.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct OrderReport
        : IOrderReport
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
        public override string ToString()
        {
            string currentValue = (_currentCallSigns.Count != 0)
                ? string.Join(", ", _currentCallSigns) : "empty";
            string upcomingValue = (_upcomingCallSigns.Count != 0)
                ? string.Join(", ", _upcomingCallSigns) : "empty";
            return string.Format("{0}: " +
                "\nCurrent {1}" +
                "\nUpcoming {2}",
                this.GetType().Name,
                StringUtils.Format(currentValue),
                StringUtils.Format(upcomingValue));
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