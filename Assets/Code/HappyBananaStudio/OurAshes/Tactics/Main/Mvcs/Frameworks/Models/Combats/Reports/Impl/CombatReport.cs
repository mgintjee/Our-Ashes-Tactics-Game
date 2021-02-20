namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Combats.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Combats.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Effects.Objects.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct CombatReport
        : ICombatReport
    {
        // Todo
        private readonly ISet<ITalonEffectObject> talonEffectObjectSet;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonEffectObjectSet"></param>
        private CombatReport(ISet<ITalonEffectObject> talonEffectObjectSet)
        {
            this.talonEffectObjectSet = talonEffectObjectSet;
        }

        /// <inheritdoc/>
        ISet<ITalonEffectObject> ICombatReport.GetTalonEffectObjectSet()
        {
            return new HashSet<ITalonEffectObject>(this.talonEffectObjectSet);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: Set: {1}=[\n\t>{2}]",
                this.GetType().Name, typeof(ITalonEffectObject).Name,
                string.Join("\n\t>", this.talonEffectObjectSet));
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ISet<ITalonEffectObject> talonEffectObjectSet = new HashSet<ITalonEffectObject>();

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ICombatReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new CombatReport(this.talonEffectObjectSet);
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
            /// <param name="talonEffectObjectSet"></param>
            /// <returns></returns>
            public Builder SetTalonEffectObjectSet(ISet<ITalonEffectObject> talonEffectObjectSet)
            {
                if (talonEffectObjectSet != null)
                {
                    this.talonEffectObjectSet = new HashSet<ITalonEffectObject>(talonEffectObjectSet);
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
                // Check that talonEffectObjectSet has been set
                if (this.talonEffectObjectSet == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(ITalonEffectObject).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}