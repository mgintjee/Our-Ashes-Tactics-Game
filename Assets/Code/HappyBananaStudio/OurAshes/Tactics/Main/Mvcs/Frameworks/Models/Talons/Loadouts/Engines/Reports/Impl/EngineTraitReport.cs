namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Reports.Api;

    /// <summary>
    /// Engine Trait Report Impl
    /// </summary>
    public class EngineTraitReport
        : IEngineTraitReport
    {
        // Todo
        private readonly EngineTraitStructure engineTraitStructure;

        // Todo
        private readonly EngineTraitEfficiency engineTraitEfficiency;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="engineTraitStructure"></param>
        /// <param name="engineTraitEfficiency"></param>
        private EngineTraitReport(EngineTraitStructure engineTraitStructure, EngineTraitEfficiency engineTraitEfficiency)
        {
            this.engineTraitStructure = engineTraitStructure;
            this.engineTraitEfficiency = engineTraitEfficiency;
        }

        /// <inheritdoc/>
        EngineTraitEfficiency IEngineTraitReport.GetEngineTraitEfficiency()
        {
            return this.engineTraitEfficiency;
        }

        /// <inheritdoc/>
        EngineTraitStructure IEngineTraitReport.GetEngineTraitStructure()
        {
            return this.engineTraitStructure;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}={2}, {3}={4}",
                this.GetType().Name, typeof(EngineTraitStructure).Name, this.engineTraitStructure,
                typeof(EngineTraitEfficiency).Name, this.engineTraitEfficiency);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private EngineTraitStructure engineTraitStructure = EngineTraitStructure.None;

            // Todo
            private EngineTraitEfficiency engineTraitEfficiency = EngineTraitEfficiency.None;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IEngineTraitReport Build()
            {
                // Instantiate a new Report
                return new EngineTraitReport(this.engineTraitStructure, this.engineTraitEfficiency);
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
            /// <param name="engineTraitEfficiency"></param>
            public Builder SetEngineTraitEfficiency(EngineTraitEfficiency engineTraitEfficiency)
            {
                this.engineTraitEfficiency = engineTraitEfficiency;
                return this;
            }
        }
    }
}