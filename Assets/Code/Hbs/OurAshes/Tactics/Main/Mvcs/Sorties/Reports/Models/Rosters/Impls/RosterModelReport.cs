using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combatants.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Rosters.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Rosters.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class RosterModelReport : AbstractReport, IRosterModelReport
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
        private RosterModelReport(ISet<CombatantCallSign> activeCallSigns,
            ISet<CombatantCallSign> allCallSigns, ISet<ICombatantReport> combatantReports)
        {
            _activeCallSigns = activeCallSigns;
            _allCallSigns = allCallSigns;
            _combatantReports = combatantReports;
        }

        /// <inheritdoc/>
        ISet<CombatantCallSign> IRosterModelReport.GetActiveCombatantCallSigns()
        {
            return new HashSet<CombatantCallSign>(_activeCallSigns);
        }

        /// <inheritdoc/>
        ISet<CombatantCallSign> IRosterModelReport.GetAllCombatantCallSigns()
        {
            return new HashSet<CombatantCallSign>(_allCallSigns);
        }

        /// <inheritdoc/>
        Optional<ICombatantReport> IRosterModelReport.GetCombatantReport(CombatantCallSign callSign)
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

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}, {1}, {2}", _activeCallSigns, _allCallSigns, _combatantReports);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IRosterModelReport>
            {
                IBuilder SetActiveCombatantCallSigns(ISet<CombatantCallSign> combatantCallSigns);

                IBuilder SetAllCombatantCallSigns(ISet<CombatantCallSign> combatantCallSigns);

                IBuilder SetAllCombatantReports(ISet<ICombatantReport> combatantReports);
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
            private class InternalBuilder : AbstractBuilder<IRosterModelReport>, IBuilder
            {
                // Todo
                private ISet<CombatantCallSign> _activeCallSigns = null;

                // Todo
                private ISet<CombatantCallSign> _allCallSigns = null;

                // Todo
                private ISet<ICombatantReport> _combatantReports = null;

                /// <inheritdoc/>
                IBuilder IBuilder.SetActiveCombatantCallSigns(ISet<CombatantCallSign> combatantCallSigns)
                {
                    if (combatantCallSigns != null)
                    {
                        _activeCallSigns = new HashSet<CombatantCallSign>(combatantCallSigns);
                    }
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetAllCombatantCallSigns(ISet<CombatantCallSign> combatantCallSigns)
                {
                    if (combatantCallSigns != null)
                    {
                        _allCallSigns = new HashSet<CombatantCallSign>(combatantCallSigns);
                    }
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetAllCombatantReports(ISet<ICombatantReport> combatantReports)
                {
                    if (combatantReports != null)
                    {
                        _combatantReports = new HashSet<ICombatantReport>(combatantReports);
                    }
                    return this;
                }

                protected override IRosterModelReport BuildObj()
                {
                    return new RosterModelReport(_activeCallSigns, _allCallSigns, _combatantReports);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _allCallSigns);
                    this.Validate(invalidReasons, _activeCallSigns);
                    this.Validate(invalidReasons, _combatantReports);
                }
            }
        }
    }
}