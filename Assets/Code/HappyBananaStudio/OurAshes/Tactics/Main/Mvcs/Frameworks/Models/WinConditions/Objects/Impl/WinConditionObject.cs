namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.WinConditions.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Phalanxes.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Phalanxes.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.WinConditions.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.WinConditions.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.WinConditions.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Reports.Phalanxes.Api;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// WinCondition Object Impl
    /// </summary>
    public class WinConditionObject
        : IWinConditionObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly MatchType matchType;

        // Todo
        private readonly ITalonRosterObject rosterObject;

        // Todo
        private readonly IPhalanxRosterObject phalanxRosterObject;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="matchType"></param>
        private WinConditionObject(MatchType matchType,
            ITalonRosterObject rosterObject, IPhalanxRosterObject phalanxRosterObject)
        {
            this.matchType = matchType;
            this.phalanxRosterObject = phalanxRosterObject;
            this.rosterObject = rosterObject;
        }

        /// <inheritdoc/>
        IWinConditionReport IWinConditionObject.GetWinConditionReport()
        {
            return new WinConditionReport.Builder()
                .SetMatchType(this.matchType)
                .GetTalonCallSignSet(this.GetTalonCallSignSet())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private ISet<TalonCallSign> GetTalonCallSignSet()
        {
            ISet<TalonCallSign> talonCallSigns = new HashSet<TalonCallSign>();
            ISet<TalonCallSign> remainingActiveTalonCallSigns = this.CheckEliminationWinCondition();
            if (remainingActiveTalonCallSigns.Count > 0)
            {
                return remainingActiveTalonCallSigns;
            }
            return talonCallSigns;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private ISet<TalonCallSign> CheckEliminationWinCondition()
        {
            ISet<TalonCallSign> talonCallSignSet = new HashSet<TalonCallSign>();
            IPhalanxRosterReport phalanxRosterReport = this.phalanxRosterObject.GetPhalanxRosterReport();
            IDictionary<PhalanxCallSign, ISet<TalonCallSign>> phalanxCallSignTalonCallSignSetDictionary =
                new Dictionary<PhalanxCallSign, ISet<TalonCallSign>>();

            foreach (IPhalanxReport phalanxReport in phalanxRosterReport.GetPhalanxReports())
            {
                phalanxCallSignTalonCallSignSetDictionary.Add(
                    phalanxReport.GetPhalanxCallSign(), phalanxReport.GetTalonCallSigns());
            }

            ISet<ISet<TalonCallSign>> friendlyTalonCallSignSets = this.GetFriendlyTalonCallSignsSet(
                this.GetFriendlyPhalanxCallSignsSet(phalanxRosterReport), phalanxCallSignTalonCallSignSetDictionary);

            ISet<ISet<TalonCallSign>> activeFriendlyTalonCallSignSets = new HashSet<ISet<TalonCallSign>>(friendlyTalonCallSignSets);

            foreach (ISet<TalonCallSign> talonCallSigns in friendlyTalonCallSignSets)
            {
                bool isActive = false;
                foreach (TalonCallSign talonCallSign in talonCallSigns)
                {
                    if (this.rosterObject.IsTalonCallSignActive(talonCallSign))
                    {
                        logger.Debug("? of [?] is still active",
                            talonCallSign, string.Join(", ", talonCallSigns));
                        isActive = true;
                        break;
                    }
                }
                if (!isActive)
                {
                    logger.Debug("All of [?] are inactive", string.Join(", ", talonCallSigns));
                    activeFriendlyTalonCallSignSets.Remove(talonCallSigns);
                }
            }

            if (activeFriendlyTalonCallSignSets.Count == 1)
            {
                talonCallSignSet.UnionWith(
                    new List<ISet<TalonCallSign>>(activeFriendlyTalonCallSignSets)[0]);
            }

            return talonCallSignSet;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxRosterReport"></param>
        /// <returns></returns>
        private ISet<ISet<PhalanxCallSign>> GetFriendlyPhalanxCallSignsSet(IPhalanxRosterReport phalanxRosterReport)
        {
            ISet<ISet<PhalanxCallSign>> friendlyPhalanxCallSignSets = new HashSet<ISet<PhalanxCallSign>>();
            ISet<PhalanxCallSign> visitedPhalanxCallSigns = new HashSet<PhalanxCallSign>();
            foreach (IPhalanxReport phalanxReport in phalanxRosterReport.GetPhalanxReports())
            {
                PhalanxCallSign phalanxCallSign = phalanxReport.GetPhalanxCallSign();
                if (!visitedPhalanxCallSigns.Contains(phalanxCallSign))
                {
                    ISet<PhalanxCallSign> friendlyPhalanxCallSigns = phalanxReport.GetFriendlyPhalanxCallSigns();
                    friendlyPhalanxCallSigns.Add(phalanxReport.GetPhalanxCallSign());
                    friendlyPhalanxCallSignSets.Add(friendlyPhalanxCallSigns);
                    visitedPhalanxCallSigns.UnionWith(friendlyPhalanxCallSigns);
                }
            }

            return friendlyPhalanxCallSignSets;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxRosterReport"></param>
        /// <returns></returns>
        private ISet<ISet<TalonCallSign>> GetFriendlyTalonCallSignsSet(ISet<ISet<PhalanxCallSign>> friendlyPhalanxCallSignSets,
            IDictionary<PhalanxCallSign, ISet<TalonCallSign>> phalanxCallSignTalonCallSignSetDictionary)
        {
            ISet<ISet<TalonCallSign>> friendlyTalonCallSignSets = new HashSet<ISet<TalonCallSign>>();

            foreach (ISet<PhalanxCallSign> phalanxCallSigns in friendlyPhalanxCallSignSets)
            {
                ISet<TalonCallSign> friendlyTalonCallSigns = new HashSet<TalonCallSign>();
                foreach (PhalanxCallSign phalanxCallSign in phalanxCallSigns)
                {
                    friendlyTalonCallSigns.UnionWith(phalanxCallSignTalonCallSignSetDictionary[phalanxCallSign]);
                }
                friendlyTalonCallSignSets.Add(friendlyTalonCallSigns);
            }
            return friendlyTalonCallSignSets;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private MatchType matchType = MatchType.None;

            // Todo
            private ITalonRosterObject rosterObject = null;

            // Todo
            private IPhalanxRosterObject phalanxRosterObject = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IWinConditionObject Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new WinConditionObject(this.matchType, this.rosterObject, this.phalanxRosterObject);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="matchType"></param>
            /// <returns></returns>
            public Builder SetMatchType(MatchType matchType)
            {
                this.matchType = matchType;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="phalanxRosterObject"></param>
            /// <returns></returns>
            public Builder SetPhalanxRosterObject(IPhalanxRosterObject phalanxRosterObject)
            {
                this.phalanxRosterObject = phalanxRosterObject;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonRosterObject"></param>
            /// <returns></returns>
            public Builder SetTalonRosterObject(ITalonRosterObject talonRosterObject)
            {
                this.rosterObject = talonRosterObject;
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
                // Check that matchType has been set
                if (this.matchType == MatchType.None)
                {
                    argumentExceptionSet.Add(typeof(MatchType).Name + " can not be none.");
                }
                // Check that phalanxRosterObject has been set
                if (this.phalanxRosterObject == null)
                {
                    argumentExceptionSet.Add(typeof(IPhalanxRosterObject).Name + " can not be null.");
                }
                // Check that rosterObject has been set
                if (this.rosterObject == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonRosterObject).Name + " can not be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}