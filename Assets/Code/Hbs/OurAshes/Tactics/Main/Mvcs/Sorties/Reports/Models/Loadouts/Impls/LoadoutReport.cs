using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Gears.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Constants.Loadouts.Models.Gears.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Gears.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Loadouts.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Loadouts.Impls
{
    /// <summary>
    /// Loadout Report Implementation
    /// </summary>
    public class LoadoutReport : AbstractReport, ILoadoutReport
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
        ISet<IGearReport> ILoadoutReport.GetGearReports(GearType gearType)
        {
            ISet<IGearReport> gearReports = new HashSet<IGearReport>();

            foreach (IGearReport gearReport in _gearReports)
            {
                GearModelConstantsManager.GetConstants(gearReport.GetGearID()).IfPresent(gearModelConstants =>
                {
                    if (gearModelConstants.GetGearType() == gearType)
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

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("[{0}]", string.Join(", ", _gearReports));
        }

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder : IBuilder<ILoadoutReport>
            {
                IBuilder SetGearReports(ISet<IGearReport> gearReports);
            }

            /// <summary>
            /// Get the Builder for this object
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Builder Implementation for this object
            /// </summary>
            private class InternalBuilder : AbstractBuilder<ILoadoutReport>, IBuilder
            {
                // Todo
                private ISet<IGearReport> _gearReports = new HashSet<IGearReport>();

                /// <inheritdoc/>
                IBuilder IBuilder.SetGearReports(ISet<IGearReport> gearReports)
                {
                    _gearReports = new HashSet<IGearReport>(gearReports);
                    return this;
                }

                /// <inheritdoc/>
                protected override ILoadoutReport BuildObj()
                {
                    // Instantiate a new attributes
                    return new LoadoutReport(_gearReports);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _gearReports);
                }
            }
        }
    }
}