namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Constructions.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Reports.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Roster Object Impl
    /// </summary>
    public class TalonRosterObject
        : ITalonRosterObject
    {
        // Todo
        private readonly ISet<TalonCallSign> activeTalonCallSignSet = new HashSet<TalonCallSign>();

        // Todo
        private readonly IDictionary<TalonCallSign, ITalonObject> talonCallSignObjectDictionary =
            new Dictionary<TalonCallSign, ITalonObject>();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonConstructionReportSet"></param>
        private TalonRosterObject(ISet<ITalonConstructionReport> talonConstructionReportSet)
        {
            this.activeTalonCallSignSet = new HashSet<TalonCallSign>();
            this.talonCallSignObjectDictionary = new Dictionary<TalonCallSign, ITalonObject>();
            foreach (ITalonConstructionReport talonConstructionReport in talonConstructionReportSet)
            {
                TalonCallSign talonCallSign = talonConstructionReport.GetTalonCallSign();
                this.activeTalonCallSignSet.Add(talonCallSign);
                this.talonCallSignObjectDictionary.Add(talonCallSign,
                    new TalonObject.Builder()
                    .SetTalonCallSign(talonCallSign)
                    .SetTalonLoadoutReport(talonConstructionReport.GetTalonLoadoutReport())
                    .SetCustomizationReport(talonConstructionReport.GetCustomizationReport())
                    .Build());
            }
        }

        /// <inheritdoc/>
        void ITalonRosterObject.DeactivateTalonCallSign(TalonCallSign callSign)
        {
            if (this.activeTalonCallSignSet.Contains(callSign))
            {
                this.activeTalonCallSignSet.Remove(callSign);
            }
            else
            {
                throw ExceptionUtil.Arguments.Build();
            }
        }

        /// <inheritdoc/>
        ISet<TalonCallSign> ITalonRosterObject.GetActiveTalonCallSignSet()
        {
            return new HashSet<TalonCallSign>(this.activeTalonCallSignSet);
        }

        /// <inheritdoc/>
        ISet<TalonCallSign> ITalonRosterObject.GetAllTalonCallSignSet()
        {
            return new HashSet<TalonCallSign>(this.talonCallSignObjectDictionary.Keys);
        }

        /// <inheritdoc/>
        ITalonRosterReport ITalonRosterObject.GetTalonRosterReport()
        {
            IDictionary<TalonCallSign, ITalonReport> talonCallSignReportDictionary = new Dictionary<TalonCallSign, ITalonReport>();
            foreach (KeyValuePair<TalonCallSign, ITalonObject> entry in this.talonCallSignObjectDictionary)
            {
                talonCallSignReportDictionary.Add(entry.Key, entry.Value.GetTalonReport());
            }
            return new TalonRosterReport.Builder()
                .SetActiveTalonCallSignSet(this.activeTalonCallSignSet)
                .SetTalonCallSignReportDictionary(talonCallSignReportDictionary)
                .Build();
        }

        /// <inheritdoc/>
        ITalonObject ITalonRosterObject.GetTalonObject(TalonCallSign talonCallSign)
        {
            if (this.talonCallSignObjectDictionary.ContainsKey(talonCallSign))
            {
                return this.talonCallSignObjectDictionary[talonCallSign];
            }
            else
            {
                throw ExceptionUtil.Arguments.Build();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <returns></returns>
        bool ITalonRosterObject.IsTalonCallSignActive(TalonCallSign talonCallSign)
        {
            if (this.talonCallSignObjectDictionary.ContainsKey(talonCallSign))
            {
                return this.talonCallSignObjectDictionary[talonCallSign].GetTalonReport()
                    .GetCurrentTalonAttributesReport().GetHealthPoints() >= 0;
            }
            else
            {
                throw ExceptionUtil.Arguments.Build();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ISet<ITalonConstructionReport> talonConstructionReportSet = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ITalonRosterObject Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new TalonRosterObject(this.talonConstructionReportSet);
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonConstructionReportSet"></param>
            /// <returns></returns>
            public Builder SetTalonConstructionReportSet(ISet<ITalonConstructionReport> talonConstructionReportSet)
            {
                if (talonConstructionReportSet != null)
                {
                    this.talonConstructionReportSet =
                        new HashSet<ITalonConstructionReport>(talonConstructionReportSet);
                }
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
                // Check that talonConstructionReportSet has been set
                if (this.talonConstructionReportSet == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(ITalonConstructionReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}