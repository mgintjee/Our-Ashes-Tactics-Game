using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combatants.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Loadouts.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combatants.Implementaions
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CombatantReport : AbstractReport, ICombatantReport
    {
        // Todo
        private readonly CombatantCallSign _combatantCallSign;

        // Todo
        private readonly CombatantID _combatantID;

        // Todo
        private readonly ICombatantAttributes _currentAttributes;

        // Todo
        private readonly ILoadoutReport _loadoutReport;

        // Todo
        private readonly ICombatantAttributes _maximumAttributes;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="currentAttributes"></param>
        /// <param name="maximumAttributes"></param>
        /// <param name="callSign">         </param>
        /// <param name="loadoutReport">    </param>
        /// <param name="combatantID">      </param>
        private CombatantReport(ICombatantAttributes currentAttributes,
            ICombatantAttributes maximumAttributes, CombatantCallSign callSign,
            ILoadoutReport loadoutReport, CombatantID combatantID)
        {
            _currentAttributes = currentAttributes;
            _maximumAttributes = maximumAttributes;
            _combatantCallSign = callSign;
            _loadoutReport = loadoutReport;
            _combatantID = combatantID;
        }

        /// <inheritdoc/>
        CombatantCallSign ICombatantReport.GetCombatantCallSign()
        {
            return _combatantCallSign;
        }

        /// <inheritdoc/>
        CombatantID ICombatantReport.GetCombatantID()
        {
            return _combatantID;
        }

        /// <inheritdoc/>
        ICombatantAttributes ICombatantReport.GetCurrentAttributes()
        {
            return _currentAttributes;
        }

        /// <inheritdoc/>
        ILoadoutReport ICombatantReport.GetLoadoutReport()
        {
            return _loadoutReport;
        }

        /// <inheritdoc/>
        ICombatantAttributes ICombatantReport.GetMaximumAttributes()
        {
            return _maximumAttributes;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}, {1}, {2}, Current {3}, Maximum {4}, {5}",
                this.GetType().Name,
                StringUtils.Format(_combatantCallSign),
                StringUtils.Format(_combatantID),
                _currentAttributes, _maximumAttributes, _loadoutReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private CombatantCallSign _combatantCallSign = CombatantCallSign.None;

            // Todo
            private CombatantID _combatantID = CombatantID.None;

            // Todo
            private ICombatantAttributes _currentAttributes = null;

            // Todo
            private ILoadoutReport _loadoutReport = null;

            // Todo
            private ICombatantAttributes _maximumAttributes = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ICombatantReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new CombatantReport(_currentAttributes, _maximumAttributes,
                        _combatantCallSign, _loadoutReport, _combatantID);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantCallSign"></param>
            /// <returns></returns>
            public Builder SetCombatantCallSign(CombatantCallSign combatantCallSign)
            {
                _combatantCallSign = combatantCallSign;
                return this;
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
            /// <param name="currentAttributes"></param>
            /// <returns></returns>
            public Builder SetCurrentCombatantAttributes(ICombatantAttributes currentAttributes)
            {
                _currentAttributes = currentAttributes;
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
            /// <param name="maximumAttributes"></param>
            /// <returns></returns>
            public Builder SetMaximumCombatantAttributes(ICombatantAttributes maximumAttributes)
            {
                _maximumAttributes = maximumAttributes;
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
                // Check that _combatantCallSign has been set
                if (_combatantCallSign == CombatantCallSign.None)
                {
                    argumentExceptionSet.Add(typeof(CombatantCallSign).Name + " cannot be null.");
                }
                // Check that combatantID has been set
                if (_combatantID == CombatantID.None)
                {
                    argumentExceptionSet.Add(typeof(CombatantID).Name + " cannot be null.");
                }
                // Check that currentAttributes has been set
                if (_currentAttributes == null)
                {
                    argumentExceptionSet.Add("Current " + typeof(ICombatantAttributes).Name + " points cannot be null.");
                }
                // Check that maximumAttributes has been set
                if (_maximumAttributes == null)
                {
                    argumentExceptionSet.Add("Maximum " + typeof(ICombatantAttributes).Name + " points cannot be null.");
                }
                // Check that loadoutReport has been set
                if (_loadoutReport == null)
                {
                    argumentExceptionSet.Add(typeof(ILoadoutReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}