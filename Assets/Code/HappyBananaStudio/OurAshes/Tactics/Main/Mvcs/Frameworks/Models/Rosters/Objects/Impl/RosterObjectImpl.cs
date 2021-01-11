namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Constructions.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Reports.Impl;
    using System.Collections.Generic;

    /// <summary>
    /// Roster Object Impl
    /// </summary>
    public class RosterObjectImpl
        : IRosterObject
    {
        // Todo
        private readonly ISet<TalonCallSign> activeTalonCallSignSet = new HashSet<TalonCallSign>();

        // Todo
        private readonly IDictionary<TalonCallSign, ITalonObject> talonCallSignObjectDictionary =
            new Dictionary<TalonCallSign, ITalonObject>();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSignConstructionReportDictionary"></param>
        private RosterObjectImpl(
            IDictionary<TalonCallSign, ITalonConstructionReport> talonCallSignConstructionReportDictionary)
        {
            this.activeTalonCallSignSet = new HashSet<TalonCallSign>();
            this.talonCallSignObjectDictionary = new Dictionary<TalonCallSign, ITalonObject>();
            foreach (KeyValuePair<TalonCallSign, ITalonConstructionReport> entry in talonCallSignConstructionReportDictionary)
            {
                TalonCallSign talonCallSign = entry.Key;
                this.activeTalonCallSignSet.Add(entry.Key);
                this.talonCallSignObjectDictionary.Add(entry.Key,
                    new TalonObjectImpl.Builder()
                    .SetTalonCallSign(talonCallSign)
                    .SetTalonLoadoutReport(entry.Value.GetTalonLoadoutReport())
                    .SetCustomizationReport(entry.Value.GetCustomizationReport())
                    .Build());
            }
        }

        /// <inheritdoc/>
        void IRosterObject.DeactivateTalonCallSign(TalonCallSign callSign)
        {
            if (this.activeTalonCallSignSet.Contains(callSign))
            {
                this.activeTalonCallSignSet.Remove(callSign);
            }
            else
            {
                throw ExceptionUtil.Argument.Build();
            }
        }

        /// <inheritdoc/>
        ISet<TalonCallSign> IRosterObject.GetActiveTalonCallSignSet()
        {
            return new HashSet<TalonCallSign>(this.activeTalonCallSignSet);
        }

        /// <inheritdoc/>
        ISet<TalonCallSign> IRosterObject.GetAllTalonCallSignSet()
        {
            return new HashSet<TalonCallSign>(this.talonCallSignObjectDictionary.Keys);
        }

        /// <inheritdoc/>
        IRosterReport IRosterObject.GetRosterReport()
        {
            IDictionary<TalonCallSign, ITalonReport> talonCallSignObjectDictionary = new Dictionary<TalonCallSign, ITalonReport>();
            foreach (KeyValuePair<TalonCallSign, ITalonObject> entry in this.talonCallSignObjectDictionary)
            {
                talonCallSignObjectDictionary.Add(entry.Key,
                    new TalonReportImpl.Builder()
                    .Build());
            }
            return new RosterReportImpl.Builder()
                .SetActiveTalonCallSignSet(this.activeTalonCallSignSet)
                .SetTalonCallSignReportDictionary(talonCallSignObjectDictionary)
                .Build();
        }

        /// <inheritdoc/>
        ITalonObject IRosterObject.GetTalonObject(TalonCallSign callSign)
        {
            if (this.talonCallSignObjectDictionary.ContainsKey(callSign))
            {
                return this.talonCallSignObjectDictionary[callSign];
            }
            else
            {
                throw ExceptionUtil.Argument.Build();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IDictionary<TalonCallSign, ITalonConstructionReport> talonCallSignConstructionReportDictionary = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IRosterObject Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new RosterObjectImpl(this.talonCallSignConstructionReportDictionary);
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
            /// <param name="talonCallSignCustomizationReportDictionary"></param>
            /// <returns></returns>
            public Builder SetTalonCallSignConstructionReportDictionary(
                IDictionary<TalonCallSign, ITalonConstructionReport> talonCallSignCustomizationReportDictionary)
            {
                if (talonCallSignCustomizationReportDictionary != null)
                {
                    this.talonCallSignConstructionReportDictionary =
                        new Dictionary<TalonCallSign, ITalonConstructionReport>(talonCallSignCustomizationReportDictionary);
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
                // Check that talonCallSignConstructionReportDictionary has been set
                if (this.talonCallSignConstructionReportDictionary == null)
                {
                    argumentExceptionSet.Add("talonCallSignConstructionReportDictionary has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}