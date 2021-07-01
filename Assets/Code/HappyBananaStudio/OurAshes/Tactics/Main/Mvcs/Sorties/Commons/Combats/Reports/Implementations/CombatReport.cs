using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combats.Damages.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combats.Reports.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combats.Reports.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct CombatReport
        : ICombatReport
    {
        // Todo
        private readonly CombatantCallSign _actingCallSign;

        // Todo
        private readonly CombatantCallSign _targetCallSign;

        // Todo
        private readonly ISet<IDamageReport> _damageReports;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="damageReports"></param>
        private CombatReport(CombatantCallSign actingCallSign, CombatantCallSign targetCallSign, ISet<IDamageReport> damageReports)
        {
            _actingCallSign = actingCallSign;
            _targetCallSign = targetCallSign;
            _damageReports = damageReports;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            string damageReportsString = (_damageReports.Count != 0)
                ? string.Join("\n", _damageReports)
                : "empty";
            return string.Format("{0}: Acting {1}, Target {2}" +
                "\n{3}",
                this.GetType().Name, _actingCallSign, _targetCallSign,
                StringUtils.Format(typeof(IDamageReport), damageReportsString));
        }

        /// <inheritdoc/>
        CombatantCallSign ICombatReport.GetActingCallSign()
        {
            return _actingCallSign;
        }

        /// <inheritdoc/>
        ISet<IDamageReport> ICombatReport.GetDamageReports()
        {
            return new HashSet<IDamageReport>(_damageReports);
        }

        /// <inheritdoc/>
        CombatantCallSign ICombatReport.GetTargetCallSign()
        {
            return _targetCallSign;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private CombatantCallSign _actingCallSign = CombatantCallSign.None;

            // Todo
            private CombatantCallSign _targetCallSign = CombatantCallSign.None;

            // Todo
            private ISet<IDamageReport> _damageReports = new HashSet<IDamageReport>();

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ICombatReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new report
                    return new CombatReport(_actingCallSign, _targetCallSign, _damageReports);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="callSign"></param>
            public Builder SetActingCallSign(CombatantCallSign callSign)
            {
                _actingCallSign = callSign;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="callSign"></param>
            public Builder SetTargetCallSign(CombatantCallSign callSign)
            {
                _targetCallSign = callSign;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="damageReports"></param>
            public Builder SetDamageReports(ISet<IDamageReport> damageReports)
            {
                if (damageReports != null)
                {
                    _damageReports = new HashSet<IDamageReport>(damageReports);
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
                // Check that _damageReports has been set
                if (_damageReports == null)
                {
                    argumentExceptionSet.Add("List: " + typeof(IDamageReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}