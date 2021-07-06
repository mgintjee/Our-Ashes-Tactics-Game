using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Stats.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Stats.Managers;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Reports.Implementations
{
    /// <summary>
    /// Gear Report Implementation
    /// </summary>
    public class GearReport
        : IGearReport
    {
        // Todo
        private readonly GearID _gearID;

        // Todo
        private readonly ITraitReport _traitReport;

        // Todo
        private ICombatantAttributes _combatantAttributes;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gearID">     </param>
        /// <param name="traitReport"></param>
        private GearReport(GearID gearID, ITraitReport traitReport)
        {
            _gearID = gearID;
            _traitReport = traitReport;
            this.CalculateCombatantAttributes();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}, Set {2}",
                this.GetType().Name,
                StringUtils.Format(_gearID),
                _traitReport);
        }

        /// <inheritdoc/>
        ICombatantAttributes IGearReport.GetCombatantAttributes()
        {
            return _combatantAttributes;
        }

        /// <inheritdoc/>
        GearID IGearReport.GetGearID()
        {
            return _gearID;
        }

        /// <inheritdoc/>
        ITraitReport IGearReport.GetTraitReport()
        {
            return _traitReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void CalculateCombatantAttributes()
        {
            GearStatsManager.GetStats(_gearID).IfPresent(gearStats =>
            {
                ISet<ICombatantAttributes> combatantAttributes = new HashSet<ICombatantAttributes>() { gearStats.GetCombatantAttributes() };
                foreach (TraitID traitID in _traitReport.GetTraitIDs())
                {
                    TraitStatsManager.GetStats(traitID).IfPresent(traitStats =>
                    {
                        combatantAttributes.Add(traitStats.GetCombatantAttributes());
                    });
                }
                _combatantAttributes = new CombatantAttributes.Builder().Build(combatantAttributes);
            });
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private GearID _gearID;

            // Todo
            private ITraitReport _traitReport;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IGearReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new construction
                    return new GearReport(_gearID, _traitReport);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gearID"></param>
            /// <returns></returns>
            public Builder SetGearID(GearID gearID)
            {
                _gearID = gearID;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="traitReport"></param>
            /// <returns></returns>
            public Builder SetTraitReport(ITraitReport traitReport)
            {
                _traitReport = traitReport;
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
                // Check that _gearID has been set
                if (_gearID == GearID.None)
                {
                    argumentExceptionSet.Add(typeof(GearID).Name + " cannot be none.");
                }
                // Check that _traitReport has been set
                if (_traitReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITraitReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}