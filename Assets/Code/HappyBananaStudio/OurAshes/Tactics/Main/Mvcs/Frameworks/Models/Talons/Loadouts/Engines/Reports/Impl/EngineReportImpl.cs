namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Constants;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Reports.Api;
    using HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct EngineReportImpl
        : IEngineReport
    {
        // Todo
        private readonly EngineId engineId;

        // Todo
        private readonly LoadoutRarity loadoutRarity;

        // Todo
        private readonly EngineTraitEfficiency engineTraitEfficiency;

        // Todo
        private readonly EngineTraitStructure engineTraitStructure;

        // Todo
        private readonly ILoadoutAttributes loadoutAttributes;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="engineId"></param>
        /// <param name="engineTraitEfficiency"></param>
        /// <param name="engineTraitStructure"></param>
        private EngineReportImpl(EngineId engineId, EngineTraitEfficiency engineTraitEfficiency, EngineTraitStructure engineTraitStructure)
        {
            this.engineId = engineId;
            this.loadoutRarity = EngineRarityConstants.GetLoadoutRarity(this.engineId);
            this.engineTraitEfficiency = engineTraitEfficiency;
            this.engineTraitStructure = engineTraitStructure;
            ISet<ILoadoutAttributes> loadoutAttributesSet = new HashSet<ILoadoutAttributes>()
            {
                EngineTraitConstants.Efficiency.GetLoadoutAttributes(this.engineTraitEfficiency),
                EngineTraitConstants.Structures.GetLoadoutAttributes(this.engineTraitStructure),
                EngineIdConstants.GetLoadoutAttributes(this.engineId)
            };
            this.loadoutAttributes = new LoadoutAttributesImpl.Builder().Build(loadoutAttributesSet);
        }

        /// <inheritdoc/>
        EngineId IEngineReport.GetEngineId()
        {
            return this.engineId;
        }

        /// <inheritdoc/>
        EngineTraitEfficiency IEngineReport.GetEngineTraitEfficiency()
        {
            return this.engineTraitEfficiency;
        }

        /// <inheritdoc/>
        EngineTraitStructure IEngineReport.GetEngineTraitStructure()
        {
            return this.engineTraitStructure;
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

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private EngineId engineId = EngineId.None;

            // Todo
            private EngineTraitEfficiency engineTraitEfficiency = EngineTraitEfficiency.None;

            // Todo
            private EngineTraitStructure engineTraitStructure = EngineTraitStructure.None;

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
                    return new EngineReportImpl(this.engineId, this.engineTraitEfficiency, this.engineTraitStructure);
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
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
            /// <param name="engineTraitEfficiency"></param>
            public Builder SetEngineTraitEfficiency(EngineTraitEfficiency engineTraitEfficiency)
            {
                this.engineTraitEfficiency = engineTraitEfficiency;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="engineTraitStructure"></param>
            public Builder SetEngineTraitStructure(EngineTraitStructure engineTraitStructure)
            {
                this.engineTraitStructure = engineTraitStructure;
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
                    argumentExceptionSet.Add(typeof(EngineId).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}