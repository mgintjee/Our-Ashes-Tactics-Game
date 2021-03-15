using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.WinConditions.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Enums;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.WinConditions.Reports.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct WinConditionReport
        : IWinConditionReport
    {
        // Todo
        private readonly MatchType matchType;

        // Todo
        private readonly ISet<TalonCallSign> talonCallSignSet;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="matchType"></param>
        /// <param name="talonCallSignSet"></param>
        private WinConditionReport(MatchType matchType, ISet<TalonCallSign> talonCallSignSet)
        {
            this.matchType = matchType;
            this.talonCallSignSet = talonCallSignSet;
        }

        /// <inheritdoc/>
        MatchType IWinConditionReport.GetMatchType()
        {
            return this.matchType;
        }

        /// <inheritdoc/>
        ISet<TalonCallSign> IWinConditionReport.GetTalonCallSignSet()
        {
            return new HashSet<TalonCallSign>(this.talonCallSignSet);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}={2}, Winning {3}s: [{4}]",
                this.GetType().Name, typeof(MatchType).Name, this.matchType, typeof(PhalanxCallSign).Name,
                string.Join(", ", this.talonCallSignSet));
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private MatchType matchType = MatchType.None;

            // Todo
            private ISet<TalonCallSign> talonCallSignSet = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IWinConditionReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new WinConditionReport(this.matchType, this.talonCallSignSet);
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
            /// <param name="talonCallSignSet"></param>
            /// <returns></returns>
            public Builder GetTalonCallSignSet(ISet<TalonCallSign> talonCallSignSet)
            {
                if (talonCallSignSet != null)
                {
                    this.talonCallSignSet = new HashSet<TalonCallSign>(talonCallSignSet);
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
                // Check that matchType has been set
                if (this.matchType == MatchType.None)
                {
                    argumentExceptionSet.Add(typeof(MatchType).Name + " has not been set");
                }
                // Check that talonCallSignSet has been set
                if (this.talonCallSignSet == null)
                {
                    argumentExceptionSet.Add("Set:" + typeof(TalonCallSign) + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}