namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Roes.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Roes.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Roes.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Roes.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Roe Object Class
    /// </summary>
    public class RoeObject
        : IRoeObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);
        // Todo
        private readonly ISet<ISet<TalonCallSign>> friendlyTalonCallSignSets;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="friendlyTalonCallSignSets">
        /// </param>
        private RoeObject(ISet<ISet<TalonCallSign>> friendlyTalonCallSignSets)
        {
            this.friendlyTalonCallSignSets = new HashSet<ISet<TalonCallSign>>(friendlyTalonCallSignSets);
        }

        /// <inheritdoc/>
        bool IRoeObject.AreCallSignsFriendly(TalonCallSign talonCallSignA, TalonCallSign talonCallSignB)
        {
            foreach (ISet<TalonCallSign> friendlyTalonCallSignSet in this.friendlyTalonCallSignSets)
            {
                logger.Debug("[?]", string.Join(", ", friendlyTalonCallSignSet));
                if (friendlyTalonCallSignSet.Contains(talonCallSignA) &&
                    friendlyTalonCallSignSet.Contains(talonCallSignB))
                {
                    logger.Debug("[?] contains both ? and ?",
                        string.Join(", ", friendlyTalonCallSignSet),
                        talonCallSignA, talonCallSignB);
                    return true;
                }
            }
            return false;
        }

        /// <inheritdoc/>
        ISet<TalonCallSign> IRoeObject.GetFriendlyCallSignSet(TalonCallSign callSign)
        {
            foreach (ISet<TalonCallSign> friendlyTalonCallSignSet in this.friendlyTalonCallSignSets)
            {
                if (friendlyTalonCallSignSet.Contains(callSign))
                {
                    return new HashSet<TalonCallSign>(friendlyTalonCallSignSet);
                }
            }
            return new HashSet<TalonCallSign>();
        }

        /// <inheritdoc/>
        IRoeReport IRoeObject.GetRoeReport()
        {
            return new RoeReport.Builder()
                .SetFriendlyTalonCallSignSets(this.friendlyTalonCallSignSets)
                .Build();
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
            public IRoeObject Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new RoeObject(this.friendlyTalonCallSignSets);
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
                this.friendlyTalonCallSignSets = new HashSet<ISet<TalonCallSign>>();
                foreach (ISet<TalonCallSign> friendlyTalonCallSignSet in friendlyTalonCallSignSets)
                {
                    this.friendlyTalonCallSignSets.Add(new HashSet<TalonCallSign>(friendlyTalonCallSignSet));
                }
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonCallSignSet"></param>
            /// <returns></returns>
            public Builder SetFriendlyCallSignDictionary(ISet<TalonCallSign> talonCallSignSet)
            {
                this.friendlyTalonCallSignSets = new HashSet<ISet<TalonCallSign>>();
                foreach (TalonCallSign talonCallSign in talonCallSignSet)
                {
                    this.friendlyTalonCallSignSets.Add(new HashSet<TalonCallSign>() { talonCallSign });
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