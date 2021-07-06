using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Stats.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Implementations
{
    /// <summary>
    /// Loadout Report Implementation
    /// </summary>
    public class LoadoutReport
        : ILoadoutReport
    {
        // Todo
        private readonly ISet<IGearReport> _gearReports = new HashSet<IGearReport>();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gearReports"></param>
        private LoadoutReport(ISet<IGearReport> gearReports)
        {
            _gearReports = new HashSet<IGearReport>(gearReports);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: " +
                "\n{1}=[{2}]",
                this.GetType().Name,
                typeof(IGearReport).Name, string.Join("\n", _gearReports));
        }

        /// <inheritdoc/>
        ISet<IGearReport> ILoadoutReport.GetGearReports(GearType gearType)
        {
            ISet<IGearReport> gearReports = new HashSet<IGearReport>();

            foreach (IGearReport gearReport in _gearReports)
            {
                GearStatsManager.GetStats(gearReport.GetGearID()).IfPresent(gearStats =>
                {
                    if (gearStats.GetGearType() == gearType)
                    {
                        gearReports.Add(gearReport);
                    }
                });
            }

            return gearReports;
        }

        /// <inheritdoc/>
        ISet<IGearReport> ILoadoutReport.GetGearReports()
        {
            return new HashSet<IGearReport>(_gearReports);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ISet<IGearReport> _gearReports = new HashSet<IGearReport>();

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ILoadoutReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new construction
                    return new LoadoutReport(_gearReports);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gearReports"></param>
            /// <returns></returns>
            public Builder SetGearReports(ISet<IGearReport> gearReports)
            {
                if (gearReports != null)
                {
                    _gearReports = new HashSet<IGearReport>(gearReports);
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
                // Check that _gearReports has been set
                if (_gearReports == null ||
                    _gearReports.Count == 0)
                {
                    argumentExceptionSet.Add("Set: " + typeof(IGearReport).Name + " cannot be null or empty.");
                }
                return argumentExceptionSet;
            }
        }
    }
}