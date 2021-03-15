namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Phalanxes.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Phalanxes.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Phalanxes.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Phalanxes.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Reports.Phalanxes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public class PhalanxRosterObject
        : IPhalanxRosterObject
    {
        // Todo
        private readonly IDictionary<PhalanxCallSign, IPhalanxReport> phalanxCallSignReportDictionary;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxReportSet"></param>
        private PhalanxRosterObject(ISet<IPhalanxReport> phalanxReportSet)
        {
            this.phalanxCallSignReportDictionary = new Dictionary<PhalanxCallSign, IPhalanxReport>();
            foreach (IPhalanxReport phalanxReport in phalanxReportSet)
            {
                this.phalanxCallSignReportDictionary.Add(phalanxReport.GetPhalanxCallSign(), phalanxReport);
            }
        }

        /// <inheritdoc/>s
        IPhalanxRosterReport IPhalanxRosterObject.GetPhalanxRosterReport()
        {
            return new PhalanxRosterReport.Builder()
                .SetPhalanxReports(new HashSet<IPhalanxReport>(this.phalanxCallSignReportDictionary.Values))
                .Build();
        }

        /// <inheritdoc/>
        PhalanxCallSign IPhalanxRosterObject.GetPhalanxCallSign(TalonCallSign talonCallSign)
        {
            PhalanxCallSign phalanxCallSign = PhalanxCallSign.None;

            foreach (IPhalanxReport phalanxReport in this.phalanxCallSignReportDictionary.Values)
            {
                if (phalanxReport.GetTalonCallSigns().Contains(talonCallSign))
                {
                    phalanxCallSign = phalanxReport.GetPhalanxCallSign();
                    break;
                }
            }

            return phalanxCallSign;
        }

        /// <inheritdoc/>
        bool IPhalanxRosterObject.ArePhalanxCallSignsFriendly(
            PhalanxCallSign phalanxCallSignA, PhalanxCallSign phalanxCallSignB)
        {
            bool areFriendly = false;

            if (this.phalanxCallSignReportDictionary.ContainsKey(phalanxCallSignA) &&
                this.phalanxCallSignReportDictionary.ContainsKey(phalanxCallSignB))
            {
                ISet<PhalanxCallSign> friendlyPhalanxCallSignSet = this.phalanxCallSignReportDictionary
                    [phalanxCallSignA].GetFriendlyPhalanxCallSigns();
                friendlyPhalanxCallSignSet.IntersectWith(this.phalanxCallSignReportDictionary
                    [phalanxCallSignB].GetFriendlyPhalanxCallSigns());
                areFriendly = friendlyPhalanxCallSignSet.Contains(phalanxCallSignA) &&
                    friendlyPhalanxCallSignSet.Contains(phalanxCallSignB);
            }

            return areFriendly;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: " +
                "\n\t>{1}",
                this.GetType().Name,
                string.Join("\n\t>", this.phalanxCallSignReportDictionary.Values));
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ISet<IPhalanxReport> phalanxReportSet = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IPhalanxRosterObject Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new PhalanxRosterObject(this.phalanxReportSet);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                    typeof(PhalanxRosterObject).Name, string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="phalanxReportSet"></param>
            /// <returns></returns>
            public Builder SetPhalanxReportSet(ISet<IPhalanxReport> phalanxReportSet)
            {
                if (phalanxReportSet != null)
                {
                    this.phalanxReportSet = phalanxReportSet;
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
                // Check that phalanxReportSet has been set
                if (this.phalanxReportSet == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(IPhalanxReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}