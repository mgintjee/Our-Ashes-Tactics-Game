using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Common.Attributes.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Common.Attributes.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Common.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Constants;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Traits.Constants;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Traits.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Traits.Reports.Impl;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Reports.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct EngineReport
        : IEngineReport
    {
        // Todo
        private readonly EngineId engineId;

        // Todo
        private readonly LoadoutRarity loadoutRarity;

        // Todo
        private readonly IEngineTraitReport engineTraitReport;

        // Todo
        private readonly ILoadoutAttributes loadoutAttributes;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="engineId"></param>
        /// <param name="engineTraitReport"></param>
        private EngineReport(EngineId engineId, IEngineTraitReport engineTraitReport)
        {
            this.engineId = engineId;
            this.loadoutRarity = EngineRarityConstants.GetLoadoutRarity(this.engineId);
            this.engineTraitReport = engineTraitReport;
            ISet<ILoadoutAttributes> loadoutAttributesSet = new HashSet<ILoadoutAttributes>()
            {
                EngineTraitConstants.Efficiency.GetLoadoutAttributes(this.engineTraitReport.GetEngineTraitEfficiency()),
                EngineTraitConstants.Structures.GetLoadoutAttributes(this.engineTraitReport.GetEngineTraitStructure()),
                EngineIdConstants.GetLoadoutAttributes(this.engineId)
            };
            this.loadoutAttributes = new LoadoutAttributes.Builder().Build(loadoutAttributesSet);
        }

        /// <inheritdoc/>
        EngineId IEngineReport.GetEngineId()
        {
            return this.engineId;
        }

        /// <inheritdoc/>
        IEngineTraitReport IEngineReport.GetEngineTraitReport()
        {
            return this.engineTraitReport;
        }

        /// <inheritdoc/>
        ILoadoutAttributes ILoadoutReport.GetLoadoutAttributes()
        {
            return this.loadoutAttributes;
        }

        /// <inheritdoc/>
        LoadoutRarity ILoadoutReport.GetLoadoutRarity()
        {
            return this.loadoutRarity;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}={2}, {3}={4}" +
                "\n\t>{5}" +
                "\n\t>{6}",
                this.GetType().Name, typeof(EngineId).Name, this.engineId,
                typeof(LoadoutRarity).Name, this.loadoutRarity,
                this.engineTraitReport, this.loadoutAttributes);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private EngineId engineId = EngineId.None;

            // Todo
            private IEngineTraitReport engineTraitReport = new EngineTraitReport.Builder().Build();

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IEngineReport Build()
            {
                // Collect the invalid reasons to be built
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new EngineReport(this.engineId, this.engineTraitReport);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="engineId"></param>
            public Builder SetEngineId(EngineId engineId)
            {
                this.engineId = engineId;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="engineTraitReport"></param>
            public Builder SetEngineTraitReport(IEngineTraitReport engineTraitReport)
            {
                this.engineTraitReport = engineTraitReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that engineId has been set
                if (this.engineId == EngineId.None)
                {
                    argumentExceptionSet.Add(typeof(EngineId).Name + " cannot be null.");
                }
                // Check that engineTraitReport has been set
                if (this.engineTraitReport == null)
                {
                    argumentExceptionSet.Add(typeof(IEngineTraitReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}