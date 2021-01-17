namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Roes.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Roes.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct RoeReport
        : IRoeReport
    {
        // Todo
        private readonly ISet<ISet<TalonCallSign>> friendlyTalonCallSignSets;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="friendlyTalonCallSignSets"></param>
        public RoeReport(ISet<ISet<TalonCallSign>> friendlyTalonCallSignSets)
        {
            this.friendlyTalonCallSignSets = new HashSet<ISet<TalonCallSign>>(friendlyTalonCallSignSets);
        }

        /// <inheritdoc/>
        ISet<ISet<TalonCallSign>> IRoeReport.GetFriendlyTalonCallSignSets()
        {
            return new HashSet<ISet<TalonCallSign>>(this.friendlyTalonCallSignSets);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            ISet<string> friendlyTalonCallSignSetsString = new HashSet<string>();
            foreach (ISet<TalonCallSign> talonCallSignSet in this.friendlyTalonCallSignSets)
            {
                friendlyTalonCallSignSetsString.Add("(" + string.Join(", ", talonCallSignSet) + ")");
            }
            return string.Format("{0}: Set: Friendly {1}=[{2}]",
                this.GetType().Name, typeof(TalonCallSign).Name,
                string.Join(", ", friendlyTalonCallSignSetsString));
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ISet<ISet<TalonCallSign>> friendlyTalonCallSignSets = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IRoeReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new RoeReport(this.friendlyTalonCallSignSets);
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
            /// <param name="friendlyTalonCallSignSets"></param>
            /// <returns></returns>
            public Builder SetFriendlyTalonCallSignSets(ISet<ISet<TalonCallSign>> friendlyTalonCallSignSets)
            {
                this.friendlyTalonCallSignSets = new HashSet<ISet<TalonCallSign>>(friendlyTalonCallSignSets);
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
                // Check that friendlyTalonCallSignSets has been set
                if (this.friendlyTalonCallSignSets == null)
                {
                    argumentExceptionSet.Add("friendlyTalonCallSignSets has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}