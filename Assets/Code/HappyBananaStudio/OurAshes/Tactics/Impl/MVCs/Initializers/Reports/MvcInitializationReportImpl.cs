namespace HappyBananaStudio.OurAshes.Tactics.Impl.MVCs.Initializers.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Maps.Games.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Initializers.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct MvcInitializationReportImpl
        : IMvcInitializationReport
    {
        // Todo
        private readonly IGameMapConstructionReport gameMapConstructionReport;

        // Todo
        private readonly int gameRNGSeed;

        // Todo
        private readonly IRosterConstructionReport rosterConstructionReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameMapConstructionReport">
        /// </param>
        /// <param name="gameRNGSeed">
        /// </param>
        /// <param name="rosterConstructionReport">
        /// </param>
        private MvcInitializationReportImpl(IGameMapConstructionReport gameMapConstructionReport,
            int gameRNGSeed, IRosterConstructionReport rosterConstructionReport)
        {
            this.gameMapConstructionReport = gameMapConstructionReport;
            this.gameRNGSeed = gameRNGSeed;
            this.rosterConstructionReport = rosterConstructionReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IGameMapConstructionReport GetGameMapConstructionReport()
        {
            return this.gameMapConstructionReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetGameRNGSeed()
        {
            return this.gameRNGSeed;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IRosterConstructionReport GetRosterConstructionReport()
        {
            return this.rosterConstructionReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ": " +
                "\n\t>" + this.GetGameMapConstructionReport() +
                "\n\t>Game RNG Seed: " + this.GetGameRNGSeed() +
                "\n\t>" + this.GetRosterConstructionReport();
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private IGameMapConstructionReport gameMapConstructionReport = null;

            // Todo
            private int gameRNGSeed;

            // Todo
            private IRosterConstructionReport rosterConstructionReport = null;

            // Todo
            private bool setGameRNGSeed = false;

            /// <summary>
            /// Build the GameInitializationReport with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public IMvcInitializationReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new MvcInitializationReportImpl(this.gameMapConstructionReport,
                        this.gameRNGSeed, this.rosterConstructionReport);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of IGameMapConstructionReport
            /// </summary>
            /// <param name="gameMapConstructionReport">
            /// The IGameMapConstructionReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetGameMapConstructionReport(IGameMapConstructionReport gameMapConstructionReport)
            {
                this.gameMapConstructionReport = gameMapConstructionReport;
                return this;
            }

            /// <summary>
            /// Set the value of gameRNGSeed
            /// </summary>
            /// <param name="gameRNGSeed">
            /// The gameRNGSeed to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetGameRNGSeed(int gameRNGSeed)
            {
                this.gameRNGSeed = gameRNGSeed;
                this.setGameRNGSeed = true;
                return this;
            }

            /// <summary>
            /// Set the value of IRosterConstructionReport
            /// </summary>
            /// <param name="rosterConstructionReport">
            /// The IRosterConstructionReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetRosterConstructionReport(IRosterConstructionReport rosterConstructionReport)
            {
                this.rosterConstructionReport = rosterConstructionReport;
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
                // Check that gameMapConstructionReport has been set
                if (this.gameMapConstructionReport == null)
                {
                    argumentExceptionSet.Add(typeof(IGameMapConstructionReport).Name + " has not been set");
                }
                // Check that gameRNGSeed has been set
                if (!this.setGameRNGSeed)
                {
                    argumentExceptionSet.Add("gameRNGSeed has not been set");
                }
                // Check that rosterConstructionReport has been set
                if (this.rosterConstructionReport == null)
                {
                    argumentExceptionSet.Add(typeof(IRosterConstructionReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}